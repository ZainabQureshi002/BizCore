namespace BizCore.Models.ViewModels;
public class OrderViewModel
{
    public int OrderId { get; set; }
    public string? OrderType { get; set; }
    public string? CustomerName { get; set; }
    public string? SupplierName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
}
