namespace PriceBey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceClickHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductPriceId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductPrices", t => t.ProductPriceId, cascadeDelete: true)
                .Index(t => t.ProductPriceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceClickHistories", "ProductPriceId", "dbo.ProductPrices");
            DropIndex("dbo.PriceClickHistories", new[] { "ProductPriceId" });
            DropTable("dbo.PriceClickHistories");
        }
    }
}
