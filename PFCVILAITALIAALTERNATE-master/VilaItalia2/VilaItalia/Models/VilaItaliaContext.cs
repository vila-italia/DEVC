using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class VilaItaliaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VilaItaliaContext() : base("name=VilaItaliaContext")
        {
        }

        public System.Data.Entity.DbSet<VilaItalia.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Funcionario> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Motoboy> Motoboys { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Estoque> Estoques { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Balcao> Balcaos { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Mesa> Mesas { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Ingrediente> Ingredientes { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Receita> Receitas { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Receita_Ingrediente> Receita_Ingrediente { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Delivery> Deliveries { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Pizza> Pizzas { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.Pagamento> Pagamentoes { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.PagamentoCartaoDebito> PagamentoCartaoDebitoes { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.PagamentoDinheiro> PagamentoDinheiroes { get; set; }

        public System.Data.Entity.DbSet<VilaItalia.Models.MesaAdicionada> MesaAdicionadas { get; set; }
    }
}
