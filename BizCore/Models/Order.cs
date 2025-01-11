using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace BizCore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public Customer Customer { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        [ValidateNever]
        public Supplier Supplier { get; set; }
        public int OrderTypeId { get; set; }

        [ForeignKey(nameof(OrderTypeId))]
        [ValidateNever]
        public OrderType OrderType { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }

        [ValidateNever]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
