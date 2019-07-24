namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoFuncionandoFiltroContagemFuncionando : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "CPF", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Complemento", c => c.String(maxLength: 255));
            AlterColumn("dbo.Clientes", "Referencia", c => c.String(maxLength: 255));
            AlterColumn("dbo.Clientes", "Observacao", c => c.String(maxLength: 255));
            AlterColumn("dbo.Motoboys", "CPF", c => c.String(nullable: false));
            AlterColumn("dbo.Motoboys", "Referencia", c => c.String(maxLength: 255));
            AlterColumn("dbo.Motoboys", "Observacao", c => c.String(maxLength: 255));
            AlterColumn("dbo.Funcionarios", "CPF", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "Complemento", c => c.String(maxLength: 255));
            AlterColumn("dbo.Funcionarios", "Referencia", c => c.String(maxLength: 255));
            AlterColumn("dbo.Funcionarios", "Observacao", c => c.String(maxLength: 255));
            AlterColumn("dbo.Funcionarios", "Função", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionarios", "Função", c => c.String());
            AlterColumn("dbo.Funcionarios", "Observacao", c => c.String());
            AlterColumn("dbo.Funcionarios", "Referencia", c => c.String());
            AlterColumn("dbo.Funcionarios", "Complemento", c => c.String());
            AlterColumn("dbo.Funcionarios", "CPF", c => c.String());
            AlterColumn("dbo.Motoboys", "Observacao", c => c.String());
            AlterColumn("dbo.Motoboys", "Referencia", c => c.String());
            AlterColumn("dbo.Motoboys", "CPF", c => c.String());
            AlterColumn("dbo.Clientes", "Observacao", c => c.String());
            AlterColumn("dbo.Clientes", "Referencia", c => c.String());
            AlterColumn("dbo.Clientes", "Complemento", c => c.String());
            AlterColumn("dbo.Clientes", "CPF", c => c.String());
        }
    }
}
