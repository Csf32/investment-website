using Microsoft.EntityFrameworkCore;
namespace api.Models
{
    public class FinancesDbContext : DbContext
    {
        public FinancesDbContext(DbContextOptions<FinancesDbContext> options) : base(options)
        {

        }

        public DbSet<UsersModel> users { get; set; }
        public DbSet<ProductsModel> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}