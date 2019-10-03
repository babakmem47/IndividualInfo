namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFluentApiForWorkPlaceAndWorkPlaceType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkPlaces", "WorkPlaceTypeId", "dbo.WorkPlaceTypes");
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 13));
            AlterColumn("dbo.Individuals", "TelDakheli", c => c.String(maxLength: 4));
            AlterColumn("dbo.Individuals", "Mobile", c => c.String(maxLength: 13));
            AlterColumn("dbo.WorkPlaces", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.WorkPlaces", "Tel", c => c.String(maxLength: 40));
            AlterColumn("dbo.WorkPlaces", "Address", c => c.String(maxLength: 130));
            AlterColumn("dbo.WorkPlaceTypes", "Name", c => c.String(nullable: false, maxLength: 20));
            AddForeignKey("dbo.WorkPlaces", "WorkPlaceTypeId", "dbo.WorkPlaceTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkPlaces", "WorkPlaceTypeId", "dbo.WorkPlaceTypes");
            AlterColumn("dbo.WorkPlaceTypes", "Name", c => c.String());
            AlterColumn("dbo.WorkPlaces", "Address", c => c.String());
            AlterColumn("dbo.WorkPlaces", "Tel", c => c.String());
            AlterColumn("dbo.WorkPlaces", "Name", c => c.String());
            AlterColumn("dbo.Individuals", "Mobile", c => c.String(maxLength: 50));
            AlterColumn("dbo.Individuals", "TelDakheli", c => c.String(maxLength: 40));
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 50));
            AddForeignKey("dbo.WorkPlaces", "WorkPlaceTypeId", "dbo.WorkPlaceTypes", "Id", cascadeDelete: true);
        }
    }
}
