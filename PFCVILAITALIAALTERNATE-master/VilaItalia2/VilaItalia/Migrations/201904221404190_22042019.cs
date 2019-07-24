namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22042019 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        EstoqueId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.EstoqueId);
            
            CreateTable(
                "dbo.Insumoes",
                c => new
                    {
                        InsumoId = c.Int(nullable: false, identity: true),
                        InsumoNome = c.String(),
                        InsumoQuantidadeBruto = c.Int(nullable: false),
                        InsumoQuantidadeProcessado = c.Int(),
                        InsumoQuantidadeTotal = c.Int(nullable: false),
                        InsumoUltimoPreco = c.Double(nullable: false),
                        InsumoPrecoMedio = c.Double(nullable: false),
                        Estoque_EstoqueId = c.Int(),
                    })
                .PrimaryKey(t => t.InsumoId)
                .ForeignKey("dbo.Estoques", t => t.Estoque_EstoqueId)
                .Index(t => t.Estoque_EstoqueId);
            
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
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Estoques", t => t.Estoque_EstoqueId)
                .Index(t => t.Estoque_EstoqueId);
            
            CreateTable(
                "dbo.FichaTecnicas",
                c => new
                    {
                        FIchaTecnicaId = c.Int(nullable: false, identity: true),
                        FichaNome = c.String(),
                        PrecoSugerido = c.Double(nullable: false),
                        PrecoSabor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FIchaTecnicaId);
            
            CreateTable(
                "dbo.Insumo_Ficha",
                c => new
                    {
                        Insumo_FichaId = c.Int(nullable: false, identity: true),
                        InsumoId = c.Int(nullable: false),
                        FichaTecnicaId = c.Int(nullable: false),
                        PrecoInsumo = c.Double(nullable: false),
                        QuantidadeInsumo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Insumo_FichaId)
                .ForeignKey("dbo.FichaTecnicas", t => t.FichaTecnicaId, cascadeDelete: true)
                .ForeignKey("dbo.Insumoes", t => t.InsumoId, cascadeDelete: true)
                .Index(t => t.InsumoId)
                .Index(t => t.FichaTecnicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insumo_Ficha", "InsumoId", "dbo.Insumoes");
            DropForeignKey("dbo.Insumo_Ficha", "FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.Produtoes", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Insumoes", "Estoque_EstoqueId", "dbo.Estoques");
            DropIndex("dbo.Insumo_Ficha", new[] { "FichaTecnicaId" });
            DropIndex("dbo.Insumo_Ficha", new[] { "InsumoId" });
            DropIndex("dbo.Produtoes", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Insumoes", new[] { "Estoque_EstoqueId" });
            DropTable("dbo.Insumo_Ficha");
            DropTable("dbo.FichaTecnicas");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Insumoes");
            DropTable("dbo.Estoques");
        }
    }
}
