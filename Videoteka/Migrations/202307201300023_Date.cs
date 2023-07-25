namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rents", "ReturnDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rents", "ReturnDate", c => c.DateTime(nullable: false));
        }
    }
}
