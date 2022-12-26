using Car_Shop.Domain;
using Car_Shop.Domain.Enum;
using Car_Shop.Domain.Helpers;
using Car_Shop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Car_Shop.DAL
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }
        
        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BORISENKO\SQLSERVER;Database=CarShop;Trusted_Connection=True;");//(localdb)\mssqllocaldb
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>(builder =>
            {
                builder.ToTable("Cars").HasKey(x => x.Id);

                builder.HasData(new Car
                {
                    Id = 1,
                    Name = "BMW X5",
                    Description = "Expensive car",
                    DateCreate = DateTime.Now,
                    Speed = 210,
                    Price = 50000,
                    Model = "BMW",
                    Avatar = null,
                    TypeCar = TypeCar.Suv
                },
                new Car
                {
                    Id = 2,
                    Name = "Audi A9",
                    Description = "Expensive and good car",
                    DateCreate = DateTime.Now,
                    Speed = 200,
                    Price = 45000,
                    Model = "Audi",
                    Avatar = null,
                    TypeCar = TypeCar.SportsCar
                },
                new Car
                {
                    Id = 3,
                    Name = "Ford Focus",
                    Description = "Just OK car",
                    DateCreate = DateTime.Now,
                    Speed = 150,
                    Price = 17000,
                    Model = "Ford",
                    Avatar = null,
                    TypeCar = TypeCar.PassengerCar
                },
                new Car
                {
                    Id = 4,
                    Name = "Skoda Octavia",
                    Description = "Great car!!!",
                    DateCreate = DateTime.Now,
                    Speed = 140,
                    Price = 20000,
                    Model = "Skoda",
                    Avatar = null,
                    TypeCar = TypeCar.PassengerCar
                },
                new Car
                {
                    Id = 5,
                    Name = "Lada Kalina",
                    Description = "Great car!!!",
                    DateCreate = DateTime.Now,
                    Speed = 230,
                    Price = 15000,
                    Model = "BMW",
                    Avatar = null,
                    TypeCar = TypeCar.PassengerCar
                }
                );
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.HasData(new User
                {
                    Id = 1,
                    Name = "Alexander",
                    Password = HashPasswordHelper.HashPassword("123456"),
                    Role = Role.Admin
                });
                
                builder.Property(x => x.Id).ValueGeneratedOnAdd(); // АВТО ИНКРЕМЕНТ ID-шника
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
