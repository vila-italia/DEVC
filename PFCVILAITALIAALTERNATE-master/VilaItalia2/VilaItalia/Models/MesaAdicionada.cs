using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class MesaAdicionada
    {
        public int MesaAdicionadaId { get; set; }
        public string Nome { get; set; }
        public bool Disponibilidade { get; set; }
        public virtual ICollection<Mesa> Mesas { get; set; }
        public MesaAdicionada()
        {
            Disponibilidade = true;
    }
    }
  
}