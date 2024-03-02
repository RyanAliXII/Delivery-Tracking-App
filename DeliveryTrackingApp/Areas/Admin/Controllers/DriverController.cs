using DeliveryTrackingApp.Areas.Admin.Models;
using DeliveryTrackingApp.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace DeliveryTrackingApp.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class DriverController : Controller
    {
        // GET: DriverController
        private readonly ILogger<DriverController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public DriverController (ILogger<DriverController> logger, IUnitOfWork unitOfWork){
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {  
            return View();
        }
        public IActionResult New(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Driver driver){
            if(!ModelState.IsValid){
                return View(driver);
            }
                    
            return View();
        }
    }
}
