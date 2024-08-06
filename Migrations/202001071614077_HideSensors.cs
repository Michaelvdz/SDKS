namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HideSensors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "HideAlarm1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "HideAlarm2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "HideAlarm3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "HideAlarm4", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "HideAlarm5", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "HideAlarm6", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "HideAlarm7", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "HideAlarm8", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "HideAlarm8");
            DropColumn("dbo.Devices", "HideAlarm7");
            DropColumn("dbo.Devices", "HideAlarm6");
            DropColumn("dbo.Devices", "HideAlarm5");
            DropColumn("dbo.Devices", "HideAlarm4");
            DropColumn("dbo.Devices", "HideAlarm3");
            DropColumn("dbo.Devices", "HideAlarm2");
            DropColumn("dbo.Devices", "HideAlarm1");
        }
    }
}
