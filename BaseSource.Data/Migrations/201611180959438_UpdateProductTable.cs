namespace BaseSource.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "HotFlag", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "SafeOff", c => c.Byte());
            DropColumn("dbo.Products", "InStock");
            DropColumn("dbo.Products", "Priority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Priority", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "InStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "SafeOff", c => c.Byte(nullable: false));
            DropColumn("dbo.Products", "HotFlag");
            DropColumn("dbo.Products", "NumberInStock");
        }
    }
}
