namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valorfixobalcao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Balcaos", "ValorTotal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Balcaos", "ValorTotal");
        }
    }
}
