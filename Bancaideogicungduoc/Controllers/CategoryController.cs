using Bancaideogicungduoc.Models;
using Bancaideogicungduoc.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bancaideogicungduoc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        public CategoryController(DataContext Context)
        {
            _dataContext = Context;
        }
        public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            var productByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);
            return View(await productByCategory.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
