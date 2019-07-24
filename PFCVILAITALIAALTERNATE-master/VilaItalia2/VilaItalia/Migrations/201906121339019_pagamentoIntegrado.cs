namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pagamentoIntegrado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PagamentoCartaoDebitoes",
                c => new
                    {
                        PagamentoCartaoDebitoId = c.Int(nullable: false, identity: true),
                        Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PagamentoCartaoDebitoId);
            
            CreateTable(
                "dbo.PagamentoDinheiroes",
                c => new
                    {
                        PagamentoDinheiroId = c.Int(nullable: false, identity: true),
                        Troco = c.Single(),
                        Valor = c.Single(),
                    })
                .PrimaryKey(t => t.PagamentoDinheiroId);
            
            CreateTable(
                "dbo.Pagamentoes",
                c => new
                    {
                        PagamentoId = c.Int(nullable: false, identity: true),
                        BalcaoId = c.Int(nullable: false),
                        MesaId = c.Int(nullable: false),
                        DeliveryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PagamentoId)
                .ForeignKey("dbo.Balcaos", t => t.BalcaoId, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId, cascadeDelete: true)
                .ForeignKey("dbo.Mesas", t => t.MesaId, cascadeDelete: true)
                .Index(t => t.BalcaoId)
                .Index(t => t.MesaId)
                .Index(t => t.DeliveryId);
            
            AddColumn("dbo.Deliveries", "ValorTotal", c => c.Double(nullable: false));
            AddColumn("dbo.Mesas", "ValorTotal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamentoes", "MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Pagamentoes", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Pagamentoes", "BalcaoId", "dbo.Balcaos");
            DropIndex("dbo.Pagamentoes", new[] { "DeliveryId" });
            DropIndex("dbo.Pagamentoes", new[] { "MesaId" });
            DropIndex("dbo.Pagamentoes", new[] { "BalcaoId" });
            DropColumn("dbo.Mesas", "ValorTotal");
            DropColumn("dbo.Deliveries", "ValorTotal");
            DropTable("dbo.Pagamentoes");
            DropTable("dbo.PagamentoDinheiroes");
            DropTable("dbo.PagamentoCartaoDebitoes");
        }
    }
}
