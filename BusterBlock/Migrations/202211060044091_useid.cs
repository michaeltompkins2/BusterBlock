namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
    }
}
