namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientAddedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "KalibratieMaand", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "KalibratieMaand");
        }
    }
}
