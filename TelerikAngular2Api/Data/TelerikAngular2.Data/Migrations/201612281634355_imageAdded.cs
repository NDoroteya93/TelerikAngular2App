namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        VisitedPlace_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VisitedPlaces", t => t.VisitedPlace_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.VisitedPlace_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "VisitedPlace_Id", "dbo.VisitedPlaces");
            DropIndex("dbo.Images", new[] { "VisitedPlace_Id" });
            DropIndex("dbo.Images", new[] { "IsDeleted" });
            DropTable("dbo.Images");
        }
    }
}
