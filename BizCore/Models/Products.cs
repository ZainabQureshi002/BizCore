using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BizCore.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        [StringLength(500, ErrorMessage = "Product description cannot exceed 500 characters.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Purchase price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Purchase price must be greater than zero.")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Sales price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sales price must be greater than zero.")]
        public decimal SalesPrice { get; set; }

        [Required(ErrorMessage = "In-stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "In-stock quantity cannot be negative.")]
        public int InStock { get; set; }

        
        [ValidateNever]
        public string PictureUrl { get; set; } // Stores the path to the product's image
        // Navigation property for OrderItems
        [NotMapped] // This tells EF Core not to map this property to the database
        public IFormFile? ImageFile { get; set; }
        [ValidateNever]
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
