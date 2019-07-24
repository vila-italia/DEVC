using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public enum Medida { Grama, Mililitro, Unidade }
    public class Ingrediente
    {
        public int IngredienteId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Processado { get; set; }
        public int Total { get; set; }
        public double UltimoPreco { get; set; }
        public double PrecoMedio { get; set; }
        public Medida Medida { get; set; }
        public virtual ICollection<Receita_Ingrediente> Receita_Ingrediente { get; set; }
    }
}