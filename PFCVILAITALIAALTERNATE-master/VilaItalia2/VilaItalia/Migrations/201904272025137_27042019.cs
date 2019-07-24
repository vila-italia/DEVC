namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27042019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insumo_Ficha", "Contem", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insumo_Ficha", "Contem");
        }
    }
}
