using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class DataContext : DbContext {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        public DbSet<Product> Product { get; set; }

        
    }
}