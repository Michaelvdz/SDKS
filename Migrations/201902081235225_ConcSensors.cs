namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConcSensors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "Conc", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "Conc");
        }
    }
}
