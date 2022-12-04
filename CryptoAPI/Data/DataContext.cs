using Microsoft.EntityFrameworkCore;

namespace CryptoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            //Database.EnsureCreated();
        }
        public DbSet<Crypto> cryptos { get; set; }
    }
}
