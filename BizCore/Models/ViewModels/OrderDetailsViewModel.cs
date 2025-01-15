namespace BizCore.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string? OrderType { get; set; }
        public string? CustomerName { get; set; }
        public string? SupplierName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemViewModel>? Items { get; set; }
    }

    public class OrderItemViewModel
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

}




