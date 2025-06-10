using crypto_wallet_api.DTOs;
using crypto_wallet_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crypto_wallet_api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> Get([FromQuery] int clientId)
        {
            var transactions = await _context.Transactions
                .Where(x => x.ClientId == clientId)
                .Include(x => x.CryptoCurrency)
                .ToListAsync();

            var transactionDtos = transactions.Select(x => new TransactionDTO
            {
                Id = x.Id,
                Action = (int)x.Action,
                CryptoCode = x.CryptoCurrency?.Code ?? "",
                CryptoAmount = x.CryptoAmount,
                Money = x.Money,
                Datetime = x.Datetime
            }).ToList();

            return Ok(transactionDtos);
        }
    }
}