using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class FichaTecnica
    {
        
        public int FichaTecnicaId { get; set; }
        public string FichaNome { get; set; }
        [Display(Name = "Teste")]
        public virtual ICollection<Insumo_Ficha>Insumos_Ficha { get; set; }
        public double PrecoSugerido { get; set; }
        public double PrecoSabor { get; set; }
    }
}