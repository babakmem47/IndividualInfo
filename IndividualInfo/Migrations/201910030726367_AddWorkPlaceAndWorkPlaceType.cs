namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkPlaceAndWorkPlaceType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WorkPlaceTypeId = c.Byte(nullable: false),
                        Tel = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkPlaceTypes", t => t.WorkPlaceTypeId, cascadeDelete: true)
                .Index(t => t.WorkPlaceTypeId);
            
            CreateTable(
                "dbo.WorkPlaceTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Individuals", "WorkPlaceId", c => c.Int());
            CreateIndex("dbo.Individuals", "WorkPlaceId");
            AddForeignKey("dbo.Individuals", "WorkPlaceId", "dbo.WorkPlaces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Individuals", "WorkPlaceId", "dbo.WorkPlaces");
            DropForeignKey("dbo.WorkPlaces", "WorkPlaceTypeId", "dbo.WorkPlaceTypes");
            DropIndex("dbo.WorkPlaces", new[] { "WorkPlaceTypeId" });
            DropIndex("dbo.Individuals", new[] { "WorkPlaceId" });
            DropColumn("dbo.Individuals", "WorkPlaceId");
            DropTable("dbo.WorkPlaceTypes");
            DropTable("dbo.WorkPlaces");
        }
    }
}
