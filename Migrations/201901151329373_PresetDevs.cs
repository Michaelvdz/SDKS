namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PresetDevs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PresetDevs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Reference = c.String(unicode: false),
                        Note = c.String(unicode: false),
                        Opmerking = c.String(unicode: false),
                        Price = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PresetDevs");
        }
    }
}
