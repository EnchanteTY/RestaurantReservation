namespace RestaurantReservation.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DishId = c.Int(nullable: false),
                        Table = c.Int(nullable: false),
                        DishSize = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .Index(t => t.DishId);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        DishID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StandardPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Festival = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DishID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DishImageMappings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        DishID = c.Int(nullable: false),
                        DishImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dishes", t => t.DishID, cascadeDelete: true)
                .ForeignKey("dbo.DishImages", t => t.DishImageID, cascadeDelete: true)
                .Index(t => t.DishID)
                .Index(t => t.DishImageID);
            
            CreateTable(
                "dbo.DishImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.FileName, unique: true);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        DishID = c.Int(),
                        Table = c.Int(nullable: false),
                        DishSize = c.Int(nullable: false),
                        DishName = c.String(),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dishes", t => t.DishID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.DishID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        Salutation = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        MealDate = c.DateTime(nullable: false),
                        MealTime = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        TableOrdered = c.Int(nullable: false),
                        ExtraRequest = c.String(nullable: false),
                        ServeListId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.ServeLists", t => t.ServeListId)
                .Index(t => t.ServeListId);
            
            CreateTable(
                "dbo.ServeLists",
                c => new
                    {
                        ServeListId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.Int(nullable: false),
                        AccumulatedTableOrdered = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServeListId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "ServeListId", "dbo.ServeLists");
            DropForeignKey("dbo.OrderLines", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderLines", "DishID", "dbo.Dishes");
            DropForeignKey("dbo.CartLines", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.DishImageMappings", "DishImageID", "dbo.DishImages");
            DropForeignKey("dbo.DishImageMappings", "DishID", "dbo.Dishes");
            DropForeignKey("dbo.Dishes", "CategoryID", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Orders", new[] { "ServeListId" });
            DropIndex("dbo.OrderLines", new[] { "DishID" });
            DropIndex("dbo.OrderLines", new[] { "OrderID" });
            DropIndex("dbo.DishImages", new[] { "FileName" });
            DropIndex("dbo.DishImageMappings", new[] { "DishImageID" });
            DropIndex("dbo.DishImageMappings", new[] { "DishID" });
            DropIndex("dbo.Dishes", new[] { "CategoryID" });
            DropIndex("dbo.CartLines", new[] { "DishId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ServeLists");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
            DropTable("dbo.DishImages");
            DropTable("dbo.DishImageMappings");
            DropTable("dbo.Categories");
            DropTable("dbo.Dishes");
            DropTable("dbo.CartLines");
        }
    }
}
