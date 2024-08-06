namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBrokenField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Broken", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Broken");
        }
    }
}
