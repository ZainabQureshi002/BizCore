using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizCore.Models.ViewModels
{
    public class OrderCreateViewModel
    {
        public Order Order { get; set; } = new Order
        {
            OrderItems = new List<OrderItem> { new OrderItem() }
        };

        [ValidateNever]
        public List<SelectListItem> Customers { get; set; } = new List<SelectListItem>(); // Ensure this is initialized

        [ValidateNever]
        public List<SelectListItem> Suppliers { get; set; } = new List<SelectListItem>(); // Ensure this is initialized

        [ValidateNever]
        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>(); // Ensure this is initialized
    }
}
