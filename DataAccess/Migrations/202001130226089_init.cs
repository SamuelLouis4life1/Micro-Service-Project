namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartProducts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Carts_Id = c.Guid(),
                        Products_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Carts_Id)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .Index(t => t.Carts_Id)
                .Index(t => t.Products_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductsCarts",
                c => new
                    {
                        Products_Id = c.Guid(nullable: false),
                        Carts_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Products_Id, t.Carts_Id })
                .ForeignKey("dbo.Products", t => t.Products_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Carts_Id, cascadeDelete: true)
                .Index(t => t.Products_Id)
                .Index(t => t.Carts_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartProducts", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.CartProducts", "Carts_Id", "dbo.Carts");
            DropForeignKey("dbo.ProductsCarts", "Carts_Id", "dbo.Carts");
            DropForeignKey("dbo.ProductsCarts", "Products_Id", "dbo.Products");
            DropIndex("dbo.ProductsCarts", new[] { "Carts_Id" });
            DropIndex("dbo.ProductsCarts", new[] { "Products_Id" });
            DropIndex("dbo.CartProducts", new[] { "Products_Id" });
            DropIndex("dbo.CartProducts", new[] { "Carts_Id" });
            DropTable("dbo.ProductsCarts");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            DropTable("dbo.CartProducts");
        }
    }
}
