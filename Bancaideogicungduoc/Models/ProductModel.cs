﻿using Bancaideogicungduoc.Reponsitory.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bancaideogicungduoc.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nhập tên sản phẩm")]
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Nhập giá sản phẩm")]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(8)")]
        public decimal Price { get; set; }

        public BrandModel Brand { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Chọn brand")]
        public int BrandId { get; set; }

        public CategoryModel Category { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Chọn loại hàng")]
        public int CategoryId { get; set; }

        public string Image { get; set; } = "noimage.jpg";

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
