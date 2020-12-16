namespace QuanLySieuthimini1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nhanviens", "Ngayvaolam", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nhanviens", "Ngayvaolam", c => c.String(nullable: false));
        }
    }
}
