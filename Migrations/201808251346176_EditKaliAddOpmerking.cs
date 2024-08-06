namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditKaliAddOpmerking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Opmerking", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Opmerking");
        }
    }
}
