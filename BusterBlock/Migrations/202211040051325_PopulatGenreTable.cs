namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, GenreCD) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, GenreCD) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres (Id, GenreCD) VALUES (3, 'Horror')");
            Sql("INSERT INTO Genres (Id, GenreCD) VALUES (4, 'Western')");
        }
        
        public override void Down()
        {
        }
    }
}
