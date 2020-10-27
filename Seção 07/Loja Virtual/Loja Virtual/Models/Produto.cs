using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Virtual.Models
{
    public class Produto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

    }
}
