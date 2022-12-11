namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountToAR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ARDocuments", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ARDocuments", "Amount");
        }
    }
}
