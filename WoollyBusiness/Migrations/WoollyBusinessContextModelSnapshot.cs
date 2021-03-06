﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WoollyBusiness.Models;

namespace WoollyBusiness.Migrations
{
    [DbContext(typeof(WoollyBusinessContext))]
    partial class WoollyBusinessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WoollyBusiness.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime");

                    b.Property<int>("SupplierId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("WoollyBusiness.Models.PurchaseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemDescription")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("ItemId");

                    b.Property<int>("PurchaseId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseDetail");
                });

            modelBuilder.Entity("WoollyBusiness.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime");

                    b.Property<int>("SaleSourceId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SaleSourceId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("WoollyBusiness.Models.SaleDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemDescription")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("ItemId");

                    b.Property<int>("SaleId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("SaleDetail");
                });

            modelBuilder.Entity("WoollyBusiness.Models.SaleSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("SaleSource");
                });

            modelBuilder.Entity("WoollyBusiness.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("WoollyBusiness.Models.Purchase", b =>
                {
                    b.HasOne("WoollyBusiness.Models.Supplier", "Supplier")
                        .WithMany("Purchase")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_Purchase_Supplier");
                });

            modelBuilder.Entity("WoollyBusiness.Models.PurchaseDetail", b =>
                {
                    b.HasOne("WoollyBusiness.Models.Purchase", "Purchase")
                        .WithMany("PurchaseDetail")
                        .HasForeignKey("PurchaseId")
                        .HasConstraintName("FK_PurchaseDetail_Purchase");
                });

            modelBuilder.Entity("WoollyBusiness.Models.Sale", b =>
                {
                    b.HasOne("WoollyBusiness.Models.SaleSource", "SaleSource")
                        .WithMany("Sale")
                        .HasForeignKey("SaleSourceId")
                        .HasConstraintName("FK_Sale_SaleSource");
                });

            modelBuilder.Entity("WoollyBusiness.Models.SaleDetail", b =>
                {
                    b.HasOne("WoollyBusiness.Models.Sale", "Item")
                        .WithMany("SaleDetail")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_SaleDetail_Sale");
                });
#pragma warning restore 612, 618
        }
    }
}
