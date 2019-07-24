namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receitas", "Balcao_BalcaoId", c => c.Int());
            CreateIndex("dbo.Receitas", "Balcao_BalcaoId");
            AddForeignKey("dbo.Receitas", "Balcao_BalcaoId", "dbo.Balcaos", "BalcaoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receitas", "Balcao_BalcaoId", "dbo.Balcaos");
            DropIndex("dbo.Receitas", new[] { "Balcao_BalcaoId" });
            DropColumn("dbo.Receitas", "Balcao_BalcaoId");
        }
    }
}
