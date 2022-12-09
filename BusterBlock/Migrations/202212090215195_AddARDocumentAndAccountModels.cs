namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddARDocumentAndAccountModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountCD = c.String(maxLength: 10),
                        IsCashAccount = c.Boolean(nullable: false),
                        Payable = c.Boolean(nullable: false),
                        Receivable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.AccountCD, unique: true);
            
            CreateTable(
                "dbo.ARDocuments",
                c => new
                    {
                        DocType = c.String(nullable: false, maxLength: 1),
                        RefNbr = c.String(nullable: false, maxLength: 10),
                        CustomerId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 1),
                        DateEntered = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocType, t.RefNbr })
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.AccountId);
            
            AddColumn("dbo.Rentals", "DocRefNbr", c => c.String());
            AddColumn("dbo.Rentals", "Paid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ARDocuments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ARDocuments", "AccountId", "dbo.Accounts");
            DropIndex("dbo.ARDocuments", new[] { "AccountId" });
            DropIndex("dbo.ARDocuments", new[] { "CustomerId" });
            DropIndex("dbo.Accounts", new[] { "AccountCD" });
            DropColumn("dbo.Rentals", "Paid");
            DropColumn("dbo.Rentals", "DocRefNbr");
            DropTable("dbo.ARDocuments");
            DropTable("dbo.Accounts");
        }
    }
}
