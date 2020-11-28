namespace QuanLySieuthimini1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConnectDB : DbContext
    {
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Nhomhang> Nhomhangs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Hanghoa> Hanghoas { get; set; }
        public virtual DbSet<Chitiethanghoa> Chitiethanghoas { get; set; }
        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public ConnectDB()
            : base("name=Dbconnect")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
