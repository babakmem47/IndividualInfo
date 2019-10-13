namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedUpdatedToWorkPlace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkPlaces", "Created", c => c.DateTime());
            AddColumn("dbo.WorkPlaces", "Updated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkPlaces", "Updated");
            DropColumn("dbo.WorkPlaces", "Created");
        }
    }
}
