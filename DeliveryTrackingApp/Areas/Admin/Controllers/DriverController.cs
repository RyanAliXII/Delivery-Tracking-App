using DeliveryTrackingApp.Areas.Admin.Models;
using DeliveryTrackingApp.Areas.Admin.ViewModels;
using DeliveryTrackingApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Minio;
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
        public IActionResult New(NewDriverViewModel driver){
            if(!ModelState.IsValid){
                return View(driver);
            }
            var contentType = driver.LicenseImage?.ContentType;
            if(contentType != "image/jpeg" && contentType != "image/png"){
                ModelState.AddModelError("LicenseImage", "File should be jpg or png.");
            }
            try{
                _unitOfWork.DriverRepository.Add(new Driver(driver));
            }catch(Exception e){
                _logger.LogError(e.Message + e.StackTrace);
                return View(driver);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
