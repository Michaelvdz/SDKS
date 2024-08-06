namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KalibratiemaandNaarInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "KalibratieMaand", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "KalibratieMaand", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
