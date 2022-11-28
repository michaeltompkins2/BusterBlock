namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDriversLicenseToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DriversLicenseNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DriversLicenseNumber");
        }
    }
}
