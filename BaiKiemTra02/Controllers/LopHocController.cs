using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BaiKiemTra02.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LopHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.LopHocs.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var lopHoc = await _context.LopHocs.FirstOrDefaultAsync(m => m.Id == id);
            if (lopHoc == null)
                return NotFound();

            return View(lopHoc);

        public IActionResult Tao()
        {
            var lopHoc = new LopHoc();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tao([Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }
        public async Task<IActionResult> ChinhSua(int? id)
        {
            if (id == null)
                return NotFound();

            var lopHoc = await _context.LopHocs.FindAsync(id);
            if (lopHoc == null)
                return NotFound();

            return View(lopHoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChinhSua(int id, [Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (id != lopHoc.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }

        public async Task<IActionResult> Xoa(int? id)
        {
            if (id == null)
                return NotFound();

            var lopHoc = await _context.LopHocs.FirstOrDefaultAsync(m => m.Id == id);
            if (lopHoc == null)
                return NotFound();

            return View(lopHoc);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lopHoc = await _context.LopHocs.FindAsync(id);
            _context.LopHocs.Remove(lopHoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
