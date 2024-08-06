namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PresentOrNot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Aanwezig", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Aanwezig");
        }
    }
}
