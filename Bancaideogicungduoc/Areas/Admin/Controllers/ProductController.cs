using Bancaideogicungduoc.Reponsitory;
using Microsoft.AspNetCore.Mvc;

namespace Bancaideogicungduoc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        public ProductController(DataContext Context)
        {
            _dataContext = Context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
