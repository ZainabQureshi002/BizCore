using System.ComponentModel.DataAnnotations;

namespace BizCore.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
   
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
       
        public string City { get; set; }
        public string State { get; set; }
        
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public ICollection<Orders> Order { get; set; } // If suppliers are linked to orders
    }
}
 