namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Receitas", name: "PizzaId", newName: "Pizza_PizzaId");
            RenameIndex(table: "dbo.Receitas", name: "IX_PizzaId", newName: "IX_Pizza_PizzaId");
            AddColumn("dbo.Receitas", "Balcao_BalcaoId", c => c.Int());
            CreateIndex("dbo.Receitas", "Balcao_BalcaoId");
            AddForeignKey("dbo.Receitas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receitas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropIndex("dbo.Receitas", new[] { "Balcao_BalcaoId" });
            DropColumn("dbo.Receitas", "Balcao_BalcaoId");
            RenameIndex(table: "dbo.Receitas", name: "IX_Pizza_PizzaId", newName: "IX_PizzaId");
            RenameColumn(table: "dbo.Receitas", name: "Pizza_PizzaId", newName: "PizzaId");
        }
    }
}
