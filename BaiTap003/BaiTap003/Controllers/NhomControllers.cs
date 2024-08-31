using Microsoft.AspNetCore.Mvc;

namespace BaiTap003.Controllers
{
    public class NhomControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
