namespace GroupProjectFestivalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Host = c.String(),
                        Ratings = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Users_Id = c.String(maxLength: 128),
                        Host_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .ForeignKey("dbo.Hosts", t => t.Host_Id)
                .Index(t => t.Users_Id)
                .Index(t => t.Host_Id);
            
            CreateTable(
                "dbo.Attractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Host = c.String(),
                        Rating = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Host_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hosts", t => t.Host_Id)
                .Index(t => t.Host_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Comment = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pushpins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Loc1 = c.Boolean(nullable: false),
                        Loc2 = c.Boolean(nullable: false),
                        Loc3 = c.Boolean(nullable: false),
                        Loc4 = c.Boolean(nullable: false),
                        Loc5 = c.Boolean(nullable: false),
                        Loc6 = c.Boolean(nullable: false),
                        Loc7 = c.Boolean(nullable: false),
                        Loc8 = c.Boolean(nullable: false),
                        Host = c.String(),
                        Active = c.Boolean(nullable: false),
                        Host_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hosts", t => t.Host_Id)
                .Index(t => t.Host_Id);
            
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Active = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
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
                "dbo.AttractionEvents",
                c => new
                    {
                        Attraction_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Attraction_Id, t.Event_Id })
                .ForeignKey("dbo.Attractions", t => t.Attraction_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Attraction_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.TagAttractions",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Attraction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Attraction_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Attractions", t => t.Attraction_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Attraction_Id);
            
            CreateTable(
                "dbo.TagEvents",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Event_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.PushpinEvents",
                c => new
                    {
                        Pushpin_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pushpin_Id, t.Event_Id })
                .ForeignKey("dbo.Pushpins", t => t.Pushpin_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Pushpin_Id)
                .Index(t => t.Event_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hosts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pushpins", "Host_Id", "dbo.Hosts");
            DropForeignKey("dbo.Events", "Host_Id", "dbo.Hosts");
            DropForeignKey("dbo.Attractions", "Host_Id", "dbo.Hosts");
            DropForeignKey("dbo.Events", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PushpinEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.PushpinEvents", "Pushpin_Id", "dbo.Pushpins");
            DropForeignKey("dbo.TagEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.TagEvents", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagAttractions", "Attraction_Id", "dbo.Attractions");
            DropForeignKey("dbo.TagAttractions", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.AttractionEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.AttractionEvents", "Attraction_Id", "dbo.Attractions");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.PushpinEvents", new[] { "Event_Id" });
            DropIndex("dbo.PushpinEvents", new[] { "Pushpin_Id" });
            DropIndex("dbo.TagEvents", new[] { "Event_Id" });
            DropIndex("dbo.TagEvents", new[] { "Tag_Id" });
            DropIndex("dbo.TagAttractions", new[] { "Attraction_Id" });
            DropIndex("dbo.TagAttractions", new[] { "Tag_Id" });
            DropIndex("dbo.AttractionEvents", new[] { "Event_Id" });
            DropIndex("dbo.AttractionEvents", new[] { "Attraction_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Hosts", new[] { "User_Id" });
            DropIndex("dbo.Pushpins", new[] { "Host_Id" });
            DropIndex("dbo.Attractions", new[] { "Host_Id" });
            DropIndex("dbo.Events", new[] { "Host_Id" });
            DropIndex("dbo.Events", new[] { "Users_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.PushpinEvents");
            DropTable("dbo.TagEvents");
            DropTable("dbo.TagAttractions");
            DropTable("dbo.AttractionEvents");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Hosts");
            DropTable("dbo.Pushpins");
            DropTable("dbo.Tags");
            DropTable("dbo.Attractions");
            DropTable("dbo.Events");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
