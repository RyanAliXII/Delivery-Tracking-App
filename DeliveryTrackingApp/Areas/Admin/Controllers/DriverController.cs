using DeliveryTrackingApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryTrackingApp.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class DriverController : Controller
    {
        // GET: DriverController
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New(){
            return View();
        }
    }
}
