using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include(sp => sp.TheLoai).ToList();
            return View(sanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Details(int sanphamid)
        {
            // T?o gi? h�ng ? trang Details �? x? l? ch?c n�ng th�m v�o gi? sau n�y
            GioHang giohang = new GioHang()
            {
                SanPhamId = sanphamid,
                SanPham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == sanphamid),
                Quantity = 1
            };
            return View(giohang);
        }
        [HttpPost]
        [Authorize] // Y�u c?u ��ng nh?p
        public IActionResult Details(GioHang giohang)
        {
            // L?y th�ng tin t�i kho?n
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            giohang.ApplicationUserId = claim.Value;

            // Ki?m tra s?n ph?m �? c� trong gi? h�ng ch�a
            var giohangdb = _db.GioHang.FirstOrDefault(sp => sp.SanPhamId == giohang.SanPhamId
            && sp.ApplicationUserId == giohang.ApplicationUserId);
            if (giohangdb == null) // N?u kh�ng c� s?n ph?m trong gi? h�ng
            {
                _db.GioHang.Add(giohang); // Th�m s?n ph?m v�o gi? h�ng
            }
            else // N?u kh�ng c� s?n ph?m trong gi? h�ng
            {

                giohangdb.Quantity += giohang.Quantity; // C?p nh?t s? l�?ng s?n ph?m
            }

            // Th�m s?n ph?m v�o gi? h�ng
            _db.GioHang.Add(giohang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FilterByTheLoai(int id)
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").Where(sp => sp.TheLoai.Id == id).ToList();
            return View("Index", sanpham);
        }
    }
}