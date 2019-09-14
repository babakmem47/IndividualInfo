namespace IndividualInfo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateSemat : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (1, N'کارشناس')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (2, N'کاربر رایانه')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (3, N'معاون دایره')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (4, N'رئیس دایره')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (5, N'متصدی امور بانکی')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (6, N'اپراتور')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (7, N'پیش خدمت')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (8, N'معاون اداره')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (9, N'رئیس اداره')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (10, N'کارمند')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (11, N'رابط')");
            Sql(@"INSERT INTO Semats (Id, Name) VALUES (12, N'غیره')");
        }

        public override void Down()
        {
        }
    }
}
