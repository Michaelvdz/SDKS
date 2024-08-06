namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedO2Sensor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "O2Sensor", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "O2Sensor");
        }
    }
}
