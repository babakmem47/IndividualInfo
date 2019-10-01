namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailPropToIndividual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Individuals", "Email", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Individuals", "Email");
        }
    }
}
