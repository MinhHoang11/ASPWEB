using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SanPham(SanPhamViewModel sanpham)
        {
            @sanpham.TenSanPham = "Chau Hoa";
            @sanpham.GiaBan = 100000;
            @sanpham.AnhMoTa = "https://khuonmaucongcnc.com.vn/upload/images/chau-hoa-hong.jpg";

            return View(sanpham);
        }
    }
}
