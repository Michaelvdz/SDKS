namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNextCheck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "NextDate", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckUps", "NextDate");
        }
    }
}
