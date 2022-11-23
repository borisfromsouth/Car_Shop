using Car_Shop.Domain;
using Car_Shop.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace Car_Shop.DAL
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BORISENKO\SQLSERVER;Database=CarShop;Trusted_Connection=True;");//(localdb)\mssqllocaldb
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Car>(builder =>
            //{
            //    builder.ToTable("Cars").HasKey(x => x.Id);

            //    builder.HasData(new Car
            //    {
            //        Id = 1,
            //        Name = "Car",
            //        Description = new string('A', 50),
            //        DateCreate = DateTime.Now,
            //        Speed = 230,
            //        Model = "BMW",
            //        Avatar = null,
            //        TypeCar = TypeCar.PassengerCar
            //    });
            //});
        }
    }
}
