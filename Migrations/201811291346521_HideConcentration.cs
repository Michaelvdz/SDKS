namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HideConcentration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "HideConcentrations", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "HideConcentrations");
        }
    }
}
