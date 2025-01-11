using System.ComponentModel.DataAnnotations;
using BizCore.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BizCore.Models
{
    public class OrderType
    {
        [Key]
        public int  OrderTypeId { get; set; }

        [Required(ErrorMessage = "Order type name is required.")]
        [StringLength(50, ErrorMessage = "Order type name cannot exceed 50 characters.")]
        public string OrderTypeName { get; set; }

        // Navigation property for OrderItems
        [ValidateNever]
        public ICollection<OrderItem> OrderItems { get; set; }
        
    }
}
