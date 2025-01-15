namespace BizCore.Models.ViewModels
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.AspNetCore.Mvc.Rendering;
    public class OrderEditViewModel
    {
        public int OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        [ValidateNever]
        public List<OrderItemEditViewModel>? OrderItems { get; set; }
        [ValidateNever]
        public List<SelectListItem>? Customers { get; set; }
        [ValidateNever]
        public List<SelectListItem>? Suppliers { get; set; }
        [ValidateNever]
        public List<SelectListItem>? Products { get; set; }
    }

    public class OrderItemEditViewModel
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}