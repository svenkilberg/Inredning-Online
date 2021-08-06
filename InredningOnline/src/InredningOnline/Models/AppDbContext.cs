using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InredningOnline.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // The code below is for entering users, projects and products in the in memory database
            // on startup.
            
            // seed user.

            //A hasher to hash the password before seeding the user to the db.
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {                
                UserName = "ingrid@ballong.se",
                NormalizedUserName = "INGRID@BALLONG.SE",
                Email = "ingrid@ballong.se",
                NormalizedEmail = "INGRID@BALLONG.SE",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PasswordHash = hasher.HashPassword(null, "ingrid123"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                UserName = "bengt@ballong.se",
                NormalizedUserName = "BENGT@BALLONG.SE",
                Email = "bengt@ballong.se",
                NormalizedEmail = "BENGT@BALLONG.SE",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PasswordHash = hasher.HashPassword(null, "bengt123"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                UserName = "sigrid@ballong.se",
                NormalizedUserName = "SIGRID@BALLONG.SE",
                Email = "sigrid@ballong.se",
                NormalizedEmail = "SIGRID@BALLONG.SE",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PasswordHash = hasher.HashPassword(null, "sigrid123"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            // seed projecs
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 1, ProjectName = "Restaurangen", ProjectOwner = "bengt@ballong.se" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 2, ProjectName = "Konferensrummet", ProjectOwner = "bengt@ballong.se" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 3, ProjectName = "Dagisavdelningen", ProjectOwner = "sigrid@ballong.se" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 4, ProjectName = "Lekplatsen", ProjectOwner = "sigrid@ballong.se" });

            // seed products
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Matbord",
                ProductNuberOfUnits = 1,
                ProductUnit = "st",
                ProductUnitPrice = 600,
                ProductSupplierName = "IKEA",
                ProductInfoLink = "http://www.ikea.se",
                ProjectId = 1                
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Stolar",
                ProductNuberOfUnits = 4,
                ProductUnit = "st",
                ProductUnitPrice = 200,
                ProductSupplierName = "IKEA",
                ProductInfoLink = "http://www.ikea.se",
                ProjectId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Duk",
                ProductNuberOfUnits = 1,
                ProductUnit = "st",
                ProductUnitPrice = 60,
                ProductSupplierName = "Tygboden AB",
                ProductInfoLink = "",
                ProjectId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                ProductName = "Konferensbord",
                ProductNuberOfUnits = 1,
                ProductUnit = "st",
                ProductUnitPrice = 3000,
                ProductSupplierName = "IKEA",
                ProductInfoLink = "http://www.ikea.se",
                ProjectId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                ProductName = "Konferensstol",
                ProductNuberOfUnits = 6,
                ProductUnit = "st",
                ProductUnitPrice = 800,
                ProductSupplierName = "IKEA",
                ProductInfoLink = "http://www.ikea.se",
                ProjectId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                ProductName = "Whiteboardtavla",
                ProductNuberOfUnits = 1,
                ProductUnit = "st",
                ProductUnitPrice = 1200,
                ProductSupplierName = "IKEA",
                ProductInfoLink = "http://www.ikea.se",
                ProjectId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                ProductName = "Whiteboardpenna",
                ProductNuberOfUnits = 5,
                ProductUnit = "st",
                ProductUnitPrice = 20,
                ProductSupplierName = "IKEA",
                ProductInfoLink = "http://www.ikea.se",
                ProjectId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                ProductName = "Kuddar",
                ProductNuberOfUnits = 10,
                ProductUnit = "st",
                ProductUnitPrice = 80,
                ProductSupplierName = "IKEA",
                ProductInfoLink = "http://www.ikea.se",
                ProjectId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                ProductName = "Leksakskök",
                ProductNuberOfUnits = 1,
                ProductUnit = "st",
                ProductUnitPrice = 1500,
                ProductSupplierName = "Leksakhörnan",
                ProductInfoLink = "",
                ProjectId = 3
            });

        }
    }
}
