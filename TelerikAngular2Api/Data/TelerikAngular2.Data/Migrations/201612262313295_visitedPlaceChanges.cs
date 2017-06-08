namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visitedPlaceChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitedPlaces", "Draggable", c => c.Boolean(nullable: false));
            AddColumn("dbo.VisitedPlaces", "IsOpen", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitedPlaces", "IsOpen");
            DropColumn("dbo.VisitedPlaces", "Draggable");
        }
    }
}
