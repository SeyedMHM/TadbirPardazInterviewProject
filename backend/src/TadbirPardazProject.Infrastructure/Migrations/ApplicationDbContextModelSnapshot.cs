﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TadbirPardazProject.Infrastructure.Data;

#nullable disable

namespace TadbirPardazProject.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TadbirPardazProject.Domain.Invoices.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerName = "سید محمد حسین موسوی",
                            Description = "لطفا صبح تحویل داده شود",
                            IssuedDate = new DateTime(2022, 10, 18, 17, 21, 5, 894, DateTimeKind.Local).AddTicks(3614)
                        });
                });

            modelBuilder.Entity("TadbirPardazProject.Domain.Invoices.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("DiscountPercent")
                        .HasColumnType("tinyint");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<byte>("Quantity")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiscountPercent = (byte)10,
                            InvoiceId = 1,
                            ProductId = 1,
                            Quantity = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            DiscountPercent = (byte)0,
                            InvoiceId = 1,
                            ProductId = 2,
                            Quantity = (byte)5
                        },
                        new
                        {
                            Id = 3,
                            DiscountPercent = (byte)5,
                            InvoiceId = 1,
                            ProductId = 3,
                            Quantity = (byte)2
                        });
                });

            modelBuilder.Entity("TadbirPardazProject.Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Price = 15000000m,
                            Title = "جارو برقی"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Price = 100000m,
                            Title = "پفک نمکی"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Price = 3000000m,
                            Title = "کیبورد"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Price = 200000m,
                            Title = "شیر پرچرب"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Price = 85000000m,
                            Title = "گوشی شائومی redmi note 7"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Price = 50000000m,
                            Title = "هارد اکسترنال 1 گیگ Samsung"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Price = 4000000m,
                            Title = "هندزفری بلوتوثی"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Price = 1200000m,
                            Title = "برنچ هاشمی"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Price = 300000m,
                            Title = "جوراب"
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Price = 5000000m,
                            Title = "شلوار لی"
                        },
                        new
                        {
                            Id = 11,
                            IsDeleted = false,
                            Price = 3000000m,
                            Title = "ماگ حرارتی"
                        });
                });

            modelBuilder.Entity("TadbirPardazProject.Domain.Invoices.InvoiceDetail", b =>
                {
                    b.HasOne("TadbirPardazProject.Domain.Invoices.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TadbirPardazProject.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TadbirPardazProject.Domain.Invoices.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}