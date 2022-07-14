namespace contoso_pizza_backend.Models.DTO
{
    public partial class OrderDetailDTO
    {
        
        public long Id { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        
    }
}