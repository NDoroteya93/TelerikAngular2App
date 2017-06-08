namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visitedPlaceIs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitedPlaces", "IsVisited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitedPlaces", "IsVisited");
        }
    }
}
