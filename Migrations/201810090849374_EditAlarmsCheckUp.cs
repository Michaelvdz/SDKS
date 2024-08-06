namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAlarmsCheckUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "Alarm1L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm1H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm1S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm1T", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm2L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm2H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm2S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm2T", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm3L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm3H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm3S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm3T", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm4L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm4H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm4S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm4T", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm5L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm5H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm5S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm5T", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm6L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm6H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm6S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm6T", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm7L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm7H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm7S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm7T", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm8L", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm8H", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm8S", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm8T", c => c.String(unicode: false));
            DropColumn("dbo.CheckUps", "Alarm1");
            DropColumn("dbo.CheckUps", "Alarm2");
            DropColumn("dbo.CheckUps", "Alarm3");
            DropColumn("dbo.CheckUps", "Alarm4");
            DropColumn("dbo.CheckUps", "Alarm5");
            DropColumn("dbo.CheckUps", "Alarm6");
            DropColumn("dbo.CheckUps", "Alarm7");
            DropColumn("dbo.CheckUps", "Alarm8");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckUps", "Alarm8", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm7", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm6", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm5", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm4", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm3", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm2", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Alarm1", c => c.String(unicode: false));
            DropColumn("dbo.CheckUps", "Alarm8T");
            DropColumn("dbo.CheckUps", "Alarm8S");
            DropColumn("dbo.CheckUps", "Alarm8H");
            DropColumn("dbo.CheckUps", "Alarm8L");
            DropColumn("dbo.CheckUps", "Alarm7T");
            DropColumn("dbo.CheckUps", "Alarm7S");
            DropColumn("dbo.CheckUps", "Alarm7H");
            DropColumn("dbo.CheckUps", "Alarm7L");
            DropColumn("dbo.CheckUps", "Alarm6T");
            DropColumn("dbo.CheckUps", "Alarm6S");
            DropColumn("dbo.CheckUps", "Alarm6H");
            DropColumn("dbo.CheckUps", "Alarm6L");
            DropColumn("dbo.CheckUps", "Alarm5T");
            DropColumn("dbo.CheckUps", "Alarm5S");
            DropColumn("dbo.CheckUps", "Alarm5H");
            DropColumn("dbo.CheckUps", "Alarm5L");
            DropColumn("dbo.CheckUps", "Alarm4T");
            DropColumn("dbo.CheckUps", "Alarm4S");
            DropColumn("dbo.CheckUps", "Alarm4H");
            DropColumn("dbo.CheckUps", "Alarm4L");
            DropColumn("dbo.CheckUps", "Alarm3T");
            DropColumn("dbo.CheckUps", "Alarm3S");
            DropColumn("dbo.CheckUps", "Alarm3H");
            DropColumn("dbo.CheckUps", "Alarm3L");
            DropColumn("dbo.CheckUps", "Alarm2T");
            DropColumn("dbo.CheckUps", "Alarm2S");
            DropColumn("dbo.CheckUps", "Alarm2H");
            DropColumn("dbo.CheckUps", "Alarm2L");
            DropColumn("dbo.CheckUps", "Alarm1T");
            DropColumn("dbo.CheckUps", "Alarm1S");
            DropColumn("dbo.CheckUps", "Alarm1H");
            DropColumn("dbo.CheckUps", "Alarm1L");
        }
    }
}
