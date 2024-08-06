namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "Number", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Gas", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Reference", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "Reference");
            DropColumn("dbo.CheckUps", "Gas");
            DropColumn("dbo.CheckUps", "Number");
        }
    }
}
