﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApplication.Models;

namespace TestApplication.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20200710171641_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("TestApplication.Models.Accounting", b =>
                {
                    b.Property<int>("AccountingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sum")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountingId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Accountings");
                });

            modelBuilder.Entity("TestApplication.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TestApplication.Models.Accounting", b =>
                {
                    b.HasOne("TestApplication.Models.Category", "Category")
                        .WithMany("Accountings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
