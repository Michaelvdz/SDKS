namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Details = c.String(unicode: false),
                        Device_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.Device_Id)
                .Index(t => t.Device_Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        SerialNumber = c.String(unicode: false),
                        Bought = c.DateTime(nullable: false, precision: 0),
                        LastCheck = c.DateTime(nullable: false, precision: 0),
                        NextCheck = c.DateTime(nullable: false, precision: 0),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(unicode: false),
                        Contact = c.String(unicode: false),
                        Address1 = c.String(unicode: false),
                        Address2 = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        MobilePhone = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Note = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.CheckUps", "Device_Id", "dbo.Devices");
            DropIndex("dbo.Devices", new[] { "Client_Id" });
            DropIndex("dbo.CheckUps", new[] { "Device_Id" });
            DropTable("dbo.Clients");
            DropTable("dbo.Devices");
            DropTable("dbo.CheckUps");
        }
    }
}
