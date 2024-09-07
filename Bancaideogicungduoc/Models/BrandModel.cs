using System.ComponentModel.DataAnnotations;

namespace Bancaideogicungduoc.Models
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "nhap ten")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "nhap mo ta")]
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Status { get; set; }

    }
}
