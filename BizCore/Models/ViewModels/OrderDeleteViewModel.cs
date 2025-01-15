namespace BizCore.Models.ViewModels
{
    public class OrderDeleteViewModel
    {
            public int OrderId { get; set; }
            public string? OrderType { get; set; }
            public string? CustomerName { get; set; }
            public string? SupplierName { get; set; }
            public DateTime OrderDate { get; set; }
            public int TotalItems { get; set; }
            public decimal TotalPrice { get; set; }
        

    }
}