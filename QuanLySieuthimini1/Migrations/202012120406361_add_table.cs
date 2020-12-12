namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chitiethoadons", "Ten_HH", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chitiethoadons", "Ten_HH", c => c.Int(nullable: false));
        }
    }
}
