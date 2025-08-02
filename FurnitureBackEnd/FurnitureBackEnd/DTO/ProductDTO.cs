using System.ComponentModel.DataAnnotations;

namespace FurnitureBackEnd.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000000)]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0.1, 1000)]
        public decimal Weight { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public bool IsSelected { get; set; }
    }
}
