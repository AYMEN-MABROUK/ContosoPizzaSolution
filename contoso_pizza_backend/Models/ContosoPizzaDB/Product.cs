using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace contoso_pizza_backend.Models.ContosoPizzaDB
{
    [Table("Product", Schema = "ContosoPizza")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        [Precision(6, 2)]
        public decimal Price { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
