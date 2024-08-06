namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Lost", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Lost");
        }
    }
}
