using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Tamanho { get; set; }
        public  List<Receita>Sabores { get; set; }
       // public virtual List<Receita> Receitas { get; set; }
        public int? BalcaoId { get; set; }
        public virtual Balcao Balcao { get; set; }
        public int? MesaId { get; set; }
        public virtual Mesa Mesa { get; set; }
        public int? DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }

        public Pizza()
        {
            Sabores = new List<Receita>();
        }

    }
}