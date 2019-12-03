namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmesa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MesaAdicionadas",
                c => new
                    {
                        MesaAdicionadaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Disponibilidade = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MesaAdicionadaId);
            
            AddColumn("dbo.Mesas", "ValorAtual", c => c.Double(nullable: false));
            AddColumn("dbo.Mesas", "MesaAdicionadaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Mesas", "MesaAdicionadaId");
            AddForeignKey("dbo.Mesas", "MesaAdicionadaId", "dbo.MesaAdicionadas", "MesaAdicionadaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mesas", "MesaAdicionadaId", "dbo.MesaAdicionadas");
            DropIndex("dbo.Mesas", new[] { "MesaAdicionadaId" });
            DropColumn("dbo.Mesas", "MesaAdicionadaId");
            DropColumn("dbo.Mesas", "ValorAtual");
            DropTable("dbo.MesaAdicionadas");
        }
    }
}
