namespace contoso_pizza_backend.Models.DTO
{
    public partial class ProductDTO
    {
        
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

    }
}