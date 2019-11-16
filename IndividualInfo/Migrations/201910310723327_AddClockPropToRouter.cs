namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClockPropToRouter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routers", "Clock", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routers", "Clock");
        }
    }
}
