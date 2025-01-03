using BizCore.Data;
using BizCore.Models;
using System.ComponentModel.DataAnnotations;

public class Orders
{
    [Key]
    public int OrderId { get; set; }

    [Required(ErrorMessage = "Order type is required.")]
    public string OrderType { get; set; }

    [Required(ErrorMessage = "Customer ID is required.")]
    public int? Fk_customer { get; set; }

    public Customers Customer { get; set; }

    public int? Fk_supplier { get; set; }

    public Suppliers Supplier { get; set; }

    [Required(ErrorMessage = "Order date is required.")]
    public DateTime OrderDate { get; set; }

    [Required(ErrorMessage = "Total order amount is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Total order must be greater than 0.")]
    public decimal TotalOrder { get; set; }

    // Corrected navigation property name (pluralized for consistency)
    public ICollection<OrderItems> OrderItems { get; set; }  // Use "OrderItems" instead of "OrderItem"
}
