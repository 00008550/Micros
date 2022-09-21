using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataFolder
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
