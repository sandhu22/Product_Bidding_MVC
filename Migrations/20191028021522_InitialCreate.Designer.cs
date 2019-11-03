﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product_Bidding_MVC.Models;

namespace Product_Bidding_MVC.Migrations
{
    [DbContext(typeof(Product_Bidding_MVCContext))]
    [Migration("20191028021522_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Product_Bidding.BusinessLayer.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BidPrice");

                    b.Property<int>("BuyerId");

                    b.Property<int>("ProductId");

                    b.Property<int>("SellerId");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellerId");

                    b.ToTable("Bid");
                });

            modelBuilder.Entity("Product_Bidding.BusinessLayer.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuyerAccountNumber")
                        .IsRequired();

                    b.Property<string>("BuyerName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Buyer");
                });

            modelBuilder.Entity("Product_Bidding.BusinessLayer.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSold");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<decimal>("StartingPrice");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Product_Bidding.BusinessLayer.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber");

                    b.Property<string>("SellerName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("Product_Bidding.BusinessLayer.Bid", b =>
                {
                    b.HasOne("Product_Bidding.BusinessLayer.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Product_Bidding.BusinessLayer.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Product_Bidding.BusinessLayer.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
