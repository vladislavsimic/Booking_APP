namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrCountryChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "Name", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "Name", c => c.String());
        }
    }
}
