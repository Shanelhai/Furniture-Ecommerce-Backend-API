using FurnitureBackEnd.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBackEnd.Models
{
    public class Shoppingcart
    {
        public Shoppingcart()
        {
            Count = 1;
        }
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Count { get; set; }
        [NotMapped]
        public decimal Price { get; set; }
    }
}
