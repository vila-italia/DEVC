namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReceitaPizza : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Receitas", name: "Pizza_PizzaId", newName: "PizzaId");
            RenameIndex(table: "dbo.Receitas", name: "IX_Pizza_PizzaId", newName: "IX_PizzaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Receitas", name: "IX_PizzaId", newName: "IX_Pizza_PizzaId");
            RenameColumn(table: "dbo.Receitas", name: "PizzaId", newName: "Pizza_PizzaId");
        }
    }
}
