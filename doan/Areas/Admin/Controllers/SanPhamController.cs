using doan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly DataContext _context;
        public SanPhamController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiSP()
        {
            var sp =_context.SanPhams.ToList();
            return View(sp);
        }
        public IActionResult Them()
        {
            var dsdm = (from m in _context.DanhMucs
                          select new SelectListItem()
                          {
                              Text = m.TenDanhMuc,
                              Value = m.ID.ToString()
                          }).ToList();
            dsdm.Insert(0, new SelectListItem()
            {
                Text = "----Chọn----",
                Value = "0"
            });
            ViewBag.dsdm = dsdm;

            return View();
        }
        [HttpPost]
        public IActionResult Them(SanPham sp)
        {
            _context.SanPhams.Add(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Sua(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var dsdm = (from m in _context.DanhMucs
                        select new SelectListItem()
                        {
                            Text = m.TenDanhMuc,
                            Value = m.ID.ToString()
                        }).ToList();
            dsdm.Insert(0, new SelectListItem()
            {
                Text = "----Chọn----",
                Value = "0"
            });
            ViewBag.dsdm = dsdm;

            var sp = _context.SanPhams.Find(id);
            return View(sp);
        }
        [HttpPost]
        public IActionResult Sua(SanPham sp)
        {
            _context.SanPhams.Update(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Xoa(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.SanPhams.Find(id);
            return View(sp);

        }
        [HttpPost]
        public IActionResult Xoa(SanPham sp)
        {
            _context.SanPhams.Remove(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
    }
}
