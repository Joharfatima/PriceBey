namespace PriceBey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductBookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        ProductPriceId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        Comments = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductPrices", t => t.ProductPriceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ProductPriceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductBookings", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductBookings", "ProductPriceId", "dbo.ProductPrices");
            DropIndex("dbo.ProductBookings", new[] { "ProductPriceId" });
            DropIndex("dbo.ProductBookings", new[] { "UserID" });
            DropTable("dbo.ProductBookings");
        }
    }
}
