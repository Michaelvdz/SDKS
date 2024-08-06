namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckOptionsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "DateAndTime", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "FilterExtern", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "FilterIntern", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "Latch", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "Krokodillenclip", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "Pomptest", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "Pomprevisie", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "Lamprevisie", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "AutoZero", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckUps", "Nieuw", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "Nieuw");
            DropColumn("dbo.CheckUps", "AutoZero");
            DropColumn("dbo.CheckUps", "Lamprevisie");
            DropColumn("dbo.CheckUps", "Pomprevisie");
            DropColumn("dbo.CheckUps", "Pomptest");
            DropColumn("dbo.CheckUps", "Krokodillenclip");
            DropColumn("dbo.CheckUps", "Latch");
            DropColumn("dbo.CheckUps", "FilterIntern");
            DropColumn("dbo.CheckUps", "FilterExtern");
            DropColumn("dbo.CheckUps", "DateAndTime");
        }
    }
}
