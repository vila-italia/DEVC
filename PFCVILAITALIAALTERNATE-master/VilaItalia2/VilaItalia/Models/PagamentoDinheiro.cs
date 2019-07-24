using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class PagamentoDinheiro
    {
        public int PagamentoDinheiroId { get; set; }
        public float ? Troco { get; set; }
        public float ? Valor { get; set; }
    }
}