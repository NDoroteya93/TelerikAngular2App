namespace TelerikAngular2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userCountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Country");
        }
    }
}
