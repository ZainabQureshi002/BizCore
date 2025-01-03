using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizCore.Models
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Order ID")]
        [ForeignKey(nameof(Order))]
        public int FK_order { get; set; }

        public Orders Order { get; set; }

        [DisplayName("Product ID")]
        [ForeignKey(nameof(Product))]
        public int Fk_Product { get; set; }

        public Products Product { get; set; }

        [DisplayName("Order Type")]
        [ForeignKey(nameof(OrderType))]
        public int Fk_OrderType { get; set; }

        public OrderType OrderType { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        
        public decimal TotalPrice { get; set; }
    }
}
