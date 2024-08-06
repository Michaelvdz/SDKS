namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckListForCertificatesUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "Sinterfilter", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "Frontcover", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "A1NA", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "A1A", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "SwitchOffNA", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "FW", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "FW");
            DropColumn("dbo.CheckUps", "SwitchOffNA");
            DropColumn("dbo.CheckUps", "A1A");
            DropColumn("dbo.CheckUps", "A1NA");
            DropColumn("dbo.CheckUps", "Frontcover");
            DropColumn("dbo.CheckUps", "Sinterfilter");
        }
    }
}
