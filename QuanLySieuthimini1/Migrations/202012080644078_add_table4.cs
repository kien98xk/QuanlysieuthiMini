namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chitiethoadons", "Ten_HH", c => c.Int(nullable: false));
            DropColumn("dbo.Chitiethoadons", "Ma_HH");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chitiethoadons", "Ma_HH", c => c.Int(nullable: false));
            DropColumn("dbo.Chitiethoadons", "Ten_HH");
        }
    }
}
