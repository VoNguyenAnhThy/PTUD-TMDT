namespace S_me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donhang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserAdmin = c.String(nullable: false, maxLength: 128),
                        PassAdmin = c.String(),
                        Hoten = c.String(),
                    })
                .PrimaryKey(t => t.UserAdmin);
            
            CreateTable(
                "dbo.Chitietdonhangs",
                c => new
                    {
                        ChitietID = c.Int(nullable: false, identity: true),
                        DHID = c.Int(nullable: false),
                        SpID = c.Int(nullable: false),
                        Soluong = c.Int(nullable: false),
                        Dongia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ChitietID)
                .ForeignKey("dbo.Donhangs", t => t.DHID, cascadeDelete: true)
                .ForeignKey("dbo.Sanphams", t => t.SpID, cascadeDelete: true)
                .Index(t => t.DHID)
                .Index(t => t.SpID);
            
            CreateTable(
                "dbo.Donhangs",
                c => new
                    {
                        DHID = c.Int(nullable: false, identity: true),
                        TongTien = c.Double(nullable: false),
                        NgayLap = c.DateTime(nullable: false),
                        KHID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DHID)
                .ForeignKey("dbo.Khachhangs", t => t.KHID, cascadeDelete: true)
                .Index(t => t.KHID);
            
            CreateTable(
                "dbo.Khachhangs",
                c => new
                    {
                        KHID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(),
                        Dc = c.String(),
                        Sdt = c.String(),
                    })
                .PrimaryKey(t => t.KHID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chitietdonhangs", "SpID", "dbo.Sanphams");
            DropForeignKey("dbo.Chitietdonhangs", "DHID", "dbo.Donhangs");
            DropForeignKey("dbo.Donhangs", "KHID", "dbo.Khachhangs");
            DropIndex("dbo.Donhangs", new[] { "KHID" });
            DropIndex("dbo.Chitietdonhangs", new[] { "SpID" });
            DropIndex("dbo.Chitietdonhangs", new[] { "DHID" });
            DropTable("dbo.Khachhangs");
            DropTable("dbo.Donhangs");
            DropTable("dbo.Chitietdonhangs");
            DropTable("dbo.Admins");
        }
    }
}
