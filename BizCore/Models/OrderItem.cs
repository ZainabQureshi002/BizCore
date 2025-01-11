using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;

namespace BizCore.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [ValidateNever]
        public Order Order { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [ValidateNever]
        public Product Product { get; set; }


        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be positive.")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;  // Calculated property
    }
}
