using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Estoque
    {
        public int EstoqueId { get; set; }
        public virtual ICollection<Ingrediente> Ingredientes { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}