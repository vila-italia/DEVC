using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Balcao
    {
        public int BalcaoId { get; set; }
        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }
        public double  ValorAtual { get; set; }
        public float ValorPago { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public List<Produto> Produtos { get; set; }

        public Balcao()
        {
            Produtos = new List<Produto>();
        }
    }
}