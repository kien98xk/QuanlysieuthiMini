namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table_Chitiethanghoa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chitiethanghoas", "HSD", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chitiethanghoas", "HSD", c => c.Int(nullable: false));
        }
    }
}
