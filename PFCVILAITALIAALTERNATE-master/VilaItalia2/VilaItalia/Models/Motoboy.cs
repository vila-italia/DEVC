using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Motoboy
    {
        public int MotoboyId { get; set; }

        [RegularExpression(@"^[aA-zZ]+((\s[aA-zZ]+)+)?$", ErrorMessage = "Números não são permitidos no nome.")]
        public string Nome { get; set; }

        public string Telefone { get; set; }
        public string Celular { get; set; }

        [Required(ErrorMessage = "Informe seu CPF")]
        public string CPF { get; set; }
        [DisplayName("Dia")]
        [Range(1, 31, ErrorMessage = "Informe um dia válido")]
        public int Dia_Aniversario { get; set; }
        [DisplayName("Mês")]
        [Range(1, 12, ErrorMessage = "Informe um mês válido")]
        public int Mes_Aniversario { get; set; }
        [DisplayName("Ano")]
        public int Ano_Aniversario { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }

        [StringLength(255, MinimumLength = 1)]
        public string Referencia { get; set; }

        [StringLength(255, MinimumLength = 1)]
        public string Observacao { get; set; }
        
        public int numerCnh { get; set; }
    }
}