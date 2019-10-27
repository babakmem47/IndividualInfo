namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRouterIpIpRangeBigIpRangeWithFluentApis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BigIpRanges",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        BigRange = c.String(nullable: false, maxLength: 15),
                        Mask = c.Byte(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IpRanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Range = c.String(nullable: false, maxLength: 15),
                        Mask = c.Byte(nullable: false),
                        BigIpRangeId = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BigIpRanges", t => t.BigIpRangeId, cascadeDelete: true)
                .Index(t => t.BigIpRangeId);
            
            CreateTable(
                "dbo.IpAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ipv4 = c.String(nullable: false, maxLength: 15),
                        IpRangeId = c.Int(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IpRanges", t => t.IpRangeId, cascadeDelete: true)
                .Index(t => t.IpRangeId);
            
            CreateTable(
                "dbo.Routers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Model = c.String(nullable: false, maxLength: 30),
                        WorkPlaceId = c.Int(nullable: false),
                        HostName = c.String(maxLength: 50),
                        InfoDate = c.DateTime(nullable: false),
                        Ssh = c.Boolean(),
                        Ise = c.Boolean(),
                        IosVersion = c.String(maxLength: 50),
                        TunnelNumber = c.Short(),
                        DefaultRouteNumber = c.Byte(),
                        IpRouteNumber = c.Short(),
                        DownInterfacesNumber = c.Byte(),
                        Uptime = c.DateTime(),
                        DualPower = c.Byte(),
                        IpAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkPlaces", t => t.WorkPlaceId)
                .ForeignKey("dbo.IpAddresses", t => t.IpAddress_Id)
                .Index(t => t.WorkPlaceId)
                .Index(t => t.IpAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IpRanges", "BigIpRangeId", "dbo.BigIpRanges");
            DropForeignKey("dbo.IpAddresses", "IpRangeId", "dbo.IpRanges");
            DropForeignKey("dbo.Routers", "IpAddress_Id", "dbo.IpAddresses");
            DropForeignKey("dbo.Routers", "WorkPlaceId", "dbo.WorkPlaces");
            DropIndex("dbo.Routers", new[] { "IpAddress_Id" });
            DropIndex("dbo.Routers", new[] { "WorkPlaceId" });
            DropIndex("dbo.IpAddresses", new[] { "IpRangeId" });
            DropIndex("dbo.IpRanges", new[] { "BigIpRangeId" });
            DropTable("dbo.Routers");
            DropTable("dbo.IpAddresses");
            DropTable("dbo.IpRanges");
            DropTable("dbo.BigIpRanges");
        }
    }
}
