namespace ShuaDanPingTai.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppBaseSettings", "IsAllowLoginAndRegister", c => c.Boolean(nullable: false));
            DropColumn("dbo.AppBaseSettings", "IsAllowLogin");
            DropColumn("dbo.AppBaseSettings", "IsAllowRegister");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppBaseSettings", "IsAllowRegister", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppBaseSettings", "IsAllowLogin", c => c.Boolean(nullable: false));
            DropColumn("dbo.AppBaseSettings", "IsAllowLoginAndRegister");
        }
    }
}
