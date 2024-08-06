namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlarms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "Alarm1", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm2", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm3", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm4", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm5", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm6", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm7", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm8", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm1", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm2", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm3", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm4", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm5", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm6", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm7", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm8", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Alarm8");
            DropColumn("dbo.Devices", "Alarm7");
            DropColumn("dbo.Devices", "Alarm6");
            DropColumn("dbo.Devices", "Alarm5");
            DropColumn("dbo.Devices", "Alarm4");
            DropColumn("dbo.Devices", "Alarm3");
            DropColumn("dbo.Devices", "Alarm2");
            DropColumn("dbo.Devices", "Alarm1");
            DropColumn("dbo.CheckUps", "Alarm8");
            DropColumn("dbo.CheckUps", "Alarm7");
            DropColumn("dbo.CheckUps", "Alarm6");
            DropColumn("dbo.CheckUps", "Alarm5");
            DropColumn("dbo.CheckUps", "Alarm4");
            DropColumn("dbo.CheckUps", "Alarm3");
            DropColumn("dbo.CheckUps", "Alarm2");
            DropColumn("dbo.CheckUps", "Alarm1");
        }
    }
}
