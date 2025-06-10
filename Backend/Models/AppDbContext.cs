using Microsoft.EntityFrameworkCore;

namespace crypto_wallet_api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }
    }
}