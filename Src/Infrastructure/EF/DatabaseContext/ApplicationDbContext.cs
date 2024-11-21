using Domain.CustomerAggregates;
using Domain.OrderAggregates;
using Domain.ProductAggregates;
using Microsoft.EntityFrameworkCore;


namespace EF.DatabaseContext
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=MyAppDb;Trusted_Connection=True;",
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            FluentBuilder(modelBuilder);
        }

        private void FluentBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer { Id = 1, Name = "Customer 1", PhoneNumber = "9876543210", Email = "info1@test.com" },
                    new Customer { Id = 2, Name = "Customer 2", PhoneNumber = "1234567890", Email = "info2@test.com" },
                    new Customer { Id = 3, Name = "Customer 3", PhoneNumber = "4567891230", Email = "info3@test.com" });

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Product 1", Price = 10000, IsFragile = false },
                    new Product { Id = 2, Name = "Product 2", Price = 20000, IsFragile = false },
                    new Product { Id = 3, Name = "Product 3", Price = 30000, IsFragile = true });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
