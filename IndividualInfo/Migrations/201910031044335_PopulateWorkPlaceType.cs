namespace IndividualInfo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateWorkPlaceType : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO WorkPlaceTypes (Id, Name) VALUES (1, N'شرکت')");
            Sql(@"INSERT INTO WorkPlaceTypes (Id, Name) VALUES (2, N'اداره')");
            Sql(@"INSERT INTO WorkPlaceTypes (Id, Name) VALUES (3, N'سرپرستی')");
            Sql(@"INSERT INTO WorkPlaceTypes (Id, Name) VALUES (4, N'شعبه')");
            Sql(@"INSERT INTO WorkPlaceTypes (Id, Name) VALUES (5, N'غیره')");
        }

        public override void Down()
        {
        }
    }
}
