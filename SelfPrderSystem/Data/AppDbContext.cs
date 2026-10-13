using Microsoft.EntityFrameworkCore;
using SelfPrderSystem.Models;

namespace SelfPrderSystem.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext>options)
            : base(options) {

        }

        public DbSet<Category> Categories => Set<Category>();        
        public DbSet<Product> Products => Set<Product>();

    }
}
