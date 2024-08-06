namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletableDevs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Tdelete", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Devices", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Deleted");
            DropColumn("dbo.Devices", "Tdelete");
        }
    }
}
