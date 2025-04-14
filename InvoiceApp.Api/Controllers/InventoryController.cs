using InvoiceApp.Api.Data;
using InvoiceApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public InventoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<InventoryItem>> GetInventoryItems()
    {
        return _context.InventoryItems.ToList();
    }

    [HttpPost]
    public ActionResult<InventoryItem> AddInventoryItem(InventoryItem item)
    {
        _context.InventoryItems.Add(item);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetInventoryItems), new { id = item.Id }, item);
    }
}
