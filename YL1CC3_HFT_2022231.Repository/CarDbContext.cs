using Microsoft.EntityFrameworkCore;
using System;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.Repository
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public CarDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("autok")
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(t => t
            .HasOne(t=>t.Brand)
            .WithMany(t=>t.Cars)
            .HasForeignKey(t=>t.BrandId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Rent>(t => t
            .HasOne(t=>t.Car)
            .WithMany(t=>t.Rents)
            .HasForeignKey(t=>t.CarId)
            .OnDelete(DeleteBehavior.Cascade)
            );
            modelBuilder.Entity<Brand>(t => t
            .HasMany(t => t.Cars)
            .WithOne(t => t.Brand)
            .OnDelete(DeleteBehavior.Cascade));



            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand() { Id = 1, Name = "BMW" },
                new Brand() { Id = 2, Name = "Citroen" },
                new Brand() { Id = 3, Name = "Audi" },
                new Brand() { Id = 4, Name = "VW" },
                new Brand() { Id = 5, Name = "Renault" }
            });

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car() { Id = 1, BrandId = 1, Price = 20000, Model = "BMW 116d" },
                new Car() { Id = 2, BrandId = 1, Price = 30000, Model = "BMW 510" },
                new Car() { Id = 3, BrandId = 2, Price = 10000, Model = "Citroen C1" },
                new Car() { Id = 4, BrandId = 2, Price = 15000, Model = "Citroen C3" },
                new Car() { Id = 5, BrandId = 3, Price = 20000, Model = "Audi A3" },
                new Car() { Id = 6, BrandId = 3, Price = 25000, Model = "Audi A4" },
                new Car() { Id = 7, BrandId = 4, Price = 25000, Model = "VW Golf 4" },
                new Car() { Id = 8, BrandId = 4, Price = 33000, Model = "VW Golf 5" },
                new Car() { Id = 9, BrandId = 5, Price = 26000, Model = "Renault Arkana" },
                new Car() { Id = 10, BrandId = 5, Price = 27000, Model = "Renault Clio" },
                new Car() { Id = 11, BrandId = 5, Price = 27000, Model = "Renault Clio" }
            });

            modelBuilder.Entity<Rent>().HasData(new Rent[]
            {
                new() { Id = 1, CarId = 1, Start = new DateTime(2020, 10, 15), End = new DateTime(2020, 10, 16) },
                new() { Id = 2, CarId = 2, Start = new DateTime(2019, 8, 27), End = new DateTime(2020, 10, 1) },
                new() { Id = 3, CarId = 3, Start = new DateTime(2022, 7, 8), End = new DateTime(2022, 9, 13) },
                new() { Id = 4, CarId = 4, Start = new DateTime(2018, 1, 1), End = new DateTime(2019, 1, 16) },
                new() { Id = 5, CarId = 7, Start = new DateTime(2020, 10, 14), End = new DateTime(2020, 10, 18) },
                new() { Id = 6, CarId = 8, Start = new DateTime(2019, 7, 20), End = new DateTime(2020, 1, 16) },
                new() { Id = 7, CarId = 10, Start = new DateTime(2020, 9, 15), End = new DateTime(2020, 9, 20) },
                new() { Id = 8, CarId = 9, Start = new DateTime(2021, 5, 17), End = new DateTime(2021, 8, 16) },
                new() { Id = 9, CarId = 7, Start = new DateTime(2022, 5, 29), End = new DateTime(2022, 10, 16) },
                new() { Id = 10, CarId = 1, Start = new DateTime(2018, 6, 8), End = new DateTime(2018, 12, 15) },
                new() { Id = 11, CarId = 3, Start = new DateTime(2022, 1, 15), End = new DateTime(2022, 7, 8) },
                new() { Id = 12, CarId = 9, Start = new DateTime(2019, 3, 4), End = new DateTime(2019, 7, 6) },
                new() { Id = 13, CarId = 8, Start = new DateTime(2020, 2, 2), End = new DateTime(2020, 3, 17) },
                new() { Id = 14, CarId = 5, Start = new DateTime(2021, 5, 9), End = new DateTime(2021, 10, 10) },
                new() { Id = 15, CarId = 10, Start = new DateTime(2020, 2, 16), End = new DateTime(2020, 10, 1) },

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
