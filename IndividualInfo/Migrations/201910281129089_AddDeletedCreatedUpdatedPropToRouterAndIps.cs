namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeletedCreatedUpdatedPropToRouterAndIps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BigIpRanges", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.BigIpRanges", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.BigIpRanges", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.IpRanges", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.IpRanges", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.IpRanges", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.IpAddresses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.IpAddresses", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.IpAddresses", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Routers", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Routers", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Routers", "Updated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routers", "Updated");
            DropColumn("dbo.Routers", "Created");
            DropColumn("dbo.Routers", "Deleted");
            DropColumn("dbo.IpAddresses", "Updated");
            DropColumn("dbo.IpAddresses", "Created");
            DropColumn("dbo.IpAddresses", "Deleted");
            DropColumn("dbo.IpRanges", "Updated");
            DropColumn("dbo.IpRanges", "Created");
            DropColumn("dbo.IpRanges", "Deleted");
            DropColumn("dbo.BigIpRanges", "Updated");
            DropColumn("dbo.BigIpRanges", "Created");
            DropColumn("dbo.BigIpRanges", "Deleted");
        }
    }
}
