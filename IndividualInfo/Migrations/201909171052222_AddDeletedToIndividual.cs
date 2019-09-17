namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeletedToIndividual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Individuals", "Deleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Individuals", "Deleted");
        }
    }
}
