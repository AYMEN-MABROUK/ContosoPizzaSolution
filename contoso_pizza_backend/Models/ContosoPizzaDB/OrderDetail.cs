using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace contoso_pizza_backend.Models.ContosoPizzaDB
{
    [Table("OrderDetails", Schema = "ContosoPizza")]
    public partial class OrderDetail
    {
        [Key]
        public long Id { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; } = null!;
        [ForeignKey("ProductId")]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; } = null!;
    }
}
