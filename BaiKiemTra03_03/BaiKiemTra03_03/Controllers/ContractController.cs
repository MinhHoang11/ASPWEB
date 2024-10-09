using BaiKiemTra03_03.Data;
using BaiKiemTra03_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_03.Controllers
{
    [Area("Admin")]
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContractController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Contract> contracts = _db.Contract.Include("Customer").ToList();
            return View(contracts);

        }
        public IActionResult Upsert(int id)
        {
            Customer customer = new Customer();
            IEnumerable<SelectListItem> dstheloai = _db.Customer.Select(
                item => new SelectListItem
                {
                    Value = item.CustomerId.ToString(),
                    Text = item.CustomerName.ToString()


                });

            ViewBag.DSTheLoai = dstheloai;

            if (id == 0) // Create / Insert
            {
                return View(customer);
            }
            else // Edit / Update
            {
                customer = _db.Customer.Include("Contract").FirstOrDefault(ct => ct.CustomerId == id);
                return View(customer);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    _db.Customer.Add(customer);
                }
                else
                {
                    _db.Customer.Update(customer);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = _db.Customer.FirstOrDefault(sp => sp.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            _db.Customer.Remove(customer);
            _db.SaveChanges();

            return Json(new { success = true });
        }
    }
}
