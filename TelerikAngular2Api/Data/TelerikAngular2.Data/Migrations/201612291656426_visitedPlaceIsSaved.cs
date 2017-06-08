namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visitedPlaceIsSaved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitedPlaces", "IsSaved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitedPlaces", "IsSaved");
        }
    }
}
