using BaiTap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap05.Controllers
{
    public class TheloaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = " Ngay 28";
            ViewBag.Thang = " Thang 2";
            ViewData["Nam"] = " Nam 2030";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModel
            {
                Id = 1,
                Name = " Trinh Tham"
            };
            return View(theloai);
        }
    }
}
