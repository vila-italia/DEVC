namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovasClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bebidas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropForeignKey("dbo.Insumo_Ficha", "FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.Insumo_Ficha", "InsumoId", "dbo.Insumoes");
            DropForeignKey("dbo.Sobremesas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropForeignKey("dbo.Bebidas", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Insumoes", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Sobremesas", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Bebidas", "Mesa_MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Sobremesas", "Mesa_MesaId", "dbo.Mesas");
            DropIndex("dbo.Bebidas", new[] { "Balcao_BalcaoId" });
            DropIndex("dbo.Bebidas", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Bebidas", new[] { "Mesa_MesaId" });
            DropIndex("dbo.Insumo_Ficha", new[] { "InsumoId" });
            DropIndex("dbo.Insumo_Ficha", new[] { "FichaTecnicaId" });
            DropIndex("dbo.Insumoes", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Sobremesas", new[] { "Balcao_BalcaoId" });
            DropIndex("dbo.Sobremesas", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Sobremesas", new[] { "Mesa_MesaId" });
            CreateTable(
                "dbo.Receita_Ingrediente",
                c => new
                    {
                        Receita_IngredienteId = c.Int(nullable: false, identity: true),
                        IngredienteId = c.Int(nullable: false),
                        ReceitaId = c.Int(nullable: false),
                        PrecoM = c.Double(nullable: false),
                        PrecoG = c.Double(nullable: false),
                        PrecoF = c.Double(nullable: false),
                        QuantidadeM = c.Int(nullable: false),
                        QuantidadeG = c.Int(nullable: false),
                        QuantidadeF = c.Int(nullable: false),
                        FichaTecnica_FichaTecnicaId = c.Int(),
                    })
                .PrimaryKey(t => t.Receita_IngredienteId)
                .ForeignKey("dbo.Ingredientes", t => t.IngredienteId, cascadeDelete: true)
                .ForeignKey("dbo.Receitas", t => t.ReceitaId, cascadeDelete: true)
                .ForeignKey("dbo.FichaTecnicas", t => t.FichaTecnica_FichaTecnicaId)
                .Index(t => t.IngredienteId)
                .Index(t => t.ReceitaId)
                .Index(t => t.FichaTecnica_FichaTecnicaId);
            
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        IngredienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Processado = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        UltimoPreco = c.Double(nullable: false),
                        PrecoMedio = c.Double(nullable: false),
                        Medida = c.Int(nullable: false),
                        Estoque_EstoqueId = c.Int(),
                    })
                .PrimaryKey(t => t.IngredienteId)
                .ForeignKey("dbo.Estoques", t => t.Estoque_EstoqueId)
                .Index(t => t.Estoque_EstoqueId);
            
            CreateTable(
                "dbo.Receitas",
                c => new
                    {
                        ReceitaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PrecoSugerido = c.Double(nullable: false),
                        PrecoFixo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReceitaId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Quantidade = c.Int(nullable: false),
                        PrecoCompra = c.Double(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                        PrecoMedio = c.Double(nullable: false),
                        PercentLucro = c.Double(nullable: false),
                        PrecoSugerido = c.Double(nullable: false),
                        Aliquota = c.Double(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Medida = c.Int(nullable: false),
                        Estoque_EstoqueId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Estoques", t => t.Estoque_EstoqueId)
                .Index(t => t.Estoque_EstoqueId);
            
            DropTable("dbo.Bebidas");
            DropTable("dbo.Insumo_Ficha");
            DropTable("dbo.Insumoes");
            DropTable("dbo.Sobremesas");
        }
        
        public override void Down()
        {
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
                        Balcao_BalcaoId = c.Int(),
                        Estoque_EstoqueId = c.Int(),
                        Mesa_MesaId = c.Int(),
                    })
                .PrimaryKey(t => t.SobremesaId);
            
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
                .PrimaryKey(t => t.InsumoId);
            
            CreateTable(
                "dbo.Insumo_Ficha",
                c => new
                    {
                        Insumo_FichaId = c.Int(nullable: false, identity: true),
                        InsumoId = c.Int(nullable: false),
                        FichaTecnicaId = c.Int(nullable: false),
                        PrecoInsumo = c.Double(nullable: false),
                        QuantidadeInsumo = c.Int(nullable: false),
                        Contem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Insumo_FichaId);
            
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
                        Alcoolico = c.Boolean(nullable: false),
                        Balcao_BalcaoId = c.Int(),
                        Estoque_EstoqueId = c.Int(),
                        Mesa_MesaId = c.Int(),
                    })
                .PrimaryKey(t => t.BebidaId);
            
            DropForeignKey("dbo.Produtoes", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Ingredientes", "Estoque_EstoqueId", "dbo.Estoques");
            DropForeignKey("dbo.Receita_Ingrediente", "FichaTecnica_FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.Receita_Ingrediente", "ReceitaId", "dbo.Receitas");
            DropForeignKey("dbo.Receita_Ingrediente", "IngredienteId", "dbo.Ingredientes");
            DropIndex("dbo.Produtoes", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Ingredientes", new[] { "Estoque_EstoqueId" });
            DropIndex("dbo.Receita_Ingrediente", new[] { "FichaTecnica_FichaTecnicaId" });
            DropIndex("dbo.Receita_Ingrediente", new[] { "ReceitaId" });
            DropIndex("dbo.Receita_Ingrediente", new[] { "IngredienteId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Receitas");
            DropTable("dbo.Ingredientes");
            DropTable("dbo.Receita_Ingrediente");
            CreateIndex("dbo.Sobremesas", "Mesa_MesaId");
            CreateIndex("dbo.Sobremesas", "Estoque_EstoqueId");
            CreateIndex("dbo.Sobremesas", "Balcao_BalcaoId");
            CreateIndex("dbo.Insumoes", "Estoque_EstoqueId");
            CreateIndex("dbo.Insumo_Ficha", "FichaTecnicaId");
            CreateIndex("dbo.Insumo_Ficha", "InsumoId");
            CreateIndex("dbo.Bebidas", "Mesa_MesaId");
            CreateIndex("dbo.Bebidas", "Estoque_EstoqueId");
            CreateIndex("dbo.Bebidas", "Balcao_BalcaoId");
            AddForeignKey("dbo.Sobremesas", "Mesa_MesaId", "dbo.Mesas", "MesaId");
            AddForeignKey("dbo.Bebidas", "Mesa_MesaId", "dbo.Mesas", "MesaId");
            AddForeignKey("dbo.Sobremesas", "Estoque_EstoqueId", "dbo.Estoques", "EstoqueId");
            AddForeignKey("dbo.Insumoes", "Estoque_EstoqueId", "dbo.Estoques", "EstoqueId");
            AddForeignKey("dbo.Bebidas", "Estoque_EstoqueId", "dbo.Estoques", "EstoqueId");
            AddForeignKey("dbo.Sobremesas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
            AddForeignKey("dbo.Insumo_Ficha", "InsumoId", "dbo.Insumoes", "InsumoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumo_Ficha", "FichaTecnicaId", "dbo.FichaTecnicas", "FichaTecnicaId", cascadeDelete: true);
            AddForeignKey("dbo.Bebidas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
        }
    }
}
