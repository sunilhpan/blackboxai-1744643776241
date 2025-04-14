using InvoiceApp.Api.Data;
using InvoiceApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Transaction>> GetTransactions()
    {
        return _context.Transactions.ToList();
    }

    [HttpPost]
    public ActionResult<Transaction> CreateTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTransactions), new { id = transaction.Id }, transaction);
    }
}
