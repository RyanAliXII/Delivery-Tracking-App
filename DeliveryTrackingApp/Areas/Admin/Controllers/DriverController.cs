using DeliveryTrackingApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryTrackingApp.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class DriverController : Controller
    {
        // GET: DriverController
        private readonly ILogger<DriverController> _logger;
        public DriverController (ILogger<DriverController> logger){
            _logger = logger;
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
        public async Task<IActionResult> New([Bind("Id,GivenName, MiddleName, Surname")] Driver driver){
            
            // if(driver != null){
                
            // }
            _logger.LogInformation(ModelState.IsValid.ToString());
            return View();
        }
    }
}
