using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Receita
    {
        public int ReceitaId { get; set; }
        public string Nome { get; set; }
        public double PrecoSugerido { get; set; }
        public double PrecoFixo { get; set; }

        public virtual ICollection<Receita_Ingrediente> Receita_Ingrediente { get; set; }

        public void CalcPreco(ICollection<Receita_Ingrediente> receita_ingredientes)
        {
            PrecoSugerido = 0;
            foreach (var item in receita_ingredientes)
            {
                PrecoSugerido = PrecoSugerido + item.PrecoM;
            }
        }

    }
}