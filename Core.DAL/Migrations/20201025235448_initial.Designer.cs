﻿// <auto-generated />
using System;
using Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.DAL.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20201025235448_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.HasOne("Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.HasOne("Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
