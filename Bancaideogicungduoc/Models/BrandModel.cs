using System.ComponentModel.DataAnnotations;

namespace Bancaideogicungduoc.Models
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nhập tên thương hiệu")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập mô tả")]
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Status { get; set; }

    }
}
