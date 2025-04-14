namespace InvoiceApp.Api.Models;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = "expense"; // or "income"
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
