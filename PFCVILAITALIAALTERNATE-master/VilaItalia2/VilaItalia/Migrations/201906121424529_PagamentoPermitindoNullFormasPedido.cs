namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PagamentoPermitindoNullFormasPedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pagamentoes", "BalcaoId", "dbo.Balcaos");
            DropForeignKey("dbo.Pagamentoes", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Pagamentoes", "MesaId", "dbo.Mesas");
            DropIndex("dbo.Pagamentoes", new[] { "BalcaoId" });
            DropIndex("dbo.Pagamentoes", new[] { "MesaId" });
            DropIndex("dbo.Pagamentoes", new[] { "DeliveryId" });
            AlterColumn("dbo.Pagamentoes", "BalcaoId", c => c.Int());
            AlterColumn("dbo.Pagamentoes", "MesaId", c => c.Int());
            AlterColumn("dbo.Pagamentoes", "DeliveryId", c => c.Int());
            CreateIndex("dbo.Pagamentoes", "BalcaoId");
            CreateIndex("dbo.Pagamentoes", "MesaId");
            CreateIndex("dbo.Pagamentoes", "DeliveryId");
            AddForeignKey("dbo.Pagamentoes", "BalcaoId", "dbo.Balcaos", "BalcaoId");
            AddForeignKey("dbo.Pagamentoes", "DeliveryId", "dbo.Deliveries", "DeliveryId");
            AddForeignKey("dbo.Pagamentoes", "MesaId", "dbo.Mesas", "MesaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamentoes", "MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Pagamentoes", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Pagamentoes", "BalcaoId", "dbo.Balcaos");
            DropIndex("dbo.Pagamentoes", new[] { "DeliveryId" });
            DropIndex("dbo.Pagamentoes", new[] { "MesaId" });
            DropIndex("dbo.Pagamentoes", new[] { "BalcaoId" });
            AlterColumn("dbo.Pagamentoes", "DeliveryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pagamentoes", "MesaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pagamentoes", "BalcaoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pagamentoes", "DeliveryId");
            CreateIndex("dbo.Pagamentoes", "MesaId");
            CreateIndex("dbo.Pagamentoes", "BalcaoId");
            AddForeignKey("dbo.Pagamentoes", "MesaId", "dbo.Mesas", "MesaId", cascadeDelete: true);
            AddForeignKey("dbo.Pagamentoes", "DeliveryId", "dbo.Deliveries", "DeliveryId", cascadeDelete: true);
            AddForeignKey("dbo.Pagamentoes", "BalcaoId", "dbo.Balcaos", "BalcaoId", cascadeDelete: true);
        }
    }
}
