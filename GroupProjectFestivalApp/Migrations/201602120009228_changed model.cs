namespace GroupProjectFestivalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "PictureUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "PicutreUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PicutreUrl");
            DropColumn("dbo.Comments", "PictureUrl");
        }
    }
}
