namespace ShuaDanPingTai.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAllowLoginANDIsAllowRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppBaseSettings", "IsDisplayValidateCodeWithRegister", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppBaseSettings", "IsAllowLogin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppBaseSettings", "IsAllowRegister", c => c.Boolean(nullable: false));
            DropColumn("dbo.AppBaseSettings", "IsDisplayValidateCodeWithRigister");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppBaseSettings", "IsDisplayValidateCodeWithRigister", c => c.Boolean(nullable: false));
            DropColumn("dbo.AppBaseSettings", "IsAllowRegister");
            DropColumn("dbo.AppBaseSettings", "IsAllowLogin");
            DropColumn("dbo.AppBaseSettings", "IsDisplayValidateCodeWithRegister");
        }
    }
}
