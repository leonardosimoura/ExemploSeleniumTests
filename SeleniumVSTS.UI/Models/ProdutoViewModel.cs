using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumVSTS.UI.Models
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid ProdutoId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o {0}")]
        public string Produto { get; set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o {0}")]
        [Range(0,9999.99,ErrorMessage = "Deve ser informado um {0} entre {1} e {2}")]
        public decimal Preco { get; set; }
    }
}
