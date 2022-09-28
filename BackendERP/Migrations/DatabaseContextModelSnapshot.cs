﻿// <auto-generated />
using System;
using BackendERP.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendERP.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendERP.Tables.Delivery", b =>
                {
                    b.Property<int>("Delivery_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Order_id")
                        .HasColumnType("int");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Delivery_id");

                    b.HasIndex("Order_id")
                        .IsUnique();

                    b.ToTable("Delivery");

                    b.HasData(
                        new
                        {
                            Delivery_id = 1,
                            Address = "Stefana Stefanovica 5",
                            City = "Novi Sad",
                            Order_id = 1,
                            Phone_number = "+381 62 839 1 075"
                        },
                        new
                        {
                            Delivery_id = 2,
                            Address = "Valentina Vodnika 17",
                            City = "Novi Sad",
                            Order_id = 2,
                            Phone_number = "0654005831"
                        });
                });

            modelBuilder.Entity("BackendERP.Tables.Order", b =>
                {
                    b.Property<int>("Order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Order_date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Order_id");

                    b.HasIndex("User_id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Order_id = 1,
                            Order_date = new DateTime(2022, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 445.0,
                            User_id = 1
                        },
                        new
                        {
                            Order_id = 2,
                            Order_date = new DateTime(2021, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 460.0,
                            User_id = 2
                        });
                });

            modelBuilder.Entity("BackendERP.Tables.OrderProduct", b =>
                {
                    b.Property<int>("Order_id")
                        .HasColumnType("int");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int>("BoughtProducts_amount")
                        .HasColumnType("int");

                    b.HasKey("Order_id", "Product_id");

                    b.HasIndex("Product_id");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("BackendERP.Tables.Product", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category_id")
                        .HasColumnType("int");

                    b.Property<string>("Discount_price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Liter")
                        .HasColumnType("float");

                    b.Property<bool>("On_action")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_quantity")
                        .HasColumnType("int");

                    b.HasKey("Product_id");

                    b.HasIndex("Category_id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Product_id = 1,
                            Category_id = 1,
                            Image_url = "",
                            Liter = 0.25,
                            On_action = true,
                            Price = 175.0,
                            Product_name = "Akva viva",
                            Product_quantity = 50
                        },
                        new
                        {
                            Product_id = 2,
                            Category_id = 2,
                            Image_url = "assets/images/Jelen.jfif",
                            Liter = 0.25,
                            On_action = false,
                            Price = 200.0,
                            Product_name = "Jelen",
                            Product_quantity = 100
                        });
                });

            modelBuilder.Entity("BackendERP.Tables.Product_category", b =>
                {
                    b.Property<int>("Category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Category_id");

                    b.ToTable("Product_categories");

                    b.HasData(
                        new
                        {
                            Category_id = 1,
                            Category_name = "Voda"
                        },
                        new
                        {
                            Category_id = 2,
                            Category_name = "Pivo"
                        });
                });

            modelBuilder.Entity("BackendERP.Tables.Rating", b =>
                {
                    b.Property<int>("Rating_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Rating_id");

                    b.HasIndex("Product_id");

                    b.HasIndex("User_id");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Rating_id = 1,
                            Comment = "odlican proizvod!",
                            Grade = 9,
                            Product_id = 2,
                            User_id = 1
                        });
                });

            modelBuilder.Entity("BackendERP.Tables.Role", b =>
                {
                    b.Property<int>("Role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Role_id = 1,
                            Role_name = "Administrator"
                        },
                        new
                        {
                            Role_id = 2,
                            Role_name = "Kupac"
                        });
                });

            modelBuilder.Entity("BackendERP.Tables.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Purchase_count")
                        .HasColumnType("int");

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("User_id");

                    b.HasIndex("Role_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            User_id = 1,
                            Email = "milosmilinovic9@gmail.com",
                            LastName = "Milinovic",
                            Name = "Milos",
                            Password = "milos123",
                            Purchase_count = 0,
                            Role_id = 1,
                            User_name = "Mili99"
                        },
                        new
                        {
                            User_id = 2,
                            Email = "nmilunovic@gmail.com",
                            LastName = "Milunovic",
                            Name = "Nemanja",
                            Password = "milun123",
                            Purchase_count = 0,
                            Role_id = 2,
                            User_name = "Milun"
                        });
                });

            modelBuilder.Entity("BackendERP.Tables.Delivery", b =>
                {
                    b.HasOne("BackendERP.Tables.Order", "Order")
                        .WithOne("Delivery")
                        .HasForeignKey("BackendERP.Tables.Delivery", "Order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BackendERP.Tables.Order", b =>
                {
                    b.HasOne("BackendERP.Tables.User", "User")
                        .WithMany()
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendERP.Tables.OrderProduct", b =>
                {
                    b.HasOne("BackendERP.Tables.Order", "Order")
                        .WithMany("Order_products")
                        .HasForeignKey("Order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendERP.Tables.Product", "Product")
                        .WithMany("Order_products")
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BackendERP.Tables.Product", b =>
                {
                    b.HasOne("BackendERP.Tables.Product_category", "Product_category")
                        .WithMany("Products")
                        .HasForeignKey("Category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product_category");
                });

            modelBuilder.Entity("BackendERP.Tables.Rating", b =>
                {
                    b.HasOne("BackendERP.Tables.Product", "Product")
                        .WithMany("Ratings")
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendERP.Tables.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendERP.Tables.User", b =>
                {
                    b.HasOne("BackendERP.Tables.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BackendERP.Tables.Order", b =>
                {
                    b.Navigation("Delivery");

                    b.Navigation("Order_products");
                });

            modelBuilder.Entity("BackendERP.Tables.Product", b =>
                {
                    b.Navigation("Order_products");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("BackendERP.Tables.Product_category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BackendERP.Tables.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BackendERP.Tables.User", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
