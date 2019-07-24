using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public enum FormaPagamento
    {
        Dinheiro,CartaoDebito
    }
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public int ? BalcaoId { get; set; }
        public virtual  Balcao Balcao { get; set; }

        public int ? MesaId { get; set; }
        public virtual Mesa Mesa { get; set; }

        public int ? DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}