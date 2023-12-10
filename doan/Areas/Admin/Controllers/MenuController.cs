using doan.Models;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;
        public MenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiDS()
        {
            var dsmenu = _context.Menus.ToList();
            return View(dsmenu);    
        }
        public IActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Them(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
            return RedirectToAction("HienThiDS");
        }
        public IActionResult Sua(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var menu = _context.Menus.Find(id);
            return View(menu);
        }
        [HttpPost]
        public IActionResult Sua(Menu menu)
        {
            _context.Menus.Update(menu);
            _context.SaveChanges();
            return RedirectToAction("HienThiDS");
        }
        public IActionResult Xoa(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var menu = _context.Menus.Find(id);
            return View(menu);

        }
        [HttpPost]
        public IActionResult Xoa(Menu menu)
        {
            _context.Menus.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction("HienThiDS");
        }
    }
}
