using BizCore.Data;
using BizCore.Models;
using System.ComponentModel.DataAnnotations;

public class Products
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product description is required.")]
    [StringLength(500)]
    public string Description { get; set; }

    [Url(ErrorMessage = "Picture must be a valid URL.")]
    public string Picture { get; set; }

    [Required(ErrorMessage = "Purchase price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Purchase price must be greater than 0.")]
    public decimal PurchasePrice { get; set; }

    [Required(ErrorMessage = "Sales price is required.")]
    
    public decimal SalesPrice { get; set; }

    [Required(ErrorMessage = "In-stock quantity is required.")]
  
    public int InStock { get; set; }

    // Corrected navigation property name (pluralized for consistency)
    public ICollection<OrderItems> OrderItems { get; set; }  // Use "OrderItems" instead of "OrderItem"
}
