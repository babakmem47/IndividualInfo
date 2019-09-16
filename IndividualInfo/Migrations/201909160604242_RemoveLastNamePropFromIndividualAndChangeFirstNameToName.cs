namespace IndividualInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLastNamePropFromIndividualAndChangeFirstNameToName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Individuals", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Individuals", "Description", c => c.String(maxLength: 250));
            DropColumn("dbo.Individuals", "FirstName");
            DropColumn("dbo.Individuals", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Individuals", "LastName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Individuals", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Individuals", "Description", c => c.String());
            DropColumn("dbo.Individuals", "Name");
        }
    }
}
