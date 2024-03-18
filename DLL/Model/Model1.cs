using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DLL.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model19")
        {
        }

        public virtual DbSet<ChiTietDichVu> ChiTietDichVus { get; set; }
        public virtual DbSet<ChiTietGhe> ChiTietGhes { get; set; }
        public virtual DbSet<ChiTIetTheLoaiPhinm> ChiTIetTheLoaiPhinms { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<Ghe> Ghes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichChieuPhim> LichChieuPhims { get; set; }
        public virtual DbSet<LoaiGhe> LoaiGhes { get; set; }
        public virtual DbSet<loaiPhong> loaiPhongs { get; set; }
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }
        public virtual DbSet<LoaiTrangThaiGhe> LoaiTrangThaiGhes { get; set; }
        public virtual DbSet<PhongChieu> PhongChieux { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TheLoaiPhim> TheLoaiPhims { get; set; }
        public virtual DbSet<ThongtinPhim> ThongtinPhims { get; set; }
        public virtual DbSet<ThongTinVe> ThongTinVes { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietDichVus)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ghe>()
                .HasMany(e => e.ChiTietGhes)
                .WithRequired(e => e.Ghe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ghe>()
                .HasMany(e => e.ThongTinVes)
                .WithRequired(e => e.Ghe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.TaiKhoans)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LichChieuPhim>()
                .HasMany(e => e.ChiTietGhes)
                .WithRequired(e => e.LichChieuPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LichChieuPhim>()
                .HasMany(e => e.ThongTinVes)
                .WithRequired(e => e.LichChieuPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTrangThaiGhe>()
                .HasMany(e => e.ChiTietGhes)
                .WithRequired(e => e.LoaiTrangThaiGhe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongChieu>()
                .HasMany(e => e.LichChieuPhims)
                .WithRequired(e => e.PhongChieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoaiPhim>()
                .HasMany(e => e.ChiTIetTheLoaiPhinms)
                .WithRequired(e => e.TheLoaiPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongtinPhim>()
                .HasMany(e => e.ChiTIetTheLoaiPhinms)
                .WithRequired(e => e.ThongtinPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongtinPhim>()
                .HasMany(e => e.LichChieuPhims)
                .WithRequired(e => e.ThongtinPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ve>()
                .HasMany(e => e.ChiTietDichVus)
                .WithRequired(e => e.Ve)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ve>()
                .HasMany(e => e.ThongTinVes)
                .WithRequired(e => e.Ve)
                .WillCascadeOnDelete(false);
        }
    }
}
