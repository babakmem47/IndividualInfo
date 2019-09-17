namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthOfMobileTo201 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 14));
            AlterColumn("dbo.Individuals", "Mobile", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Individuals", "Mobile", c => c.String(maxLength: 14));
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 20));
        }
    }
}
