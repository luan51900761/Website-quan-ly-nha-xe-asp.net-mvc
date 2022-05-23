using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF.EF
{
    public partial class DBContextSV : DbContext
    {
        public DBContextSV()
            : base("name=DBContextSV")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<chuyenxe> chuyenxes { get; set; }
        public virtual DbSet<ghe> ghes { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<kigui> kiguis { get; set; }
        public virtual DbSet<loainv> loainvs { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<tuyenxe> tuyenxes { get; set; }
        public virtual DbSet<vexe> vexes { get; set; }
        public virtual DbSet<xe> xes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.role)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.nhanviens)
                .WithOptional(e => e.account)
                .HasForeignKey(e => e.username);

            modelBuilder.Entity<account>()
                .HasMany(e => e.nhanviens1)
                .WithOptional(e => e.account1)
                .HasForeignKey(e => e.username);

            modelBuilder.Entity<chuyenxe>()
                .Property(e => e.machuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<chuyenxe>()
                .Property(e => e.tenchuyen)
                .IsFixedLength();

            modelBuilder.Entity<chuyenxe>()
                .Property(e => e.matuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<chuyenxe>()
                .Property(e => e.manv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<chuyenxe>()
                .Property(e => e.maxe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<chuyenxe>()
                .Property(e => e.matx)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ghe>()
                .Property(e => e.tenghe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.machuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.sdt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<kigui>()
                .Property(e => e.sdtnguoigui)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<kigui>()
                .Property(e => e.sdtnguoinhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<kigui>()
                .Property(e => e.machuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<kigui>()
                .Property(e => e.nvsuly)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<loainv>()
                .Property(e => e.maloainv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<loainv>()
                .HasMany(e => e.nhanviens)
                .WithOptional(e => e.loainv)
                .HasForeignKey(e => e.maloainv);

            modelBuilder.Entity<loainv>()
                .HasMany(e => e.nhanviens1)
                .WithOptional(e => e.loainv1)
                .HasForeignKey(e => e.maloainv);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.manv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.tennv)
                .IsFixedLength();

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.gioitinh)
                .IsFixedLength();

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.diachi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.cmnd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.dienthoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.maloainv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.hinhanh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.chuyenxes)
                .WithOptional(e => e.nhanvien)
                .HasForeignKey(e => e.manv);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.chuyenxes1)
                .WithOptional(e => e.nhanvien1)
                .HasForeignKey(e => e.matx);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.kiguis)
                .WithOptional(e => e.nhanvien)
                .HasForeignKey(e => e.nvsuly);

            modelBuilder.Entity<tuyenxe>()
                .Property(e => e.matuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tuyenxe>()
                .Property(e => e.diemdi)
                .IsFixedLength();

            modelBuilder.Entity<tuyenxe>()
                .Property(e => e.diemden)
                .IsFixedLength();

            modelBuilder.Entity<tuyenxe>()
                .Property(e => e.image)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tuyenxe>()
                .HasMany(e => e.chuyenxes)
                .WithOptional(e => e.tuyenxe)
                .HasForeignKey(e => e.matuyen);

            modelBuilder.Entity<tuyenxe>()
                .HasMany(e => e.chuyenxes1)
                .WithOptional(e => e.tuyenxe1)
                .HasForeignKey(e => e.matuyen);

            modelBuilder.Entity<vexe>()
                .Property(e => e.tenghe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xe>()
                .Property(e => e.maxe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xe>()
                .Property(e => e.tenxe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xe>()
                .Property(e => e.bienso)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
