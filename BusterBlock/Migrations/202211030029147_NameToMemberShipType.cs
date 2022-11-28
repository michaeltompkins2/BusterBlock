namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameToMemberShipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
