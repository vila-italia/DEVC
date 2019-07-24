namespace VilaItalia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetodosPagamentosApenasEmBalcao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Balcaos", "ValorPago", c => c.Single(nullable: false));
            AddColumn("dbo.Deliveries", "ValorPago", c => c.Double(nullable: false));
            AddColumn("dbo.Mesas", "ValorPago", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mesas", "ValorPago");
            DropColumn("dbo.Deliveries", "ValorPago");
            DropColumn("dbo.Balcaos", "ValorPago");
        }
    }
}
