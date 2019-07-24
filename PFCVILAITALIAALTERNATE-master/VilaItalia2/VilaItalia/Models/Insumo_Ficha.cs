using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Insumo_Ficha
    {
        public int Insumo_FichaId { get; set; }
        public int InsumoId { get; set; }
        public virtual Insumo Insumo { get; set; }
        public int FichaTecnicaId { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
        public double PrecoInsumo { get; set; }
        public int QuantidadeInsumo { get; set; }
        public bool Contem { get; set; }
    }
}