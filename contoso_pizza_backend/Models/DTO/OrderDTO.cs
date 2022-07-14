namespace contoso_pizza_backend.Models.DTO
{
    public partial class OrderDTO
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }

    }
}