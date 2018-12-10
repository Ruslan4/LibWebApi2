namespace LibDataLayer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BestLib : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookСipher = c.Int(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        Pages = c.Int(nullable: false),
                        PrintDate = c.DateTime(nullable: false),
                        CountBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.CatalogBooks",
                c => new
                    {
                        CatalogBooksId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        HaveABook = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CatalogBooksId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.IssuanceOfBooks",
                c => new
                    {
                        IssuanceOfBooksId = c.Int(nullable: false, identity: true),
                        DateIssue = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        CatalogBooksId = c.Int(nullable: false),
                        ClientProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IssuanceOfBooksId)
                .ForeignKey("dbo.CatalogBooks", t => t.CatalogBooksId, cascadeDelete: true)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfile_Id)
                .Index(t => t.CatalogBooksId)
                .Index(t => t.ClientProfile_Id);
            
            CreateTable(
                "dbo.ClientProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ClientProfileId = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        IssuanceOfBooksId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.IssuanceOfBooks", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.ClientProfiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.IssuanceOfBooks", "CatalogBooksId", "dbo.CatalogBooks");
            DropForeignKey("dbo.CatalogBooks", "BookId", "dbo.Books");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ClientProfiles", new[] { "Id" });
            DropIndex("dbo.IssuanceOfBooks", new[] { "ClientProfile_Id" });
            DropIndex("dbo.IssuanceOfBooks", new[] { "CatalogBooksId" });
            DropIndex("dbo.CatalogBooks", new[] { "BookId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ClientProfiles");
            DropTable("dbo.IssuanceOfBooks");
            DropTable("dbo.CatalogBooks");
            DropTable("dbo.Books");
        }
    }
}
