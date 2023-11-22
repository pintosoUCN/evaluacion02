﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231122173532_evaluacion2")]
    partial class evaluacion2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.U9nqgn1NvjMPLOQjDMjs2gHaG6&pid=Api&P=0&h=180",
                            Name = "Papas fritas",
                            Price = 10990
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.oGTTlgElx79g810lUhKESQHaE7&pid=Api&P=0&h=180",
                            Name = "Ensalada",
                            Price = 19990
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.0sKeEeaj45a1ppQqQh_kxQHaHa&pid=Api&P=0&h=180",
                            Name = "Mani salado",
                            Price = 29990
                        },
                        new
                        {
                            Id = 4,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            ImageUrl = "https://picsum.photos/200/300",
                            Name = "Product 4",
                            Price = 39990
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
