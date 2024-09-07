using Bancaideogicungduoc.Models;
using Bancaideogicungduoc.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bancaideogicungduoc.Controllers
{
    public class BrandController : Controller
    {
        private readonly DataContext _dataContext;
        public BrandController(DataContext Context)
        {
            _dataContext = Context;
        }
        public async Task<IActionResult> Index(string Slug = "")
        {
            BrandModel brand = _dataContext.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
            if (brand == null)
            {
                return RedirectToAction("Index");
            }
            var productByBrand = _dataContext.Products.Where(p => p.BrandId == brand.Id);
            return View(await productByBrand.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
