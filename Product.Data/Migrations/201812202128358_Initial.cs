namespace Product.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.ProductMaterials",
                c => new
                    {
                        ProductMaterialId = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductMaterialId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.ProductMaterials", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductMaterials", new[] { "MaterialId" });
            DropIndex("dbo.ProductMaterials", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductMaterials");
            DropTable("dbo.Materials");
        }
    }
}
