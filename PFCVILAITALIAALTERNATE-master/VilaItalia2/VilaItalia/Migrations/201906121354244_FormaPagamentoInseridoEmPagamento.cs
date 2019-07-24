namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormaPagamentoInseridoEmPagamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagamentoes", "FormaPagamento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagamentoes", "FormaPagamento");
        }
    }
}
