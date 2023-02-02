﻿// <auto-generated />
using GameKeyShop.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameKeyShop.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameKeyShop.Shared.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Category 1",
                            Url = "category1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Category 2",
                            Url = "category2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Category 3",
                            Url = "category3"
                        });
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Description Prod_ 1",
                            ImageUrl = "https://cdn.pixabay.com/photo/2012/06/19/10/32/owl-50267_960_720.jpg",
                            Name = "Prod 1.",
                            Price = 1.3m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Description Prod_ 2",
                            ImageUrl = "https://cdn.pixabay.com/photo/2022/10/29/19/21/golden-eagle-7555959_960_720.jpg",
                            Name = "Prod 2.",
                            Price = 3.5m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Description Prod_ 3",
                            ImageUrl = "https://cdn.pixabay.com/photo/2023/01/12/05/32/duck-7713310_960_720.jpg",
                            Name = "Prod 3.",
                            Price = 2.4m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Description Prod_ 4",
                            ImageUrl = "https://cdn.pixabay.com/photo/2023/01/26/18/09/zebra-7746719_960_720.jpg",
                            Name = "Prod 4.",
                            Price = 4.3m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Description Prod_ 5",
                            ImageUrl = "https://cdn.pixabay.com/photo/2016/01/02/16/53/lion-1118467_960_720.jpg",
                            Name = "Prod 5.",
                            Price = 2.66m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Description Prod_ 6",
                            ImageUrl = "https://cdn.pixabay.com/photo/2016/03/27/22/22/fox-1284512_960_720.jpg",
                            Name = "Prod 6.",
                            Price = 5.42m
                        });
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.Product", b =>
                {
                    b.HasOne("GameKeyShop.Shared.Models.Category", "Category")
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
