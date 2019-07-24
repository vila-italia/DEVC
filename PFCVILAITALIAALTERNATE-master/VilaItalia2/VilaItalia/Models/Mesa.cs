using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Mesa
    {
        public int MesaId { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public double ValorTotal { get; set; }
        public double ValorPago { get; set; }
    }
}