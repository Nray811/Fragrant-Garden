﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetFragrant_Test.Data;

namespace PetFragrant_Test.Migrations
{
    [DbContext(typeof(PetContext))]
    [Migration("20230611095801_UpdateDB4")]
    partial class UpdateDB4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("petsFragrant.Models.Categories", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherCategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryID");

                    b.HasIndex("FatherCategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("petsFragrant.Models.Coupon", b =>
                {
                    b.Property<string>("CouponID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CouponID");

                    b.HasIndex("OrderID");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("petsFragrant.Models.Customer", b =>
                {
                    b.Property<string>("CustomerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("petsFragrant.Models.Order", b =>
                {
                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Arriiveddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Delivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Orderdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Shipdate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("petsFragrant.Models.OrderDetail", b =>
                {
                    b.Property<string>("ProdcutId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("QtDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdcutId", "OrderID", "Amount", "QtDiscount");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("petsFragrant.Models.Product", b =>
                {
                    b.Property<string>("ProdcutId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoriesID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdcutId");

                    b.HasIndex("CategoriesID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("petsFragrant.Models.ProductSpec", b =>
                {
                    b.Property<string>("ProdcutId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SpecID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProdcutId", "SpecID");

                    b.HasIndex("SpecID");

                    b.ToTable("ProductSpecs");
                });

            modelBuilder.Entity("petsFragrant.Models.Spec", b =>
                {
                    b.Property<string>("SpecID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SpecName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecID");

                    b.ToTable("Specs");
                });

            modelBuilder.Entity("petsFragrant.Models.Categories", b =>
                {
                    b.HasOne("petsFragrant.Models.Categories", "FatherCategory")
                        .WithMany("Categoriess")
                        .HasForeignKey("FatherCategoryID");

                    b.Navigation("FatherCategory");
                });

            modelBuilder.Entity("petsFragrant.Models.Coupon", b =>
                {
                    b.HasOne("petsFragrant.Models.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("petsFragrant.Models.Order", b =>
                {
                    b.HasOne("petsFragrant.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("petsFragrant.Models.OrderDetail", b =>
                {
                    b.HasOne("petsFragrant.Models.Order", "Order")
                        .WithMany("Ordertails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petsFragrant.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProdcutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("petsFragrant.Models.Product", b =>
                {
                    b.HasOne("petsFragrant.Models.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoriesID");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("petsFragrant.Models.ProductSpec", b =>
                {
                    b.HasOne("petsFragrant.Models.Product", "Product")
                        .WithMany("ProductSpecs")
                        .HasForeignKey("ProdcutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petsFragrant.Models.Spec", "Spec")
                        .WithMany("ProductSpec")
                        .HasForeignKey("SpecID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Spec");
                });

            modelBuilder.Entity("petsFragrant.Models.Categories", b =>
                {
                    b.Navigation("Categoriess");
                });

            modelBuilder.Entity("petsFragrant.Models.Order", b =>
                {
                    b.Navigation("Ordertails");
                });

            modelBuilder.Entity("petsFragrant.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ProductSpecs");
                });

            modelBuilder.Entity("petsFragrant.Models.Spec", b =>
                {
                    b.Navigation("ProductSpec");
                });
#pragma warning restore 612, 618
        }
    }
}
