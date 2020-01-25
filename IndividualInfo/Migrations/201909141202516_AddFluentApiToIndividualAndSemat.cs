namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFluentApiToIndividualAndSemat : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Individuals", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Individuals", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String(maxLength: 15));
            AlterColumn("dbo.Individuals", "TelDakheli", c => c.String(maxLength: 4));
            AlterColumn("dbo.Individuals", "Mobile", c => c.String(maxLength: 14));
            AlterColumn("dbo.Semats", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Semats", "Name", c => c.String());
            AlterColumn("dbo.Individuals", "Mobile", c => c.String());
            AlterColumn("dbo.Individuals", "TelDakheli", c => c.String());
            AlterColumn("dbo.Individuals", "TelDirect", c => c.String());
            AlterColumn("dbo.Individuals", "LastName", c => c.String());
            //AlterColumn("dbo.Individuals", "Name", c => c.String());
        }
    }
}
