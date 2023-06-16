using ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<ProductCategory> ProductCategory { get; set; } = default!;
        public DbSet<ProductDesc> ProductDesc { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductDesc>()
                .HasOne(d => d.Product)
                .WithMany(p => p.Desc)
                .HasForeignKey(d => d.ProductId);
        }
    }
}
