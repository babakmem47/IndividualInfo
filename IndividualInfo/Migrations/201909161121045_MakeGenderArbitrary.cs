namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeGenderArbitrary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Individuals", "Gender", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Individuals", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
