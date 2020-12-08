namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hoadons", "Ten_HH", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hoadons", "Ten_HH");
        }
    }
}
