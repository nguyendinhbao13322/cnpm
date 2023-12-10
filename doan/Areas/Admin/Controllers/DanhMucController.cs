using doan.Models;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucController : Controller
    {
        private readonly DataContext _context;
        public DanhMucController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThi()
        {
            var bv = _context.DanhMucs.ToList();
            return View(bv);    
        }
        public IActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Them(DanhMuc bv)
        {
            _context.DanhMucs.Add(bv);
            _context.SaveChanges();
            return RedirectToAction("HienThi");
        }
        public IActionResult Sua(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var bv = _context.DanhMucs.Find(id);
            return View(bv);
        }
        [HttpPost]
        public IActionResult Sua(DanhMuc bv)
        {
            _context.DanhMucs.Update(bv);
            _context.SaveChanges();
            return RedirectToAction("HienThi");
        }
        public IActionResult Xoa(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bv = _context.DanhMucs.Find(id);
            return View(bv);

        }
        [HttpPost]
        public IActionResult Xoa(DanhMuc bv)
        {
            _context.DanhMucs.Remove(bv);
            _context.SaveChanges();
            return RedirectToAction("HienThi");
        }
    }
}
