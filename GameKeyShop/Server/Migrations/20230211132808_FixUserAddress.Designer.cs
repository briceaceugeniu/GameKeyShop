﻿// <auto-generated />
using System;
using GameKeyShop.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameKeyShop.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230211132808_FixUserAddress")]
    partial class FixUserAddress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameKeyShop.Shared.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId", "PlatformTypeId");

                    b.ToTable("CartItems");
                });

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
                            Name = "Action",
                            Url = "action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure",
                            Url = "adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "RPG",
                            Url = "rpg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fantasy",
                            Url = "fantasy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Open World",
                            Url = "open-world"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sports",
                            Url = "sports"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Horror",
                            Url = "horror"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Strategy",
                            Url = "strategy"
                        });
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "ProductId", "PlatformTypeId");

                    b.HasIndex("PlatformTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.PlatformType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlatformTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PSN"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Xbox"
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

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 8,
                            Description = "One of the most celebrated real-time strategy franchises is getting a long-awaited new installment! Become the key player in events that shaped human history with Relic Entertainment, World’s Edge and Xbox Game Studios’ latest release - Age of Empires IV. ",
                            Featured = false,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/s/s/ss_20d475d96c3a3dcb720103ce79e22d41df1aa8e0.1920x1080-min_26_.jpg",
                            Name = "Age of Empires 4"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 5,
                            Description = "Hogwarts Legacy is an open-world action RPG set in the world first introduced in the Harry Potter books. Embark on a journey through familiar and new locations as you explore and discover magical beasts, customize your character and craft potions, master spell casting, upgrade talents and become the wizard you want to be.",
                            Featured = true,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/c/u/cupheaddeliciouslast-1640043161876_3__2.jpg",
                            Name = "HOGWARTS LEGACY"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 6,
                            Description = "EA SPORTS™ FIFA 23 brings The World’s Game to the pitch, with HyperMotion2 Technology that delivers even more game-play realism, both the men’s and women’s FIFA World Cup™ coming to the game later in the the season, the addition of women’s club teams, cross-play features, and more. Experience unrivaled authenticity with over 19,000 players, 700+ teams, 100 stadiums, and over 30 leagues in FIFA 23.",
                            Featured = false,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/a/a/aaaa_5.jpg",
                            Name = "FIFA 23"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between. In the Lands Between ruled by Queen Marika the Eternal, the Elden Ring, the source of the Erdtree, has been shattered.",
                            Featured = true,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/5/d/5de6658946177c5f23698932_24_.jpg",
                            Name = "ELDEN RING"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 8,
                            Description = "The Settlers combines a fresh take on the popular game-play mechanics of the series with a new spin. It offers a deep infrastructure and economy game-play, used to create and employ armies, to ultimately defeat opponents.",
                            Featured = false,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/s/a/sadasd.jpg",
                            Name = "THE SETTLERS: NEW ALLIES"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "In Assassin's Creed Unity you will become the ultimate assassin and change the course of history forever.Experience the French Revolution first hand. You'll need to hone your skills and equipment to survive the chaos!",
                            Featured = false,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/h/e/hero_11_.jpg",
                            Name = "ASSASSIN'S CREED UNITY"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            Description = "Explore distant lands, fight bigger and more awe-inspiring machines, and encounter astonishing new tribes as you return to the far-future, post-apocalyptic world of Horizon.",
                            Featured = true,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/h/e/header_10_15__1.jpg",
                            Name = "HORIZON FORBIDDEN WEST"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 7,
                            Description = "Experience the emotional storytelling and unforgettable characters in The Last of Us, winner of over 200 Game of the Year awards, now rebuilt from the ground up for the PlayStation®5 console.",
                            Featured = false,
                            ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/r/o/roadwarden_5_.jpg",
                            Name = "HE LAST OF US PART I"
                        });
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId", "PlatformTypeId");

                    b.HasIndex("PlatformTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            PlatformTypeId = 1,
                            OriginalPrice = 18.99m,
                            Price = 14.99m
                        },
                        new
                        {
                            ProductId = 2,
                            PlatformTypeId = 4,
                            OriginalPrice = 46.99m,
                            Price = 44.29m
                        },
                        new
                        {
                            ProductId = 3,
                            PlatformTypeId = 2,
                            OriginalPrice = 12.99m,
                            Price = 11.99m
                        },
                        new
                        {
                            ProductId = 4,
                            PlatformTypeId = 1,
                            OriginalPrice = 33.99m,
                            Price = 25.99m
                        },
                        new
                        {
                            ProductId = 5,
                            PlatformTypeId = 3,
                            OriginalPrice = 44.99m,
                            Price = 34.99m
                        },
                        new
                        {
                            ProductId = 6,
                            PlatformTypeId = 4,
                            OriginalPrice = 23.99m,
                            Price = 21.99m
                        },
                        new
                        {
                            ProductId = 7,
                            PlatformTypeId = 4,
                            OriginalPrice = 56.99m,
                            Price = 33.99m
                        },
                        new
                        {
                            ProductId = 7,
                            PlatformTypeId = 1,
                            OriginalPrice = 32.99m,
                            Price = 30.99m
                        },
                        new
                        {
                            ProductId = 8,
                            PlatformTypeId = 2,
                            OriginalPrice = 66.99m,
                            Price = 65.99m
                        });
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.Address", b =>
                {
                    b.HasOne("GameKeyShop.Shared.Models.User", null)
                        .WithOne("Address")
                        .HasForeignKey("GameKeyShop.Shared.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.OrderItem", b =>
                {
                    b.HasOne("GameKeyShop.Shared.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameKeyShop.Shared.Models.PlatformType", "PlatformType")
                        .WithMany()
                        .HasForeignKey("PlatformTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameKeyShop.Shared.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PlatformType");

                    b.Navigation("Product");
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

            modelBuilder.Entity("GameKeyShop.Shared.Models.ProductVariant", b =>
                {
                    b.HasOne("GameKeyShop.Shared.Models.PlatformType", "PlatformType")
                        .WithMany()
                        .HasForeignKey("PlatformTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameKeyShop.Shared.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlatformType");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("GameKeyShop.Shared.Models.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
