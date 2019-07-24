using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class IngredienteExtra
    {
        public int IngredienteExtraId { get; set; }
        public int IngredienteId { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public int ReceitaAlteradaId { get; set; }
        public virtual ReceitaAlterada ReceitaAlterada { get; set; }

    }
}