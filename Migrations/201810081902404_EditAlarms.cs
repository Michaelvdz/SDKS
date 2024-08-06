namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAlarms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Alarm1L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm1H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm1S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm1T", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm2L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm2H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm2S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm2T", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm3L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm3H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm3S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm3T", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm4L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm4H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm4S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm4T", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm5L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm5H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm5S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm5T", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm6L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm6H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm6S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm6T", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm7L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm7H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm7S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm7T", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm8L", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm8H", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm8S", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm8T", c => c.String(unicode: false));
            DropColumn("dbo.Devices", "Alarm1");
            DropColumn("dbo.Devices", "Alarm2");
            DropColumn("dbo.Devices", "Alarm3");
            DropColumn("dbo.Devices", "Alarm4");
            DropColumn("dbo.Devices", "Alarm5");
            DropColumn("dbo.Devices", "Alarm6");
            DropColumn("dbo.Devices", "Alarm7");
            DropColumn("dbo.Devices", "Alarm8");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "Alarm8", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm7", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm6", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm5", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm4", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm3", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm2", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Alarm1", c => c.String(unicode: false));
            DropColumn("dbo.Devices", "Alarm8T");
            DropColumn("dbo.Devices", "Alarm8S");
            DropColumn("dbo.Devices", "Alarm8H");
            DropColumn("dbo.Devices", "Alarm8L");
            DropColumn("dbo.Devices", "Alarm7T");
            DropColumn("dbo.Devices", "Alarm7S");
            DropColumn("dbo.Devices", "Alarm7H");
            DropColumn("dbo.Devices", "Alarm7L");
            DropColumn("dbo.Devices", "Alarm6T");
            DropColumn("dbo.Devices", "Alarm6S");
            DropColumn("dbo.Devices", "Alarm6H");
            DropColumn("dbo.Devices", "Alarm6L");
            DropColumn("dbo.Devices", "Alarm5T");
            DropColumn("dbo.Devices", "Alarm5S");
            DropColumn("dbo.Devices", "Alarm5H");
            DropColumn("dbo.Devices", "Alarm5L");
            DropColumn("dbo.Devices", "Alarm4T");
            DropColumn("dbo.Devices", "Alarm4S");
            DropColumn("dbo.Devices", "Alarm4H");
            DropColumn("dbo.Devices", "Alarm4L");
            DropColumn("dbo.Devices", "Alarm3T");
            DropColumn("dbo.Devices", "Alarm3S");
            DropColumn("dbo.Devices", "Alarm3H");
            DropColumn("dbo.Devices", "Alarm3L");
            DropColumn("dbo.Devices", "Alarm2T");
            DropColumn("dbo.Devices", "Alarm2S");
            DropColumn("dbo.Devices", "Alarm2H");
            DropColumn("dbo.Devices", "Alarm2L");
            DropColumn("dbo.Devices", "Alarm1T");
            DropColumn("dbo.Devices", "Alarm1S");
            DropColumn("dbo.Devices", "Alarm1H");
            DropColumn("dbo.Devices", "Alarm1L");
        }
    }
}
