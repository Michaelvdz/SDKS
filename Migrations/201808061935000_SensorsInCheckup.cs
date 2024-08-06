namespace Service_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SensorsInCheckup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckUps", "Sens1VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens1ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens1NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens2VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens2ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens2NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens3VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens3ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens3NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens4VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens4ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens4NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens5VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens5ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens5NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens6VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens6ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens6NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens7VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens7ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens7NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens8VK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens8ZK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens8NK", c => c.String(unicode: false));
            AddColumn("dbo.CheckUps", "Sens1_Id", c => c.Int());
            AddColumn("dbo.CheckUps", "Sens2_Id", c => c.Int());
            AddColumn("dbo.CheckUps", "Sens3_Id", c => c.Int());
            AddColumn("dbo.CheckUps", "Sens4_Id", c => c.Int());
            AddColumn("dbo.CheckUps", "Sens5_Id", c => c.Int());
            AddColumn("dbo.CheckUps", "Sens6_Id", c => c.Int());
            AddColumn("dbo.CheckUps", "Sens7_Id", c => c.Int());
            AddColumn("dbo.CheckUps", "Sens8_Id", c => c.Int());
            CreateIndex("dbo.CheckUps", "Sens1_Id");
            CreateIndex("dbo.CheckUps", "Sens2_Id");
            CreateIndex("dbo.CheckUps", "Sens3_Id");
            CreateIndex("dbo.CheckUps", "Sens4_Id");
            CreateIndex("dbo.CheckUps", "Sens5_Id");
            CreateIndex("dbo.CheckUps", "Sens6_Id");
            CreateIndex("dbo.CheckUps", "Sens7_Id");
            CreateIndex("dbo.CheckUps", "Sens8_Id");
            AddForeignKey("dbo.CheckUps", "Sens1_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.CheckUps", "Sens2_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.CheckUps", "Sens3_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.CheckUps", "Sens4_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.CheckUps", "Sens5_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.CheckUps", "Sens6_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.CheckUps", "Sens7_Id", "dbo.Sensors", "Id");
            AddForeignKey("dbo.CheckUps", "Sens8_Id", "dbo.Sensors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckUps", "Sens8_Id", "dbo.Sensors");
            DropForeignKey("dbo.CheckUps", "Sens7_Id", "dbo.Sensors");
            DropForeignKey("dbo.CheckUps", "Sens6_Id", "dbo.Sensors");
            DropForeignKey("dbo.CheckUps", "Sens5_Id", "dbo.Sensors");
            DropForeignKey("dbo.CheckUps", "Sens4_Id", "dbo.Sensors");
            DropForeignKey("dbo.CheckUps", "Sens3_Id", "dbo.Sensors");
            DropForeignKey("dbo.CheckUps", "Sens2_Id", "dbo.Sensors");
            DropForeignKey("dbo.CheckUps", "Sens1_Id", "dbo.Sensors");
            DropIndex("dbo.CheckUps", new[] { "Sens8_Id" });
            DropIndex("dbo.CheckUps", new[] { "Sens7_Id" });
            DropIndex("dbo.CheckUps", new[] { "Sens6_Id" });
            DropIndex("dbo.CheckUps", new[] { "Sens5_Id" });
            DropIndex("dbo.CheckUps", new[] { "Sens4_Id" });
            DropIndex("dbo.CheckUps", new[] { "Sens3_Id" });
            DropIndex("dbo.CheckUps", new[] { "Sens2_Id" });
            DropIndex("dbo.CheckUps", new[] { "Sens1_Id" });
            DropColumn("dbo.CheckUps", "Sens8_Id");
            DropColumn("dbo.CheckUps", "Sens7_Id");
            DropColumn("dbo.CheckUps", "Sens6_Id");
            DropColumn("dbo.CheckUps", "Sens5_Id");
            DropColumn("dbo.CheckUps", "Sens4_Id");
            DropColumn("dbo.CheckUps", "Sens3_Id");
            DropColumn("dbo.CheckUps", "Sens2_Id");
            DropColumn("dbo.CheckUps", "Sens1_Id");
            DropColumn("dbo.CheckUps", "Sens8NK");
            DropColumn("dbo.CheckUps", "Sens8ZK");
            DropColumn("dbo.CheckUps", "Sens8VK");
            DropColumn("dbo.CheckUps", "Sens7NK");
            DropColumn("dbo.CheckUps", "Sens7ZK");
            DropColumn("dbo.CheckUps", "Sens7VK");
            DropColumn("dbo.CheckUps", "Sens6NK");
            DropColumn("dbo.CheckUps", "Sens6ZK");
            DropColumn("dbo.CheckUps", "Sens6VK");
            DropColumn("dbo.CheckUps", "Sens5NK");
            DropColumn("dbo.CheckUps", "Sens5ZK");
            DropColumn("dbo.CheckUps", "Sens5VK");
            DropColumn("dbo.CheckUps", "Sens4NK");
            DropColumn("dbo.CheckUps", "Sens4ZK");
            DropColumn("dbo.CheckUps", "Sens4VK");
            DropColumn("dbo.CheckUps", "Sens3NK");
            DropColumn("dbo.CheckUps", "Sens3ZK");
            DropColumn("dbo.CheckUps", "Sens3VK");
            DropColumn("dbo.CheckUps", "Sens2NK");
            DropColumn("dbo.CheckUps", "Sens2ZK");
            DropColumn("dbo.CheckUps", "Sens2VK");
            DropColumn("dbo.CheckUps", "Sens1NK");
            DropColumn("dbo.CheckUps", "Sens1ZK");
            DropColumn("dbo.CheckUps", "Sens1VK");
        }
    }
}
