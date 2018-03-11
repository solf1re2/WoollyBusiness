using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WoollyBusiness.Models
{
    public partial class WoollyBusinessContext : DbContext
    {
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleDetail> SaleDetail { get; set; }
        public virtual DbSet<SaleSource> SaleSource { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        public WoollyBusinessContext(DbContextOptions<WoollyBusinessContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.DateOfTransaction).HasColumnType("datetime");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Supplier");
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseDetail)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDetail_Purchase");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.DateOfTransaction).HasColumnType("datetime");

                entity.HasOne(d => d.SaleSource)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.SaleSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_SaleSource");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SaleDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_SaleDetail_Sale");
            });

            modelBuilder.Entity<SaleSource>(entity =>
            {
                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
