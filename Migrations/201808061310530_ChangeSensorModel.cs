namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSensorModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Range = c.String(unicode: false),
                        Resolution = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CheckUps", "Note", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "BoughtByUs", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "Note", c => c.String(unicode: false));
            AddColumn("dbo.Devices", "Sensor1_Id", c => c.Int());
            AddColumn("dbo.Devices", "Sensor2_Id", c => c.Int());
            AddColumn("dbo.Devices", "Sensor3_Id", c => c.Int());
            AddColumn("dbo.Devices", "Sensor4_Id", c => c.Int());
            AddColumn("dbo.Devices", "Sensor5_Id", c => c.Int());
            AddColumn("dbo.Devices", "Sensor6_Id", c => c.Int());
            AddColumn("dbo.Devices", "Sensor7_Id", c => c.Int());
            AddColumn("dbo.Devices", "Sensor8_Id", c => c.Int());
            CreateIndex("dbo.Devices", "Sensor1_Id");
            CreateIndex("dbo.Devices", "Sensor2_Id");
            CreateIndex("dbo.Devices", "Sensor3_Id");
            CreateIndex("dbo.Devices", "Sensor4_Id");
            CreateIndex("dbo.Devices", "Sensor5_Id");
            CreateIndex("dbo.Devices", "Sensor6_Id");
            CreateIndex("dbo.Devices", "Sensor7_Id");
            CreateIndex("dbo.Devices", "Sensor8_Id");
            AddForeignKey("dbo.Devices", "Sensor1_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Devices", "Sensor2_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Devices", "Sensor3_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Devices", "Sensor4_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Devices", "Sensor5_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Devices", "Sensor6_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Devices", "Sensor7_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Devices", "Sensor8_Id", "dbo.Sensors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "Sensor8_Id", "dbo.Sensors");
            DropForeignKey("dbo.Devices", "Sensor7_Id", "dbo.Sensors");
            DropForeignKey("dbo.Devices", "Sensor6_Id", "dbo.Sensors");
            DropForeignKey("dbo.Devices", "Sensor5_Id", "dbo.Sensors");
            DropForeignKey("dbo.Devices", "Sensor4_Id", "dbo.Sensors");
            DropForeignKey("dbo.Devices", "Sensor3_Id", "dbo.Sensors");
            DropForeignKey("dbo.Devices", "Sensor2_Id", "dbo.Sensors");
            DropForeignKey("dbo.Devices", "Sensor1_Id", "dbo.Sensors");
            DropIndex("dbo.Devices", new[] { "Sensor8_Id" });
            DropIndex("dbo.Devices", new[] { "Sensor7_Id" });
            DropIndex("dbo.Devices", new[] { "Sensor6_Id" });
            DropIndex("dbo.Devices", new[] { "Sensor5_Id" });
            DropIndex("dbo.Devices", new[] { "Sensor4_Id" });
            DropIndex("dbo.Devices", new[] { "Sensor3_Id" });
            DropIndex("dbo.Devices", new[] { "Sensor2_Id" });
            DropIndex("dbo.Devices", new[] { "Sensor1_Id" });
            DropColumn("dbo.Devices", "Sensor8_Id");
            DropColumn("dbo.Devices", "Sensor7_Id");
            DropColumn("dbo.Devices", "Sensor6_Id");
            DropColumn("dbo.Devices", "Sensor5_Id");
            DropColumn("dbo.Devices", "Sensor4_Id");
            DropColumn("dbo.Devices", "Sensor3_Id");
            DropColumn("dbo.Devices", "Sensor2_Id");
            DropColumn("dbo.Devices", "Sensor1_Id");
            DropColumn("dbo.Devices", "Note");
            DropColumn("dbo.Devices", "BoughtByUs");
            DropColumn("dbo.CheckUps", "Note");
            DropTable("dbo.Sensors");
        }
    }
}
