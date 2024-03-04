using DeliveryTrackingApp.Areas.Admin.Models;
using DeliveryTrackingApp.Areas.Admin.ViewModels;
using DeliveryTrackingApp.Repositories;
using DeliveryTrackingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DeliveryTrackingApp.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class DriverController : Controller
    {
        private readonly ILogger<DriverController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMinioObjectStorage _minio;
        private IConfiguration _config;
        public DriverController (ILogger<DriverController> logger, IUnitOfWork unitOfWork, IMinioObjectStorage mc, IConfiguration config){
            _logger = logger;
            _unitOfWork = unitOfWork;
            _minio = mc;
            _config = config;
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
        public async Task<IActionResult> New(MutateDriverViewModel driver){
            ValidateUniqueFields(driver);
            if(!ModelState.IsValid){
                return View(driver);
            }
            var contentType = driver.LicenseImage?.ContentType  ?? "";
            if(contentType != "image/jpeg" && contentType != "image/png"){
                ModelState.AddModelError("LicenseImage", "File should be jpg or png.");
            }
            try{
                using(var stream = driver.LicenseImage?.OpenReadStream() ){ 
                  var uploadResult =  await _minio.Upload(File: stream, ContentType: contentType, Folder: "driver-licenses");
                  driver.LicenseImagePath = uploadResult.ObjectName;
                }
                _unitOfWork.DriverRepository.Add(new Driver(driver));
            }catch(Exception e){
                _logger.LogError(e.Message + e.StackTrace);
                return View(driver);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid ID){
             var driver = _unitOfWork.DriverRepository.GetById(ID);
             if (driver.Id == Guid.Empty) {
                return NotFound();
            }
            return View(new MutateDriverViewModel(driver));
        }
        private void ValidateUniqueFields(MutateDriverViewModel d){
            var idNumber = d.LicenseIdNumber?.Trim() ?? "";
            var email = d.Account?.Email?.Trim() ?? "";
            var mobileNumber = d.MobileNumber?.Trim() ?? "";
        
            if(!idNumber.IsNullOrEmpty() && _unitOfWork.DriverRepository.IsLicenseIdNumberAlreadyRegistered(idNumber)){
               ModelState.AddModelError("LicenseIdNumber", "License ID number is already registered.");
            }
            if(!email.IsNullOrEmpty() && _unitOfWork.DriverRepository.IsEmailAlreadyRegistered(email)){
                ModelState.AddModelError("Account.Email", "Email is already registered.");
            }
            if(!email.IsNullOrEmpty() && _unitOfWork.DriverRepository.IsMobileNumberAlreadyRegistered(mobileNumber)){
                ModelState.AddModelError("MobileNumber", "Mobile number is already registered.");
            }
        }
    }
}
