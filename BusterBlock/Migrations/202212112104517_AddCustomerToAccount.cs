namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerToAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "CustomerId", c => c.Int());
            CreateIndex("dbo.Accounts", "CustomerId");
            AddForeignKey("dbo.Accounts", "CustomerId", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Accounts", new[] { "CustomerId" });
            DropColumn("dbo.Accounts", "CustomerId");
        }
    }
}
