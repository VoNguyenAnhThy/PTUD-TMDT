namespace S_me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Form : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        formID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 200),
                        CustomerEmail = c.String(nullable: false, maxLength: 100),
                        CustomerPhone = c.String(nullable: false, maxLength: 12),
                        CustomerMessage = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.formID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Forms");
        }
    }
}
