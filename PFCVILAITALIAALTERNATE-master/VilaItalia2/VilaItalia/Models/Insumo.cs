using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Insumo
    {
        public int InsumoId { get; set; }
        public string InsumoNome { get; set; }
        public int InsumoQuantidadeBruto { get; set; }
        public int? InsumoQuantidadeProcessado { get; set; }
        public int InsumoQuantidadeTotal { get; set; }
        public double InsumoUltimoPreco { get; set; }
        public double InsumoPrecoMedio { get; set; }
    }
}