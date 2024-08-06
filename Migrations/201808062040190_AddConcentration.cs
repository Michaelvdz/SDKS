namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConcentration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "Sens1C", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens2C", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens3C", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens4C", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens5C", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens6C", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens7C", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens8C", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "Sens8C");
            DropColumn("dbo.CheckUps", "Sens7C");
            DropColumn("dbo.CheckUps", "Sens6C");
            DropColumn("dbo.CheckUps", "Sens5C");
            DropColumn("dbo.CheckUps", "Sens4C");
            DropColumn("dbo.CheckUps", "Sens3C");
            DropColumn("dbo.CheckUps", "Sens2C");
            DropColumn("dbo.CheckUps", "Sens1C");
        }
    }
}
