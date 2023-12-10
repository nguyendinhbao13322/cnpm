using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using doan.Models;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var DSHoaDon = _context.hoaDonAdmins.ToList();
            return View(DSHoaDon);
        }
        public IActionResult HoaDonChiTiet(int id)
        {
            var hoadon = _context.hoaDonAdmins.Where(o => o.IDHoaDon == id).ToList();
            return View(hoadon);
        }

        public IActionResult XacNhanDon(int id)
        {
            var hoadon = _context.HoaDons.Find(id);
            hoadon.TrangThai = 1;
            _context.HoaDons.Update(hoadon);
            _context.SaveChanges();

            return RedirectToAction("HoaDonChiTiet", new { id = id });
        }

        public IActionResult HuyDonHang(int id)
        {
            var hoadon = _context.HoaDons.Find(id);
            hoadon.TrangThai = -1;
            _context.HoaDons.Update(hoadon);
            _context.SaveChanges();

            return RedirectToAction("HoaDonChiTiet", new { id = id });
        }
    }
}
