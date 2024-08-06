namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNoService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "NoS", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "NoS");
        }
    }
}
