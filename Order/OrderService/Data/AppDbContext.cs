using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura��o do relacionamento 1:N entre Order e OrderItem
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne() 
                .HasForeignKey(oi => oi.OrderId);

            // Configura��o para a tabela OrderItem, se necess�rio
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.Id); 

            
        }
    }
}