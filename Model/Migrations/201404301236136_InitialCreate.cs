namespace ShuaDanPingTai.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppBaseSettings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IsDisplayValidateCodeWithLogin = c.Boolean(nullable: false),
                        IsDisplayValidateCodeWithRigister = c.Boolean(nullable: false),
                        AppName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppBaseSettings");
        }
    }
}
