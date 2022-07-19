namespace Rgisterpage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Passworld = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductCats", "price", c => c.String());
            DropColumn("dbo.ProductCats", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCats", "status", c => c.String());
            DropColumn("dbo.ProductCats", "price");
            DropTable("dbo.Logins");
        }
    }
}
