﻿// <auto-generated />
using System;
using DBShop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBShop.Migrations
{
    [DbContext(typeof(DBshop))]
    [Migration("20240207090758_555")]
    partial class _555
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBShop.Models.ItemList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("itemLists");
                });

            modelBuilder.Entity("DBShop.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodeP")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOrders")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTrasit")
                        .HasColumnType("datetime2");

                    b.Property<string>("ListOrders")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Punkt")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsernameClients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("DBShop.Models.PP", b =>
                {
                    b.Property<int>("Id_pp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_pp"));

                    b.Property<int>("itemListId")
                        .HasColumnType("int");

                    b.Property<int>("ordersId")
                        .HasColumnType("int");

                    b.HasKey("Id_pp");

                    b.HasIndex("itemListId");

                    b.HasIndex("ordersId");

                    b.ToTable("pp");
                });

            modelBuilder.Entity("DBShop.Models.UserToItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemIdId")
                        .HasColumnType("int");

                    b.Property<int>("UserIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemIdId");

                    b.HasIndex("UserIdId");

                    b.ToTable("userToItems");
                });

            modelBuilder.Entity("DBShop.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGuest")
                        .HasColumnType("bit");

                    b.Property<bool>("IsManager")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DBShop.Models.PP", b =>
                {
                    b.HasOne("DBShop.Models.ItemList", "itemList")
                        .WithMany()
                        .HasForeignKey("itemListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBShop.Models.Orders", "orders")
                        .WithMany()
                        .HasForeignKey("ordersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("itemList");

                    b.Navigation("orders");
                });

            modelBuilder.Entity("DBShop.Models.UserToItem", b =>
                {
                    b.HasOne("DBShop.Models.ItemList", "ItemId")
                        .WithMany()
                        .HasForeignKey("ItemIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBShop.Models.Users", "UserId")
                        .WithMany()
                        .HasForeignKey("UserIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemId");

                    b.Navigation("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}