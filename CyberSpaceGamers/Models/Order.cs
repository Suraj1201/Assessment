using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.ComponentModel.Design;

namespace CyberSpaceGamers.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total {  get; set; }


        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int OrderId {  get; set; }
        public Order Order { get; set; }
    }
}
