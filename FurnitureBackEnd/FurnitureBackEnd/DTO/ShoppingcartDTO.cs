namespace FurnitureBackEnd.DTO
{
    public class ShoppingcartDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
