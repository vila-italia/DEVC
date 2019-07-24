using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Bebida
    {
        public int BebidaId { get; set; }
        public string BebidaNome { get; set; }
        public double BebidaUltimoPreco { get; set; }
        public double BebidaPrecoMedio { get; set; }
        public double BebidaPrecoFixo { get; set; }
        public double PercentLucro { get; set; }
        public double PrecoSugerido { get; set; }
        public double BebidaAliquota { get; set; }
        public bool Alcoolico { get; set; }
    }
}