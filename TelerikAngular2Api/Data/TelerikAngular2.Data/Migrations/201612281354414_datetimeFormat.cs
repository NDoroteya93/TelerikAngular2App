namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeFormat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "ModifiedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "DeletedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VisitedPlaces", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VisitedPlaces", "ModifiedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VisitedPlaces", "DeletedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitedPlaces", "DeletedOn", c => c.DateTime());
            AlterColumn("dbo.VisitedPlaces", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.VisitedPlaces", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DeletedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
