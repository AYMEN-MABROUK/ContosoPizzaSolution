using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace contoso_pizza_backend.Models.ContosoPizzaDB
{
    [Table("Order", Schema = "ContosoPizza")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public long Id { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime OrderPlaced { get; set; }
        public long CustomerId { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? OrderFulfilled { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; } = null!;
        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
