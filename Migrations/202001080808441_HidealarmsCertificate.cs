namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HidealarmsCertificate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "HideAlarm1", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "HideAlarm2", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "HideAlarm3", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "HideAlarm4", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "HideAlarm5", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "HideAlarm6", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "HideAlarm7", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "HideAlarm8", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "HideAlarm8");
            DropColumn("dbo.CheckUps", "HideAlarm7");
            DropColumn("dbo.CheckUps", "HideAlarm6");
            DropColumn("dbo.CheckUps", "HideAlarm5");
            DropColumn("dbo.CheckUps", "HideAlarm4");
            DropColumn("dbo.CheckUps", "HideAlarm3");
            DropColumn("dbo.CheckUps", "HideAlarm2");
            DropColumn("dbo.CheckUps", "HideAlarm1");
        }
    }
}
