using Microsoft.AspNetCore.Mvc;
using doan.Models;

namespace doan.Components
{
    [ViewComponent(Name = "SanPhamMoi")]
    public class SanPhamMoiComponent : ViewComponent
    {
        private DataContext _context;

        public SanPhamMoiComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sp = _context.SanPhams.Take(10).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", sp));
        }
    }
}
