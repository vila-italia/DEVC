namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoSessions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String());
            DropColumn("dbo.Funcionarios", "Senha");
        }
    }
}
