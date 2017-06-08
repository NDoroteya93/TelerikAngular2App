namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageBytes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Photo");
        }
    }
}
