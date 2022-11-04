using Car_Shop.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car_Shop.DAL
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Car> Car { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BORISENKO\SQLSERVER;Database=CarShop;Trusted_Connection=True;");//(localdb)\mssqllocaldb
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
