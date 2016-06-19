namespace ShuaDanPingTai.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppBaseSettings", "FootInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppBaseSettings", "FootInfo");
        }
    }
}
