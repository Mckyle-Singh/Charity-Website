﻿// <auto-generated />
using System;
using LoginSec.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoginSec.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LoginSec.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LoginSec.Models.Disaster", b =>
                {
                    b.Property<int>("DisasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisasterId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("DisasterLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DisasterType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequiredAids")
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DisasterId");

                    b.ToTable("Disasters");
                });

            modelBuilder.Entity("LoginSec.Models.Good_Allocation", b =>
                {
                    b.Property<int>("GoodsAllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoodsAllocationId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisasterId")
                        .HasColumnType("int");

                    b.Property<int?>("GoodsDonationGoodsId")
                        .HasColumnType("int");

                    b.Property<int>("GoodsId")
                        .HasColumnType("int");

                    b.Property<int>("NumItems")
                        .HasColumnType("int");

                    b.HasKey("GoodsAllocationId");

                    b.HasIndex("DisasterId");

                    b.HasIndex("GoodsDonationGoodsId");

                    b.ToTable("Good_Allocations");
                });

            modelBuilder.Entity("LoginSec.Models.GoodsDonation", b =>
                {
                    b.Property<int>("GoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoodsId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("NumItems")
                        .HasColumnType("int");

                    b.HasKey("GoodsId");

                    b.HasIndex("CategoryId");

                    b.ToTable("GoodsDonations");
                });

            modelBuilder.Entity("LoginSec.Models.Monetary_Allocation", b =>
                {
                    b.Property<int>("MonetaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonetaryId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("DisasterId")
                        .HasColumnType("int");

                    b.HasKey("MonetaryId");

                    b.HasIndex("DisasterId");

                    b.ToTable("Monetary_Allocations");
                });

            modelBuilder.Entity("LoginSec.Models.MonetaryDonation", b =>
                {
                    b.Property<int>("MonetaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonetaryId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("MonetaryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MonetaryDonations");
                });

            modelBuilder.Entity("LoginSec.Models.PurchaseGoods", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisasterId")
                        .HasColumnType("int");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("PurchaseAmount")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("PurchaseId");

                    b.HasIndex("DisasterId");

                    b.ToTable("PurchaseGoods");
                });

            modelBuilder.Entity("LoginSec.Models.Good_Allocation", b =>
                {
                    b.HasOne("LoginSec.Models.Disaster", "Disaster")
                        .WithMany()
                        .HasForeignKey("DisasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginSec.Models.GoodsDonation", "GoodsDonation")
                        .WithMany()
                        .HasForeignKey("GoodsDonationGoodsId");

                    b.Navigation("Disaster");

                    b.Navigation("GoodsDonation");
                });

            modelBuilder.Entity("LoginSec.Models.GoodsDonation", b =>
                {
                    b.HasOne("LoginSec.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LoginSec.Models.Monetary_Allocation", b =>
                {
                    b.HasOne("LoginSec.Models.Disaster", "Disaster")
                        .WithMany()
                        .HasForeignKey("DisasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disaster");
                });

            modelBuilder.Entity("LoginSec.Models.MonetaryDonation", b =>
                {
                    b.HasOne("LoginSec.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LoginSec.Models.PurchaseGoods", b =>
                {
                    b.HasOne("LoginSec.Models.Disaster", "Disaster")
                        .WithMany()
                        .HasForeignKey("DisasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disaster");
                });
#pragma warning restore 612, 618
        }
    }
}
