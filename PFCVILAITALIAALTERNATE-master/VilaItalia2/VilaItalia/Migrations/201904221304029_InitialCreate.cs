namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Celular = c.String(),
                        CPF = c.String(),
                        Dia_Aniversario = c.Int(nullable: false),
                        Mes_Aniversario = c.Int(nullable: false),
                        Email = c.String(),
                        CEP = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        Cidade = c.String(),
                        Complemento = c.String(),
                        Referencia = c.String(),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Celular = c.String(),
                        CPF = c.String(),
                        Dia_Aniversario = c.Int(nullable: false),
                        Mes_Aniversario = c.Int(nullable: false),
                        Ano_Aniversario = c.Int(nullable: false),
                        Email = c.String(),
                        CEP = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        Cidade = c.String(),
                        Complemento = c.String(),
                        Referencia = c.String(),
                        Observacao = c.String(),
                        Função = c.String(),
                    })
                .PrimaryKey(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Motoboys",
                c => new
                    {
                        MotoboyId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Celular = c.String(),
                        CPF = c.String(),
                        Dia_Aniversario = c.Int(nullable: false),
                        Mes_Aniversario = c.Int(nullable: false),
                        Ano_Aniversario = c.Int(nullable: false),
                        Email = c.String(),
                        CEP = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        Cidade = c.String(),
                        Referencia = c.String(),
                        Observacao = c.String(),
                        numerCnh = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MotoboyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Motoboys");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Clientes");
        }
    }
}
