namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        AverageGrade = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        ImageURL = c.String(),
                        Approved = c.Boolean(nullable: false),
                        AppUser_Id = c.Int(nullable: false),
                        AccommodationType_Id = c.Int(nullable: false),
                        Place_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccommodationTypes", t => t.AccommodationType_Id, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.Place_Id, cascadeDelete: true)
                .Index(t => t.AppUser_Id)
                .Index(t => t.AccommodationType_Id)
                .Index(t => t.Place_Id);
            
            CreateTable(
                "dbo.AccommodationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Text = c.String(),
                        Acc_Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.Acc_Id, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.User_Id)
                .Index(t => t.Acc_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id, cascadeDelete: true)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        BedCount = c.Int(nullable: false),
                        Description = c.String(),
                        PricePerNight = c.Double(nullable: false),
                        Acc_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.Acc_Id, cascadeDelete: true)
                .Index(t => t.Acc_Id);
            
            CreateTable(
                "dbo.RoomReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Timestamp = c.Time(nullable: false, precision: 7),
                        Room_Id = c.Int(nullable: false),
                        AppUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.AppUser_Id);
            
            AddColumn("dbo.AppUsers", "Username", c => c.String(maxLength: 100));
            AddColumn("dbo.AppUsers", "isBanned", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppUsers", "Role", c => c.String());
            AddColumn("dbo.AspNetUsers", "appUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "appUserId");
            AddForeignKey("dbo.AspNetUsers", "appUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.AppUsers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "FullName", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "appUserId", "dbo.AppUsers");
            DropForeignKey("dbo.RoomReservations", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomReservations", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Rooms", "Acc_Id", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.Places", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Regions", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "Acc_Id", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Accommodations", "AccommodationType_Id", "dbo.AccommodationTypes");
            DropIndex("dbo.AspNetUsers", new[] { "appUserId" });
            DropIndex("dbo.RoomReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.RoomReservations", new[] { "Room_Id" });
            DropIndex("dbo.Rooms", new[] { "Acc_Id" });
            DropIndex("dbo.Regions", new[] { "Country_Id" });
            DropIndex("dbo.Places", new[] { "Region_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Acc_Id" });
            DropIndex("dbo.Accommodations", new[] { "Place_Id" });
            DropIndex("dbo.Accommodations", new[] { "AccommodationType_Id" });
            DropIndex("dbo.Accommodations", new[] { "AppUser_Id" });
            DropColumn("dbo.AspNetUsers", "appUserId");
            DropColumn("dbo.AppUsers", "Role");
            DropColumn("dbo.AppUsers", "isBanned");
            DropColumn("dbo.AppUsers", "Username");
            DropTable("dbo.RoomReservations");
            DropTable("dbo.Rooms");
            DropTable("dbo.Countries");
            DropTable("dbo.Regions");
            DropTable("dbo.Places");
            DropTable("dbo.Comments");
            DropTable("dbo.AccommodationTypes");
            DropTable("dbo.Accommodations");
        }
    }
}
