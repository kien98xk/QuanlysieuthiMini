namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chitiethanghoas", "GiaMua", c => c.Int(nullable: false));
            DropColumn("dbo.Chitiethanghoas", "GiamMua");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chitiethanghoas", "GiamMua", c => c.Int(nullable: false));
            DropColumn("dbo.Chitiethanghoas", "GiaMua");
        }
    }
}
