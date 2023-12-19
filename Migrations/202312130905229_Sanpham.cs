namespace S_me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sanpham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Danhmucs",
                c => new
                    {
                        DMID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.DMID);
            
            CreateTable(
                "dbo.Sanphams",
                c => new
                    {
                        SpID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Summary = c.String(),
                        Picture = c.Binary(),
                        Picture2 = c.Binary(),
                        Rated = c.Double(nullable: false),
                        Storage = c.Int(nullable: false),
                        CatID = c.Int(),
                        BrandID = c.Int(),
                    })
                .PrimaryKey(t => t.SpID)
                .ForeignKey("dbo.Danhmucs", t => t.CatID)
                .ForeignKey("dbo.Thuonghieux", t => t.BrandID)
                .Index(t => t.CatID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Thuonghieux",
                c => new
                    {
                        ThuonghieuID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ThuonghieuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanphams", "BrandID", "dbo.Thuonghieux");
            DropForeignKey("dbo.Sanphams", "CatID", "dbo.Danhmucs");
            DropIndex("dbo.Sanphams", new[] { "BrandID" });
            DropIndex("dbo.Sanphams", new[] { "CatID" });
            DropTable("dbo.Thuonghieux");
            DropTable("dbo.Sanphams");
            DropTable("dbo.Danhmucs");
        }
    }
}
