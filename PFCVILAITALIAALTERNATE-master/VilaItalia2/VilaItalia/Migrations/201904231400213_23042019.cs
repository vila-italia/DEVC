namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23042019 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balcaos",
                c => new
                    {
                        BalcaoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(),
                        FichaTecnicaId = c.Int(),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BalcaoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.FichaTecnicas", t => t.FichaTecnicaId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.FichaTecnicaId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Mesas",
                c => new
                    {
                        MesaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(),
                        FichaTecnicaId = c.Int(),
                        ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.MesaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.FichaTecnicas", t => t.FichaTecnicaId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId)
                .Index(t => t.ClienteId)
                .Index(t => t.FichaTecnicaId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mesas", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Mesas", "FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.Mesas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Balcaos", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Balcaos", "FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.Balcaos", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Mesas", new[] { "ProdutoId" });
            DropIndex("dbo.Mesas", new[] { "FichaTecnicaId" });
            DropIndex("dbo.Mesas", new[] { "ClienteId" });
            DropIndex("dbo.Balcaos", new[] { "ProdutoId" });
            DropIndex("dbo.Balcaos", new[] { "FichaTecnicaId" });
            DropIndex("dbo.Balcaos", new[] { "ClienteId" });
            DropTable("dbo.Mesas");
            DropTable("dbo.Balcaos");
        }
    }
}
