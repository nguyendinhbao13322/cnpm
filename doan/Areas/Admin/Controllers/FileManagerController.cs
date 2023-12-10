using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Route("/Admin/file-manager")]
    [Area("Admin")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
