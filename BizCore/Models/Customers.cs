using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BizCore.Models
{
    public class Customers
    {
        [Key]  // Correct attribute name
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

       
        public string Email { get; set; }
        // Navigation property
        [ValidateNever]

        public ICollection<Orders> Order { get; set; }
    }
}
