namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthOfMobileTo20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 15));
        }
    }
}
