namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PizzaEmPedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deliveries", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Deliveries", new[] { "ClienteId" });
            AlterColumn("dbo.Deliveries", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Deliveries", "ClienteId");
            AddForeignKey("dbo.Deliveries", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Deliveries", new[] { "ClienteId" });
            AlterColumn("dbo.Deliveries", "ClienteId", c => c.Int());
            CreateIndex("dbo.Deliveries", "ClienteId");
            AddForeignKey("dbo.Deliveries", "ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
