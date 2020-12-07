namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chitiethanghoas", "Ma_NH", c => c.Int(nullable: false));
            CreateIndex("dbo.Chitiethanghoas", "Ma_NH");
            AddForeignKey("dbo.Chitiethanghoas", "Ma_NH", "dbo.Nhomhangs", "Ma_NH", cascadeDelete: true);
            DropColumn("dbo.Chitiethanghoas", "Loai_HH");
            DropColumn("dbo.Chitiethanghoas", "Ten_NH");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chitiethanghoas", "Ten_NH", c => c.String(nullable: false));
            AddColumn("dbo.Chitiethanghoas", "Loai_HH", c => c.String(nullable: false));
            DropForeignKey("dbo.Chitiethanghoas", "Ma_NH", "dbo.Nhomhangs");
            DropIndex("dbo.Chitiethanghoas", new[] { "Ma_NH" });
            DropColumn("dbo.Chitiethanghoas", "Ma_NH");
        }
    }
}
