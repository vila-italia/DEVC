using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class ReceitaAlterada
    {
        public int ReceitaAlteradaId { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public virtual ICollection<IngredienteExtra> Extra { get; set; }
    }
}