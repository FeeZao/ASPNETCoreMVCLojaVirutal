using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Loja_Virtual.Libraries.Lang;

namespace Loja_Virtual.Models
{
    public class Contato
    {
        [Required(ErrorMessageResourceType = typeof(), ErrorMessageResourceName = "")]
        [MinLength(4)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Texto { get; set; }
    }
}
