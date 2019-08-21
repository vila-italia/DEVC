namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consertandopagamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Balcaos", "ValorAtual", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Balcaos", "ValorAtual");
        }
    }
}
