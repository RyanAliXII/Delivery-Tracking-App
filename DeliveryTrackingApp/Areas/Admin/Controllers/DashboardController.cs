using Microsoft.AspNetCore.Mvc;

namespace DeliveryTrackingApp.Areas.Controllers
{   
    [Area("Admin")]
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public ActionResult Index()
        {
            return View();
        }

    }
}
