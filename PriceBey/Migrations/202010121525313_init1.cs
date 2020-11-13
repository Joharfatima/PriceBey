namespace PriceBey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProductPrices", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Name", c => c.String());
            AlterColumn("dbo.ProductPrices", "Url", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
