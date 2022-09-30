using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Product_category> Product_categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new
            {
                User_id = 1,
                Name = "Milos",
                LastName = "Milinovic",
                Email = "milosmilinovic9@gmail.com",
                User_name = "Mili99",
                Password = "milos123",
                Role_id = 1,
                Purchase_count=0
            }
                );
            modelBuilder.Entity<User>().HasData(new
            {
                User_id = 2,
                Name = "Nemanja",
                LastName = "Milunovic",
                Email = "nmilunovic@gmail.com",
                User_name = "Milun",
                Password = "milun123",
                Role_id = 2,
                Purchase_count=0
            }
                );

            modelBuilder.Entity<Product_category>().HasData(new
            {
                Category_id = 1,
                Category_name = "Voda"

            });
            modelBuilder.Entity<Product_category>().HasData(new
            {
                Category_id = 2,
                Category_name = "Pivo"
            }
               );
           
            modelBuilder.Entity<Role>().HasData(new
            {
                Role_id = 1,
                Role_name = "Administrator"
            });
            modelBuilder.Entity<Role>().HasData(new
            {
                Role_id = 2,
                Role_name = "Kupac"
            }
                );
            modelBuilder.Entity<Delivery>().HasData(new
            {
                Delivery_id = 1,
                Address = "Stefana Stefanovica 5",
                City = "Novi Sad",
                Phone_number = "+381 62 839 1 075",
                Order_id = 1
            }
                );
            modelBuilder.Entity<Delivery>().HasData(new
            {
                Delivery_id = 2,
                Address = "Valentina Vodnika 17",
                City = "Novi Sad",
                Phone_number = "0654005831",
                Order_id = 2
            }
               );
            modelBuilder.Entity<Product>().HasData(new
            {
                Product_id = 1,
                Product_name = "Akva viva",
                Liter = 0.25,
                Price = 175.00,
                Product_quantity=50,
                On_action = true,
                Discount = "20%",
                Discout_price = "114,15",
                Image_url="",
                Category_id = 1,
            }
                );
            modelBuilder.Entity<Product>().HasData(new
            {
                Product_id = 2,
                Product_name = "Jelen",
                Liter = 0.25,
                Price = 200.00,
                Product_quantity=100,
                On_action = false,
                Image_url="assets/images/Jelen.jfif",
                Category_id = 2
            }
                );
            modelBuilder.Entity<Order>().HasData(new
            {
                Order_id = 1,
                Total = 445.00,
                Order_date = DateTime.Parse("2022-11-4"),
                User_id = 1
            }
                );
            modelBuilder.Entity<Order>().HasData(new
            {
                Order_id = 2,
                Total = 460.00,
                Order_date = DateTime.Parse("2021-12-4"),
                User_id = 2
            }
               );
        modelBuilder.Entity<Rating>().HasData(new
           {
          Rating_id = 1,
          Grade = 9,
          Comment = "odlican proizvod!",
          Product_id = 2,
          User_id = 1
              }
             );
      

    }

    }
}
