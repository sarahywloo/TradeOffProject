namespace TradeOffProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        Street2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TradePosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                        Picture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.Pictures", t => t.Picture_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Picture_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CategoryTradePosts",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        TradePost_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.TradePost_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.TradePosts", t => t.TradePost_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.TradePost_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TradePosts", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.Pictures", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TradePosts", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CategoryTradePosts", "TradePost_Id", "dbo.TradePosts");
            DropForeignKey("dbo.CategoryTradePosts", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.CategoryTradePosts", new[] { "TradePost_Id" });
            DropIndex("dbo.CategoryTradePosts", new[] { "Category_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pictures", new[] { "Owner_Id" });
            DropIndex("dbo.TradePosts", new[] { "Picture_Id" });
            DropIndex("dbo.TradePosts", new[] { "Owner_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Address_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.CategoryTradePosts");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pictures");
            DropTable("dbo.Categories");
            DropTable("dbo.TradePosts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Addresses");
        }
    }
}
