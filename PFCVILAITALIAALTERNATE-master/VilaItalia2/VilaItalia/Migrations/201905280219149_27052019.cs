namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27052019 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receita_Ingrediente", "FichaTecnica_FichaTecnicaId", "dbo.FichaTecnicas");
            DropForeignKey("dbo.FichaTecnicas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropForeignKey("dbo.FichaTecnicas", "Mesa_MesaId", "dbo.Mesas");
            DropIndex("dbo.FichaTecnicas", new[] { "Balcao_BalcaoId" });
            DropIndex("dbo.FichaTecnicas", new[] { "Mesa_MesaId" });
            DropIndex("dbo.Receita_Ingrediente", new[] { "FichaTecnica_FichaTecnicaId" });
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        PizzaId = c.Int(nullable: false, identity: true),
                        Tamanho = c.String(),
                        BalcaoId = c.Int(),
                        MesaId = c.Int(),
                        DeliveryId = c.Int(),
                    })
                .PrimaryKey(t => t.PizzaId)
                .ForeignKey("dbo.Balcaos", t => t.BalcaoId)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId)
                .ForeignKey("dbo.Mesas", t => t.MesaId)
                .Index(t => t.BalcaoId)
                .Index(t => t.MesaId)
                .Index(t => t.DeliveryId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(),
                        MotoboyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.Motoboys", t => t.MotoboyId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.MotoboyId);
            
            AddColumn("dbo.Receitas", "Pizza_PizzaId", c => c.Int());
            AddColumn("dbo.Produtoes", "BalcaoId", c => c.Int());
            AddColumn("dbo.Produtoes", "MesaId", c => c.Int());
            AddColumn("dbo.Produtoes", "DeliveryId", c => c.Int());
            AlterColumn("dbo.Produtoes", "Tipo", c => c.String());
            CreateIndex("dbo.Produtoes", "BalcaoId");
            CreateIndex("dbo.Produtoes", "MesaId");
            CreateIndex("dbo.Produtoes", "DeliveryId");
            CreateIndex("dbo.Receitas", "Pizza_PizzaId");
            AddForeignKey("dbo.Produtoes", "BalcaoId", "dbo.Balcaos", "BalcaoId");
            AddForeignKey("dbo.Produtoes", "DeliveryId", "dbo.Deliveries", "DeliveryId");
            AddForeignKey("dbo.Produtoes", "MesaId", "dbo.Mesas", "MesaId");
            AddForeignKey("dbo.Receitas", "Pizza_PizzaId", "dbo.Pizzas", "PizzaId");
            DropColumn("dbo.Receita_Ingrediente", "FichaTecnica_FichaTecnicaId");
            DropTable("dbo.FichaTecnicas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FichaTecnicas",
                c => new
                    {
                        FichaTecnicaId = c.Int(nullable: false, identity: true),
                        FichaNome = c.String(),
                        PrecoSugerido = c.Double(nullable: false),
                        PrecoSabor = c.Double(nullable: false),
                        Balcao_BalcaoId = c.Int(),
                        Mesa_MesaId = c.Int(),
                    })
                .PrimaryKey(t => t.FichaTecnicaId);
            
            AddColumn("dbo.Receita_Ingrediente", "FichaTecnica_FichaTecnicaId", c => c.Int());
            DropForeignKey("dbo.Receitas", "Pizza_PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.Produtoes", "MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Pizzas", "MesaId", "dbo.Mesas");
            DropForeignKey("dbo.Produtoes", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Produtoes", "BalcaoId", "dbo.Balcaos");
            DropForeignKey("dbo.Pizzas", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Deliveries", "MotoboyId", "dbo.Motoboys");
            DropForeignKey("dbo.Deliveries", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Pizzas", "BalcaoId", "dbo.Balcaos");
            DropIndex("dbo.Receitas", new[] { "Pizza_PizzaId" });
            DropIndex("dbo.Produtoes", new[] { "DeliveryId" });
            DropIndex("dbo.Produtoes", new[] { "MesaId" });
            DropIndex("dbo.Produtoes", new[] { "BalcaoId" });
            DropIndex("dbo.Deliveries", new[] { "MotoboyId" });
            DropIndex("dbo.Deliveries", new[] { "ClienteId" });
            DropIndex("dbo.Pizzas", new[] { "DeliveryId" });
            DropIndex("dbo.Pizzas", new[] { "MesaId" });
            DropIndex("dbo.Pizzas", new[] { "BalcaoId" });
            AlterColumn("dbo.Produtoes", "Tipo", c => c.Int(nullable: false));
            DropColumn("dbo.Produtoes", "DeliveryId");
            DropColumn("dbo.Produtoes", "MesaId");
            DropColumn("dbo.Produtoes", "BalcaoId");
            DropColumn("dbo.Receitas", "Pizza_PizzaId");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Pizzas");
            CreateIndex("dbo.Receita_Ingrediente", "FichaTecnica_FichaTecnicaId");
            CreateIndex("dbo.FichaTecnicas", "Mesa_MesaId");
            CreateIndex("dbo.FichaTecnicas", "Balcao_BalcaoId");
            AddForeignKey("dbo.FichaTecnicas", "Mesa_MesaId", "dbo.Mesas", "MesaId");
            AddForeignKey("dbo.FichaTecnicas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
            AddForeignKey("dbo.Receita_Ingrediente", "FichaTecnica_FichaTecnicaId", "dbo.FichaTecnicas", "FichaTecnicaId");
        }
    }
}
