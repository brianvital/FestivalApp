namespace GroupProjectFestivalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pushpins", "Left", c => c.Int(nullable: false));
            AddColumn("dbo.Pushpins", "Top", c => c.Int(nullable: false));
            AddColumn("dbo.Pushpins", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pushpins", "Category");
            DropColumn("dbo.Pushpins", "Top");
            DropColumn("dbo.Pushpins", "Left");
        }
    }
}
