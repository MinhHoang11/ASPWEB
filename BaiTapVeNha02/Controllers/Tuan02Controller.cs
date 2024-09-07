using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HoTen = "Luong Duong Thanh Dat";
            ViewBag.MSSV = "1822040268";
            ViewBag.Nam = 2024;

            return View();
        }
    }
}
