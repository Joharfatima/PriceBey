namespace PriceBey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProductPrices", "ProductId");
            CreateIndex("dbo.ProductPrices", "StoreId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "ColorId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ColorId", "dbo.Colors", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductPrices", "StoreId", "dbo.Stores", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPrices", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ProductPrices", new[] { "StoreId" });
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
        }
    }
}
