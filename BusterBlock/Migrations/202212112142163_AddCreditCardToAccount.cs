namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreditCardToAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "CardNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "CardNumber");
        }
    }
}