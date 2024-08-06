namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HideAlarms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "HideAlarms", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "HideAlarms");
        }
    }
}
