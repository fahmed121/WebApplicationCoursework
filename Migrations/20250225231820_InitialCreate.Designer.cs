﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;
#nullable disable

namespace WebApplicationCourseWork.Migrations
{
    [DbContext(typeof(FastFoodContext))]
    [Migration("20250225231820_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("WebAplicationCourseWork.Models.Customer", b =>
                {
                    b.Property<int>("CustID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Telphone")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("ItemID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerCustID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StaffID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerCustID");

                    b.HasIndex("StaffID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantitiy")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Staff", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StaffID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Order", b =>
                {
                    b.HasOne("WebAplicationCourseWork.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerCustID");

                    b.HasOne("WebAplicationCourseWork.Models.Staff", "Staff")
                        .WithMany("Orders")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.OrderItem", b =>
                {
                    b.HasOne("WebAplicationCourseWork.Models.Item", "MenuItem")
                        .WithMany("Orderitems")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAplicationCourseWork.Models.Order", "Order")
                        .WithMany("Orderitems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Item", b =>
                {
                    b.Navigation("Orderitems");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Order", b =>
                {
                    b.Navigation("Orderitems");
                });

            modelBuilder.Entity("WebAplicationCourseWork.Models.Staff", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
