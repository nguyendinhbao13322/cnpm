using Microsoft.AspNetCore.Mvc;
using doan.Models;

namespace doan.Components
{
    [ViewComponent(Name = "Menu")]
    public class MenuComponent : ViewComponent
    {
        private DataContext _context;

        public MenuComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listOfMenu = (from m in _context.Menus
                              where (m.TrangThai == true)
                              select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listOfMenu));
        }
    }
}
