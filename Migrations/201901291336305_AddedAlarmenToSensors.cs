namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlarmenToSensors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "Laag", c => c.String(unicode: false));
            AddColumn("dbo.Sensors", "Hoog", c => c.String(unicode: false));
            AddColumn("dbo.Sensors", "Stel", c => c.String(unicode: false));
            AddColumn("dbo.Sensors", "Twa", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "Twa");
            DropColumn("dbo.Sensors", "Stel");
            DropColumn("dbo.Sensors", "Hoog");
            DropColumn("dbo.Sensors", "Laag");
        }
    }
}
