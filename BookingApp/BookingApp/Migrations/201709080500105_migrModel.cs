namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accommodations", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Accommodations", "Description", c => c.String(maxLength: 120));
            AlterColumn("dbo.Accommodations", "Address", c => c.String(maxLength: 40));
            AlterColumn("dbo.AccommodationTypes", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Comments", "Text", c => c.String(maxLength: 100));
            AlterColumn("dbo.Places", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Regions", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Rooms", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "Description", c => c.String());
            AlterColumn("dbo.Regions", "Name", c => c.String());
            AlterColumn("dbo.Places", "Name", c => c.String());
            AlterColumn("dbo.Comments", "Text", c => c.String());
            AlterColumn("dbo.AccommodationTypes", "Name", c => c.String());
            AlterColumn("dbo.Accommodations", "Address", c => c.String());
            AlterColumn("dbo.Accommodations", "Description", c => c.String());
            AlterColumn("dbo.Accommodations", "Name", c => c.String());
        }
    }
}
