namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToCustomerTypeAndMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerTypes (Name) VALUES ('Učenik')");
            Sql("INSERT INTO CustomerTypes (Name) VALUES ('Student')");
            Sql("INSERT INTO CustomerTypes (Name) VALUES ('Nezaposlen')");
            Sql("INSERT INTO CustomerTypes (Name) VALUES ('Zaposlen')");
            Sql("INSERT INTO CustomerTypes (Name) VALUES ('Penzioner')");

            
            Sql("INSERT INTO MembershipTypes (Name, MembershipFee, Discount, MonthlyDuration) VALUES ('Po viđenju', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Name, MembershipFee, Discount, MonthlyDuration) VALUES ('Mjesečno', 30, 10, 1)");
            Sql("INSERT INTO MembershipTypes (Name, MembershipFee, Discount, MonthlyDuration) VALUES ('Kvartalno', 90, 15, 3)");
            Sql("INSERT INTO MembershipTypes (Name, MembershipFee, Discount, MonthlyDuration) VALUES ('Polugodišnje', 165, 20, 6)");
            Sql("INSERT INTO MembershipTypes (Name, MembershipFee, Discount, MonthlyDuration) VALUES ('Godišnje', 300, 30, 12)");
        }
        
        public override void Down()
        {
        }
    }
}
