namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBatteryToCheckUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "battery", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "battery");
        }
    }
}
