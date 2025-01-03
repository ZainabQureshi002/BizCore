using System.ComponentModel.DataAnnotations;
using BizCore.Data;

namespace BizCore.Models
{
    public class OrderType
    {
        [Key]
        public int OrderTypeId { get; set; }

        [Required(ErrorMessage = "Order type name is required.")]
        [StringLength(50, ErrorMessage = "Order type name cannot exceed 50 characters.")]
        public string Name { get; set; }

        // Navigation property for OrderItems
        public ICollection<OrderItems> OrderItems { get; set; }
        
    }
}
