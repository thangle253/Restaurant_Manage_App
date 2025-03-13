using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Orderly.Model
{
    public partial class QLNhaHangDB : DbContext
    {
        public QLNhaHangDB()
            : base("name=QLNhaHangDB")
        {
        }

        public virtual DbSet<BanAn> BanAns { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<LoaiMon> LoaiMons { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<ThongKe> ThongKes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanAn>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.BanAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BanAn>()
                .HasMany(e => e.ThongKes)
                .WithRequired(e => e.BanAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiMon>()
                .HasMany(e => e.MonAns)
                .WithRequired(e => e.LoaiMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);
        }
    }
}
