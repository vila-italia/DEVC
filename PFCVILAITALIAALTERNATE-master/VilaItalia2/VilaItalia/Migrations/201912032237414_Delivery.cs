namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delivery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deliveries", "ValorAtual", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deliveries", "ValorAtual");
        }
    }
}
