using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBackEnd.Models
{
    public class Product
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

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        [Range(0.1, 1000, ErrorMessage = "Weight must be between 0.1 kg and 1000 kg.")]
        [Display(Name = "Weight (in kg)")]
        public decimal Weight { get; set; }

        [StringLength(50)]
        public string Color { get; set; }
        public bool IsSelected { get; set; }
    }
}
