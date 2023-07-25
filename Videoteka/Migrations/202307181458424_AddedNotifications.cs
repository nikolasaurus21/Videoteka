namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Notifications", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Notifications");
        }
    }
}
