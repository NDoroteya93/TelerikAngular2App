namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VisitedPlaces", "Lat", c => c.Single(nullable: false));
            AlterColumn("dbo.VisitedPlaces", "Lng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitedPlaces", "Lng", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VisitedPlaces", "Lat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
