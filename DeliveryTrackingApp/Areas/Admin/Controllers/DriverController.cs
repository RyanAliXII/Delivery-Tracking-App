using DeliveryTrackingApp.Areas.Admin.Models;
using DeliveryTrackingApp.Areas.Admin.ViewModels;
using DeliveryTrackingApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
namespace DeliveryTrackingApp.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class DriverController : Controller
    {
        // GET: DriverController
        private readonly ILogger<DriverController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMinioClient _minio;
        public DriverController (ILogger<DriverController> logger, IUnitOfWork unitOfWork, IMinioClient mc){
            _logger = logger;
            _unitOfWork = unitOfWork;
            _minio = mc;
        }
        public IActionResult Index()
        {  var drivers = _unitOfWork.DriverRepository.GetAllDrivers();
           return View(drivers);
        }
        public IActionResult New(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(NewDriverViewModel driver){
            if(!ModelState.IsValid){
                return View(driver);
            }
            var contentType = driver.LicenseImage?.ContentType;
          
            if(contentType != "image/jpeg" && contentType != "image/png"){
                ModelState.AddModelError("LicenseImage", "File should be jpg or png.");
            }
            try{
                using(var stream = driver.LicenseImage?.OpenReadStream() ){
                    var ext = Path.GetExtension(driver.LicenseImage?.FileName);
                    var objectName = $"/driver-licenses/{Guid.NewGuid()}{ext}";
                    var putObjectArgs = new PutObjectArgs();
                    _logger.LogInformation(objectName);
                    _logger.LogInformation(contentType);
                    putObjectArgs.WithBucket("delivery-app");
                    putObjectArgs.WithObject(objectName);
                    putObjectArgs.WithStreamData(stream);
                    putObjectArgs.WithObjectSize(stream?.Length ?? -1);
                    putObjectArgs.WithContentType(contentType);
                    
                    var uploadResult = await _minio.PutObjectAsync(putObjectArgs);
                    driver.LicenseImagePath = uploadResult.ObjectName;
                    
                    _logger.LogInformation(uploadResult.ObjectName);
                }
                _unitOfWork.DriverRepository.Add(new Driver(driver));
            }catch(Exception e){
                _logger.LogError(e.Message + e.StackTrace);
                return View(driver);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
