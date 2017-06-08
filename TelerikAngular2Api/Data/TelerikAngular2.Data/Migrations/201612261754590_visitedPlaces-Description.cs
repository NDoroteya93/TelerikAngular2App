namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visitedPlacesDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitedPlaces", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitedPlaces", "Description");
        }
    }
}
