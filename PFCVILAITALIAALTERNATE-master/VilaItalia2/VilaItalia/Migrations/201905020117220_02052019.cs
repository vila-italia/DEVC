namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02052019 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Balcaos", "BebidaId", "dbo.Bebidas");
            DropForeignKey("dbo.Balcaos", "FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.Balcaos", "SobremesaId", "dbo.Sobremesas");
            DropForeignKey("dbo.Mesas", "BebidaId", "dbo.Bebidas");
            DropForeignKey("dbo.Mesas", "FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.Mesas", "SobremesaId", "dbo.Sobremesas");
            DropIndex("dbo.Balcaos", new[] { "FichaTecnicaId" });
            DropIndex("dbo.Balcaos", new[] { "SobremesaId" });
            DropIndex("dbo.Balcaos", new[] { "BebidaId" });
            DropIndex("dbo.Mesas", new[] { "FichaTecnicaId" });
            DropIndex("dbo.Mesas", new[] { "SobremesaId" });
            DropIndex("dbo.Mesas", new[] { "BebidaId" });
            AddColumn("dbo.Bebidas", "Balcao_BalcaoId", c => c.Int());
            AddColumn("dbo.Bebidas", "Mesa_MesaId", c => c.Int());
            AddColumn("dbo.FichaTecnicas", "Balcao_BalcaoId", c => c.Int());
            AddColumn("dbo.FichaTecnicas", "Mesa_MesaId", c => c.Int());
            AddColumn("dbo.Sobremesas", "Balcao_BalcaoId", c => c.Int());
            AddColumn("dbo.Sobremesas", "Mesa_MesaId", c => c.Int());
            CreateIndex("dbo.Bebidas", "Balcao_BalcaoId");
            CreateIndex("dbo.Bebidas", "Mesa_MesaId");
            CreateIndex("dbo.FichaTecnicas", "Balcao_BalcaoId");
            CreateIndex("dbo.FichaTecnicas", "Mesa_MesaId");
            CreateIndex("dbo.Sobremesas", "Balcao_BalcaoId");
            CreateIndex("dbo.Sobremesas", "Mesa_MesaId");
            AddForeignKey("dbo.Bebidas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
            AddForeignKey("dbo.FichaTecnicas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
            AddForeignKey("dbo.Sobremesas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
            AddForeignKey("dbo.Bebidas", "Mesa_MesaId", "dbo.Mesas", "MesaId");
            AddForeignKey("dbo.FichaTecnicas", "Mesa_MesaId", "dbo.Mesas", "MesaId");
            AddForeignKey("dbo.Sobremesas", "Mesa_MesaId", "dbo.Mesas", "MesaId");
            DropColumn("dbo.Balcaos", "FichaTecnicaId");
            DropColumn("dbo.Balcaos", "SobremesaId");
            DropColumn("dbo.Balcaos", "BebidaId");
            DropColumn("dbo.Mesas", "FichaTecnicaId");
            DropColumn("dbo.Mesas", "SobremesaId");
            DropColumn("dbo.Mesas", "BebidaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mesas", "BebidaId", c => c.Int());
            AddColumn("dbo.Mesas", "SobremesaId", c => c.Int());
            AddColumn("dbo.Mesas", "FichaTecnicaId", c => c.Int());
            AddColumn("dbo.Balcaos", "BebidaId", c => c.Int());
            AddColumn("dbo.Balcaos", "SobremesaId", c => c.Int());
            AddColumn("dbo.Balcaos", "FichaTecnicaId", c => c.Int());
            DropForeignKey("dbo.Sobremesas", "Mesa_MesaId", "dbo.Mesas");
            DropForeignKey("dbo.FichaTecnicas", "Mesa_MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Bebidas", "Mesa_MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Sobremesas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropForeignKey("dbo.FichaTecnicas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropForeignKey("dbo.Bebidas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropIndex("dbo.Sobremesas", new[] { "Mesa_MesaId" });
            DropIndex("dbo.Sobremesas", new[] { "Balcao_BalcaoId" });
            DropIndex("dbo.FichaTecnicas", new[] { "Mesa_MesaId" });
            DropIndex("dbo.FichaTecnicas", new[] { "Balcao_BalcaoId" });
            DropIndex("dbo.Bebidas", new[] { "Mesa_MesaId" });
            DropIndex("dbo.Bebidas", new[] { "Balcao_BalcaoId" });
            DropColumn("dbo.Sobremesas", "Mesa_MesaId");
            DropColumn("dbo.Sobremesas", "Balcao_BalcaoId");
            DropColumn("dbo.FichaTecnicas", "Mesa_MesaId");
            DropColumn("dbo.FichaTecnicas", "Balcao_BalcaoId");
            DropColumn("dbo.Bebidas", "Mesa_MesaId");
            DropColumn("dbo.Bebidas", "Balcao_BalcaoId");
            CreateIndex("dbo.Mesas", "BebidaId");
            CreateIndex("dbo.Mesas", "SobremesaId");
            CreateIndex("dbo.Mesas", "FichaTecnicaId");
            CreateIndex("dbo.Balcaos", "BebidaId");
            CreateIndex("dbo.Balcaos", "SobremesaId");
            CreateIndex("dbo.Balcaos", "FichaTecnicaId");
            AddForeignKey("dbo.Mesas", "SobremesaId", "dbo.Sobremesas", "SobremesaId");
            AddForeignKey("dbo.Mesas", "FichaTecnicaId", "dbo.FichaTecnicas", "FichaTecnicaId");
            AddForeignKey("dbo.Mesas", "BebidaId", "dbo.Bebidas", "BebidaId");
            AddForeignKey("dbo.Balcaos", "SobremesaId", "dbo.Sobremesas", "SobremesaId");
            AddForeignKey("dbo.Balcaos", "FichaTecnicaId", "dbo.FichaTecnicas", "FichaTecnicaId");
            AddForeignKey("dbo.Balcaos", "BebidaId", "dbo.Bebidas", "BebidaId");
        }
    }
}
