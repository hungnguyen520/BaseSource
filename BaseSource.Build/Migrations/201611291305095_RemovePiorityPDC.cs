namespace BaseSource.Build.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePiorityPDC : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductCatalogs", "Priority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCatalogs", "Priority", c => c.Int(nullable: false));
        }
    }
}
