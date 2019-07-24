using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Sobremesa
    {
       
            public int SobremesaId { get; set; }
            public string SobremesaNome { get; set; }
            public double SobremesaUltimoPreco { get; set; }
            public double SobremesaPrecoMedio { get; set; }
            public double SobremesaPrecoFixo { get; set; }
            public double PercentLucro { get; set; }
            public double PrecoSugerido { get; set; }
            public double SobremesaAliquota { get; set; }
        
    }
}