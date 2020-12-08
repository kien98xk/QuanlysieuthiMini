namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chitiethanghoas", "Ten_HH", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chitiethanghoas", "Ten_HH");
        }
    }
}
