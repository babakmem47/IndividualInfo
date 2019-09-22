namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendLengthOfStrings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Individuals", "Name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 50));
            AlterColumn("dbo.Individuals", "TelDakheli", c => c.String(maxLength: 40));
            AlterColumn("dbo.Individuals", "Mobile", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Individuals", "Mobile", c => c.String(maxLength: 20));
            AlterColumn("dbo.Individuals", "TelDakheli", c => c.String(maxLength: 4));
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 14));
            AlterColumn("dbo.Individuals", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
