using crypto_wallet_api.DTOs;
using crypto_wallet_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crypto_wallet_api.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> Get()
        {
            var clients = await _context.Clients
                .ToListAsync();

            var clientDtos = clients.Select(client => new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email
            }).ToList();

            return Ok(clientDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(n => n.Id == id);

            if (client == null)
                return NotFound();

            var dto = new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = client }, client);
        }
    }
}