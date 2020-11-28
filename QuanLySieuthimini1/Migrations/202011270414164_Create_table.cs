namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hoadons", "Ma_HH", "dbo.Chitiethanghoas");
            AddForeignKey("dbo.Hoadons", "Ma_HH", "dbo.Hanghoas", "Ma_HH", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hoadons", "Ma_HH", "dbo.Hanghoas");
            AddForeignKey("dbo.Hoadons", "Ma_HH", "dbo.Chitiethanghoas", "Ma_HH", cascadeDelete: true);
        }
    }
}
