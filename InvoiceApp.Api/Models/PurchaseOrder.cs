namespace InvoiceApp.Api.Models;

public class PurchaseOrder
{
    public int Id { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public List<OrderItem> Items { get; set; } = new();
    public string Status { get; set; } = "Pending";
}

public class OrderItem
{
    public int Id { get; set; }
    public int InventoryItemId { get; set; }
    public int Quantity { get; set; }
}
