using InvoiceApp.Api.Data;
using InvoiceApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
    private readonly AppDbContext _context;

    public PurchaseOrderController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PurchaseOrder>> GetPurchaseOrders()
    {
        return _context.PurchaseOrders.ToList();
    }

    [HttpPost]
    public ActionResult<PurchaseOrder> CreatePurchaseOrder(PurchaseOrder order)
    {
        _context.PurchaseOrders.Add(order);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPurchaseOrders), new { id = order.Id }, order);
    }
}
