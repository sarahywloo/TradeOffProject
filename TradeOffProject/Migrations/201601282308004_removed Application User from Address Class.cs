namespace TradeOffProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedApplicationUserfromAddressClass : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryTradePosts", newName: "TradePostCategories");
            DropIndex("dbo.AspNetUsers", new[] { "Address_Id" });
            DropPrimaryKey("dbo.TradePostCategories");
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "State", c => c.String());
            AlterColumn("dbo.Addresses", "PostalCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Address_Id", c => c.Int());
            AddPrimaryKey("dbo.TradePostCategories", new[] { "TradePost_Id", "Category_Id" });
            CreateIndex("dbo.AspNetUsers", "Address_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Address_Id" });
            DropPrimaryKey("dbo.TradePostCategories");
            AlterColumn("dbo.AspNetUsers", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "PostalCode", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false));
            AddPrimaryKey("dbo.TradePostCategories", new[] { "Category_Id", "TradePost_Id" });
            CreateIndex("dbo.AspNetUsers", "Address_Id");
            RenameTable(name: "dbo.TradePostCategories", newName: "CategoryTradePosts");
        }
    }
}
