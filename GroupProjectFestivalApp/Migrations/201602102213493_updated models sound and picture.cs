namespace GroupProjectFestivalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelssoundandpicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attractions", "Sound", c => c.String());
            AddColumn("dbo.Attractions", "PictureUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attractions", "PictureUrl");
            DropColumn("dbo.Attractions", "Sound");
        }
    }
}
