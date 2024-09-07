using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HoTen = "Phan Minh Hoang";
            ViewBag.MSSV = "1822040473";
            ViewBag.Nam = 2024;

            return View();
        }
    }
}
