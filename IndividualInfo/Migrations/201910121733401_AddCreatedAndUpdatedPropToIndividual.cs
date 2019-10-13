namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAndUpdatedPropToIndividual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Individuals", "Created", c => c.DateTime());
            AddColumn("dbo.Individuals", "Updated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Individuals", "Updated");
            DropColumn("dbo.Individuals", "Created");
        }
    }
}
