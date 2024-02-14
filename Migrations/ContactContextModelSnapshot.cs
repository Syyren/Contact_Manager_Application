﻿// <auto-generated />
using Contact_Manager_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contact_Manager_Application.Migrations
{
    [DbContext(typeof(ContactContext))]
    partial class ContactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Contact_Manager_Application.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "F",
                            Name = "Family"
                        },
                        new
                        {
                            CategoryId = "Fr",
                            Name = "Friend"
                        },
                        new
                        {
                            CategoryId = "U",
                            Name = "Unknown"
                        },
                        new
                        {
                            CategoryId = "W",
                            Name = "Work"
                        });
                });

            modelBuilder.Entity("Contact_Manager_Application.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = "Fr",
                            Email = "Ryan@McGrandle.com",
                            FirstName = "Ryan",
                            LastName = "McGrandle",
                            Phone = "888-888-8888"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = "F",
                            Email = "Kaden@deFrece.com",
                            FirstName = "Kaden",
                            LastName = "de Frece",
                            Phone = "888-888-8889"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = "W",
                            Email = "Dane@Fillingham.com",
                            FirstName = "Dane",
                            LastName = "Fillingham",
                            Phone = "888-888-8887"
                        });
                });

            modelBuilder.Entity("Contact_Manager_Application.Models.Contact", b =>
                {
                    b.HasOne("Contact_Manager_Application.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
