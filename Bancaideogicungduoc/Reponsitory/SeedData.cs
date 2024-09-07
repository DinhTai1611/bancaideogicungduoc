using Bancaideogicungduoc.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Bancaideogicungduoc.Reponsitory
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();
            if (!_context.Products.Any())
            {
                CategoryModel food = new CategoryModel { Name = "Food", Slug = "food", Description = "food", Status = 1 };
                CategoryModel phone = new CategoryModel { Name = "Phone", Slug = "Phone", Description = "Phone", Status = 1 };

                BrandModel farmer = new BrandModel { Name = "Farmer", Slug = "farmer", Description = "farmer", Status = 1 };
                BrandModel apple = new BrandModel { Name = "Apple", Slug = "Apple", Description = "Apple", Status = 1 };

                _context.Products.AddRange(
                    new ProductModel { Name = "tao xanh", Slug = "tao xanh", Description = "chua vailon", Price = 100000, Brand = farmer, Category = food, Image = "" },
                    new ProductModel { Name = "delli7520", Slug = "delli7520", Description = "lapngu", Price = 5000000, Brand = apple, Category = phone, Image = "" }
                );
                _context.SaveChanges();
            }
        }
    }
}
