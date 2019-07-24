namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00520191 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bebidas", "Alcoolico", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bebidas", "Alcoolico");
        }
    }
}
