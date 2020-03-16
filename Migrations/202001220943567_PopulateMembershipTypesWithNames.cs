namespace Vidly_Correct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypesWithNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay as you go' WHERE DurationInMonths=0");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE DurationInMonths=1");
            Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE DurationInMonths=3");
            Sql("UPDATE MembershipTypes SET Name='Annual' WHERE DurationInMonths=12");
        }
        
        public override void Down()
        {
        }
    }
}
