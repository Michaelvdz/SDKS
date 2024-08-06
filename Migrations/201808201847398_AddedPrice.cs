namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Price", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Price");
        }
    }
}
