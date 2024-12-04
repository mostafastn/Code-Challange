using Domain.DocumentAggregates;
using Domain.EntityAggregates;
using Microsoft.EntityFrameworkCore;

namespace efdb
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Entity> Entities { get; set; }

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
            modelBuilder.Entity<Entity>()
                .HasData(
                    new Entity { Id = 1, TableName = "Table 1" },
                    new Entity { Id = 2, TableName = "Table 2" },
                    new Entity { Id = 3, TableName = "Table 3" });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
