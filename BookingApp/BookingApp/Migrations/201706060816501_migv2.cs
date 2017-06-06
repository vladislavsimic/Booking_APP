namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accommodations", "Approved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Comments", "Grade", c => c.Int(nullable: false));
            AlterColumn("dbo.RoomReservations", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RoomReservations", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RoomReservations", "Timestamp", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomReservations", "Timestamp", c => c.String());
            AlterColumn("dbo.RoomReservations", "EndDate", c => c.String());
            AlterColumn("dbo.RoomReservations", "StartDate", c => c.String());
            AlterColumn("dbo.Comments", "Grade", c => c.String());
            AlterColumn("dbo.Accommodations", "Approved", c => c.String());
        }
    }
}
