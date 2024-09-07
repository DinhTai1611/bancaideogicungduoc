using Bancaideogicungduoc.Reponsitory;
using Microsoft.AspNetCore.Mvc;

namespace Bancaideogicungduoc.Controllers
{
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

        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");

            var productById = _dataContext.Products.Where(p => p.Id == Id).FirstOrDefault();
            return View(productById);
        }
    }
}
