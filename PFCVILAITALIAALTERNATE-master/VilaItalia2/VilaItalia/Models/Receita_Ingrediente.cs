using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Receita_Ingrediente
    {
        public int Receita_IngredienteId { get; set; }
        public int IngredienteId { get; set; }
        public int ReceitaId { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Receita Receita { get; set; }
        public double PrecoM { get; set; }
        public double PrecoG { get; set; }
        public double PrecoF { get; set; }
        public int QuantidadeM { get; set; }
        public int QuantidadeG { get; set; }
        public int QuantidadeF { get; set; }

    }
}