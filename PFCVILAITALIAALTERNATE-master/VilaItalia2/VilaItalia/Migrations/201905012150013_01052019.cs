namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01052019 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Balcaos", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Mesas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Balcaos", new[] { "ProdutoId" });
            DropIndex("dbo.Produtoes", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Mesas", new[] { "ProdutoId" });
            CreateTable(
                "dbo.Bebidas",
                c => new
                    {
                        BebidaId = c.Int(nullable: false, identity: true),
                        BebidaNome = c.String(),
                        BebidaUltimoPreco = c.Double(nullable: false),
                        BebidaPrecoMedio = c.Double(nullable: false),
                        BebidaPrecoFixo = c.Double(nullable: false),
                        PercentLucro = c.Double(nullable: false),
                        PrecoSugerido = c.Double(nullable: false),
                        BebidaAliquota = c.Double(nullable: false),
                        Estoque_EstoqueId = c.Int(),
                    })
                .PrimaryKey(t => t.BebidaId)
                .ForeignKey("dbo.Estoques", t => t.Estoque_EstoqueId)
                .Index(t => t.Estoque_EstoqueId);
            
            CreateTable(
                "dbo.Sobremesas",
                c => new
                    {
                        SobremesaId = c.Int(nullable: false, identity: true),
                        SobremesaNome = c.String(),
                        SobremesaUltimoPreco = c.Double(nullable: false),
                        SobremesaPrecoMedio = c.Double(nullable: false),
                        SobremesaPrecoFixo = c.Double(nullable: false),
                        PercentLucro = c.Double(nullable: false),
                        PrecoSugerido = c.Double(nullable: false),
                        SobremesaAliquota = c.Double(nullable: false),
                        Estoque_EstoqueId = c.Int(),
                    })
                .PrimaryKey(t => t.SobremesaId)
                .ForeignKey("dbo.Estoques", t => t.Estoque_EstoqueId)
                .Index(t => t.Estoque_EstoqueId);
            
            AddColumn("dbo.Balcaos", "SobremesaId", c => c.Int());
            AddColumn("dbo.Balcaos", "BebidaId", c => c.Int());
            AddColumn("dbo.Mesas", "SobremesaId", c => c.Int());
            AddColumn("dbo.Mesas", "BebidaId", c => c.Int());
            CreateIndex("dbo.Balcaos", "SobremesaId");
            CreateIndex("dbo.Balcaos", "BebidaId");
            CreateIndex("dbo.Mesas", "SobremesaId");
            CreateIndex("dbo.Mesas", "BebidaId");
            AddForeignKey("dbo.Balcaos", "BebidaId", "dbo.Bebidas", "BebidaId");
            AddForeignKey("dbo.Balcaos", "SobremesaId", "dbo.Sobremesas", "SobremesaId");
            AddForeignKey("dbo.Mesas", "BebidaId", "dbo.Bebidas", "BebidaId");
            AddForeignKey("dbo.Mesas", "SobremesaId", "dbo.Sobremesas", "SobremesaId");
            DropColumn("dbo.Balcaos", "ProdutoId");
            DropColumn("dbo.Mesas", "ProdutoId");
            DropTable("dbo.Produtoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(),
                        ProdutoTipo = c.String(),
                        ProdutoUltimoPreco = c.Double(nullable: false),
                        ProdutoPrecoMedio = c.Double(nullable: false),
                        ProdutoPrecoFixo = c.Double(nullable: false),
                        PercentLucro = c.Double(nullable: false),
                        PrecoSugerido = c.Double(nullable: false),
                        ProdutoAliquota = c.Double(nullable: false),
                        Estoque_EstoqueId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            AddColumn("dbo.Mesas", "ProdutoId", c => c.Int());
            AddColumn("dbo.Balcaos", "ProdutoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Mesas", "SobremesaId", "dbo.Sobremesas");
            DropForeignKey("dbo.Mesas", "BebidaId", "dbo.Bebidas");
            DropForeignKey("dbo.Sobremesas", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Bebidas", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Balcaos", "SobremesaId", "dbo.Sobremesas");
            DropForeignKey("dbo.Balcaos", "BebidaId", "dbo.Bebidas");
            DropIndex("dbo.Mesas", new[] { "BebidaId" });
            DropIndex("dbo.Mesas", new[] { "SobremesaId" });
            DropIndex("dbo.Sobremesas", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Bebidas", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Balcaos", new[] { "BebidaId" });
            DropIndex("dbo.Balcaos", new[] { "SobremesaId" });
            DropColumn("dbo.Mesas", "BebidaId");
            DropColumn("dbo.Mesas", "SobremesaId");
            DropColumn("dbo.Balcaos", "BebidaId");
            DropColumn("dbo.Balcaos", "SobremesaId");
            DropTable("dbo.Sobremesas");
            DropTable("dbo.Bebidas");
            CreateIndex("dbo.Mesas", "ProdutoId");
            CreateIndex("dbo.Produtoes", "Estoque_EstoqueId");
            CreateIndex("dbo.Balcaos", "ProdutoId");
            AddForeignKey("dbo.Mesas", "ProdutoId", "dbo.Produtoes", "ProdutoId");
            AddForeignKey("dbo.Produtoes", "Estoque_EstoqueId", "dbo.Estoques", "EstoqueId");
            AddForeignKey("dbo.Balcaos", "ProdutoId", "dbo.Produtoes", "ProdutoId", cascadeDelete: true);
        }
    }
}
