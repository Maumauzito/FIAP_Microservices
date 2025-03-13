using CatalogService.Models;
using Microsoft.EntityFrameworkCore;


namespace CatalogService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>(); 
    }
}