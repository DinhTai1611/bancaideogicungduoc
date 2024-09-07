using Bancaideogicungduoc.Models;
using Bancaideogicungduoc.Models.ViewModel;
using Bancaideogicungduoc.Reponsitory;
using Microsoft.AspNetCore.Mvc;

namespace Bancaideogicungduoc.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;
        public CartController(DataContext _context)
        {
            _dataContext = _context;
        }
        public IActionResult Index()
        {
            List<CartModel> cartItems = HttpContext.Session.GetJson<List<CartModel>>("Cart") ?? new List<CartModel>();
            CartViewModel cartViewModel = new()
            {
                Carts = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };
            return View(cartViewModel);
        }
        public async Task<IActionResult> Add(int Id)
        {
            ProductModel product = await _dataContext.Products.FindAsync(Id);
            List<CartModel> cartItems = HttpContext.Session.GetJson<List<CartModel>>("Cart") ?? new List<CartModel>();
            CartModel cartModel = cartItems.Where(c => c.ProductId == Id).FirstOrDefault();
            if (cartModel == null)
            {
                cartItems.Add(new CartModel(product));
            }
            else
            {
                cartModel.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cartItems);
            TempData["success"] = "Add success";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Increase(int Id)
        {
            List<CartModel> cartItems = HttpContext.Session.GetJson<List<CartModel>>("Cart");
            CartModel cartModel = cartItems.Where(c => c.ProductId == Id).FirstOrDefault();
            if (cartModel.Quantity > 0)
            {
                ++cartModel.Quantity;
            }

            if (cartItems.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cartItems);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Decrease(int Id)
        {
            List<CartModel> cartItems = HttpContext.Session.GetJson<List<CartModel>>("Cart");
            CartModel cartModel = cartItems.Where(c => c.ProductId == Id).FirstOrDefault();
            if (cartModel.Quantity > 1)
            {
                --cartModel.Quantity;
            }
            else
            {
                cartItems.RemoveAll(p => p.ProductId == Id);
            }
            if (cartItems.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cartItems);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int Id)
        {
            List<CartModel> cartItems = HttpContext.Session.GetJson<List<CartModel>>("Cart");
            cartItems.RemoveAll(p => p.ProductId == Id);
            if (cartItems.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cartItems);
            }
            TempData["success"] = "Remove success";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear(int Id)
        {
            HttpContext.Session.Remove("Cart");
            TempData["success"] = "Clear success";
            return RedirectToAction("Index");
        }
    }
}
