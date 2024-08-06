namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreOptionsToCheck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "SensorVervangen", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "ExtaOpmerkingen", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "ExtaOpmerkingen");
            DropColumn("dbo.CheckUps", "SensorVervangen");
        }
    }
}
