namespace BusterBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'94d6cb92-8faf-4b80-b970-e91e9ef9baeb', N'admin@vidly.com', 0, N'AO8kma6xNM/ukyB5Z0lnrpcLLk5ZlQ/iLTgL5CGaD8efktnIxi0oPL/Hs9p/2xvx3g==', N'349afd94-b3f1-4154-8d22-4c3e29dbf276', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a1440229-5fa8-4033-b3f3-233dc67779dc', N'guest@vidly.com', 0, N'ABe1DeiILCcBBzx9gyeXJYRMXzu9Tl57TXFOF0H91D9kmB0v5Hlju12CBkMGlasIvA==', N'a58527ff-4d33-440c-99c8-ca82b9f59542', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5e4d2aac-4a59-4dd3-ac35-5fc0c8975970', 'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'94d6cb92-8faf-4b80-b970-e91e9ef9baeb', N'5e4d2aac-4a59-4dd3-ac35-5fc0c8975970')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
