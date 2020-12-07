namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Chitiethanghoas", "Ma_NH");
            AddForeignKey("dbo.Chitiethanghoas", "Ma_NH", "dbo.Nhomhangs", "Ma_NH", cascadeDelete: true);
            DropColumn("dbo.Chitiethanghoas", "Loai_HH");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chitiethanghoas", "Loai_HH", c => c.String(nullable: false));
            DropForeignKey("dbo.Chitiethanghoas", "Ma_NH", "dbo.Nhomhangs");
            DropIndex("dbo.Chitiethanghoas", new[] { "Ma_NH" });
        }
    }
}
