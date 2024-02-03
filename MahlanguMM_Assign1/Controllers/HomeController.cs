using Microsoft.AspNetCore.Mvc;

namespace MahlanguMM_Assign1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
