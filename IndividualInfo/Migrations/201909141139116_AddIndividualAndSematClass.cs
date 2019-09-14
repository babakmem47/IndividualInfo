namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndividualAndSematClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Boolean(nullable: false),
                        TelDirect = c.String(),
                        TelDakheli = c.String(),
                        Mobile = c.String(),
                        Description = c.String(),
                        SematId = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semats", t => t.SematId)
                .Index(t => t.SematId);
            
            CreateTable(
                "dbo.Semats",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Individuals", "SematId", "dbo.Semats");
            DropIndex("dbo.Individuals", new[] { "SematId" });
            DropTable("dbo.Semats");
            DropTable("dbo.Individuals");
        }
    }
}
