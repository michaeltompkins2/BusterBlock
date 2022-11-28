namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Int(nullable: false));

            Sql("UPDATE Movies SET AvailableStock = StockCount");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}