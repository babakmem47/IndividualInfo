namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToIpRange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IpRanges", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IpRanges", "Description");
        }
    }
}
