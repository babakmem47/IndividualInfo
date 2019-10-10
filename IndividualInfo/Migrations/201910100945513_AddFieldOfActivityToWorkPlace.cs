namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldOfActivityToWorkPlace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkPlaces", "FieldOfActivity", c => c.String(maxLength: 130));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkPlaces", "FieldOfActivity");
        }
    }
}
