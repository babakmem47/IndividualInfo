namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmailLengthTo40 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Individuals", "Email", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Individuals", "Email", c => c.String(maxLength: 30));
        }
    }
}
