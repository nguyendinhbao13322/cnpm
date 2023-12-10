using Microsoft.AspNetCore.Mvc;
using doan.Models;

namespace doan.Components
{
    [ViewComponent(Name = "BaiViet")]
    public class BaiVietComponent : ViewComponent
    {
        private DataContext _context;

        public BaiVietComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listOfMenu = _context.BaiViets.Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listOfMenu));
        }
    }
}
