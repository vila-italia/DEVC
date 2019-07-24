using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Extra
    {
        public int ExtraId { get; set; }
        public int IngredienteId { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public int IngredienteFixaId { get; set; }
        public virtual IngredienteExtra IngredienteExtra { get; set; }
        public double PrecoM { get; set; }
        public double PrecoG { get; set; }
        public double PrecoF { get; set; }
        public int QuantidadeM { get; set; }
        public int QuantidadeG { get; set; }
        public int QuantidadeF { get; set; }
    }
}