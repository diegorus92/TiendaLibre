﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaLibreAPI_DAL.Data;

#nullable disable

namespace TiendaLibreAPI_DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.Announcement", b =>
                {
                    b.Property<long>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AnnouncementId"));

                    b.Property<string>("AnnouncementMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AnnouncementRead")
                        .HasColumnType("bit");

                    b.Property<long>("PurchaseId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserReceiverId")
                        .HasColumnType("bigint");

                    b.HasKey("AnnouncementId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProductId"));

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductUserSellerUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("StockQty")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductUserSellerUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.ProductImage", b =>
                {
                    b.Property<long>("ProductImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProductImageId"));

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.Purchase", b =>
                {
                    b.Property<long>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PurchaseId"));

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("PurchaseState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtyToBuy")
                        .HasColumnType("int");

                    b.Property<long>("UserCostumerUserId")
                        .HasColumnType("bigint");

                    b.HasKey("PurchaseId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserCostumerUserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<string>("ProfileImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("UserBirthdate")
                        .HasColumnType("date");

                    b.Property<string>("UserCellphone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserDni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserPwHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("UserPwSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UserRegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.Announcement", b =>
                {
                    b.HasOne("TiendaLibreAPI_DAL.Models.Purchase", "Purchase")
                        .WithMany()
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.Product", b =>
                {
                    b.HasOne("TiendaLibreAPI_DAL.Models.User", "ProductUserSeller")
                        .WithMany()
                        .HasForeignKey("ProductUserSellerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductUserSeller");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.ProductImage", b =>
                {
                    b.HasOne("TiendaLibreAPI_DAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TiendaLibreAPI_DAL.Models.Purchase", b =>
                {
                    b.HasOne("TiendaLibreAPI_DAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaLibreAPI_DAL.Models.User", "UserCostumer")
                        .WithMany()
                        .HasForeignKey("UserCostumerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("UserCostumer");
                });
#pragma warning restore 612, 618
        }
    }
}
