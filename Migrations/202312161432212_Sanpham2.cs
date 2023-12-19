namespace S_me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sanpham2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sanphams", "Sanpham_SpID", c => c.Int());
            CreateIndex("dbo.Sanphams", "Sanpham_SpID");
            AddForeignKey("dbo.Sanphams", "Sanpham_SpID", "dbo.Sanphams", "SpID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanphams", "Sanpham_SpID", "dbo.Sanphams");
            DropIndex("dbo.Sanphams", new[] { "Sanpham_SpID" });
            DropColumn("dbo.Sanphams", "Sanpham_SpID");
        }
    }
}
