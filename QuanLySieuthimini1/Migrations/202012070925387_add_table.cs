namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chitiethanghoas",
                c => new
                    {
                        Ma_HH = c.Int(nullable: false, identity: true),
                        GiamMua = c.Int(nullable: false),
                        GiaBan = c.Int(nullable: false),
                        Noi_SX = c.String(nullable: false),
                        HSD = c.DateTime(nullable: false),
                        Loai_HH = c.String(nullable: false),
                        SoLuongNhap = c.String(nullable: false),
                        Ma_NH = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_HH);
            
            CreateTable(
                "dbo.Hanghoas",
                c => new
                    {
                        Ma_HH = c.Int(nullable: false, identity: true),
                        Ma_NCC = c.Int(nullable: false),
                        Ma_NH = c.Int(nullable: false),
                        Ten_HH = c.String(nullable: false),
                        Chitiethanghoa_Ma_HH = c.Int(),
                    })
                .PrimaryKey(t => t.Ma_HH)
                .ForeignKey("dbo.Chitiethanghoas", t => t.Chitiethanghoa_Ma_HH)
                .ForeignKey("dbo.Nhacungcaps", t => t.Ma_NCC, cascadeDelete: true)
                .ForeignKey("dbo.Nhomhangs", t => t.Ma_NH, cascadeDelete: true)
                .Index(t => t.Ma_NCC)
                .Index(t => t.Ma_NH)
                .Index(t => t.Chitiethanghoa_Ma_HH);
            
            CreateTable(
                "dbo.Hoadons",
                c => new
                    {
                        Ma_HD = c.Int(nullable: false, identity: true),
                        Ma_HH = c.Int(nullable: false),
                        Ma_NV = c.Int(nullable: false),
                        TongTien = c.Int(nullable: false),
                        Trangthai = c.String(),
                        Ngaytaohoadon = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_HD)
                .ForeignKey("dbo.Hanghoas", t => t.Ma_HH, cascadeDelete: true)
                .ForeignKey("dbo.Nhanviens", t => t.Ma_NV, cascadeDelete: true)
                .Index(t => t.Ma_HH)
                .Index(t => t.Ma_NV);
            
            CreateTable(
                "dbo.Chitiethoadons",
                c => new
                    {
                        Ma_CTHD = c.Int(nullable: false, identity: true),
                        Ma_HD = c.Int(nullable: false),
                        Ma_HH = c.Int(nullable: false),
                        Soluong = c.Int(nullable: false),
                        Gia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_CTHD)
                .ForeignKey("dbo.Hoadons", t => t.Ma_HD, cascadeDelete: true)
                .Index(t => t.Ma_HD);
            
            CreateTable(
                "dbo.Nhanviens",
                c => new
                    {
                        Ma_NV = c.Int(nullable: false, identity: true),
                        Ten_NV = c.String(nullable: false, maxLength: 30),
                        SĐT = c.Int(nullable: false),
                        Diachi = c.String(nullable: false),
                        Gioitinh = c.String(nullable: false),
                        Ngayvaolam = c.String(),
                        Email = c.String(nullable: false),
                        Role = c.String(),
                        Matkhau = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_NV);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        Ma_NV = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Matkhau = c.String(nullable: false),
                        Nhanvien_Ma_NV = c.Int(),
                    })
                .PrimaryKey(t => t.Ma_NV)
                .ForeignKey("dbo.Nhanviens", t => t.Nhanvien_Ma_NV)
                .Index(t => t.Nhanvien_Ma_NV);
            
            CreateTable(
                "dbo.Nhacungcaps",
                c => new
                    {
                        Ma_NCC = c.Int(nullable: false, identity: true),
                        Ten_NCC = c.String(nullable: false),
                        Diachi = c.String(nullable: false),
                        SĐT = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_NCC);
            
            CreateTable(
                "dbo.Nhomhangs",
                c => new
                    {
                        Ma_NH = c.Int(nullable: false, identity: true),
                        Ten_NH = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_NH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hanghoas", "Ma_NH", "dbo.Nhomhangs");
            DropForeignKey("dbo.Hanghoas", "Ma_NCC", "dbo.Nhacungcaps");
            DropForeignKey("dbo.TaiKhoans", "Nhanvien_Ma_NV", "dbo.Nhanviens");
            DropForeignKey("dbo.Hoadons", "Ma_NV", "dbo.Nhanviens");
            DropForeignKey("dbo.Hoadons", "Ma_HH", "dbo.Hanghoas");
            DropForeignKey("dbo.Chitiethoadons", "Ma_HD", "dbo.Hoadons");
            DropForeignKey("dbo.Hanghoas", "Chitiethanghoa_Ma_HH", "dbo.Chitiethanghoas");
            DropIndex("dbo.TaiKhoans", new[] { "Nhanvien_Ma_NV" });
            DropIndex("dbo.Chitiethoadons", new[] { "Ma_HD" });
            DropIndex("dbo.Hoadons", new[] { "Ma_NV" });
            DropIndex("dbo.Hoadons", new[] { "Ma_HH" });
            DropIndex("dbo.Hanghoas", new[] { "Chitiethanghoa_Ma_HH" });
            DropIndex("dbo.Hanghoas", new[] { "Ma_NH" });
            DropIndex("dbo.Hanghoas", new[] { "Ma_NCC" });
            DropTable("dbo.Nhomhangs");
            DropTable("dbo.Nhacungcaps");
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.Nhanviens");
            DropTable("dbo.Chitiethoadons");
            DropTable("dbo.Hoadons");
            DropTable("dbo.Hanghoas");
            DropTable("dbo.Chitiethanghoas");
        }
    }
}
