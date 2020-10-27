using Loja_Virtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Virtual.Controllers
{
    public class ProdutoController : Controller
    {

        public ActionResult Visualizar()
        {

            Produto produto =getProduto();

            return View(produto);
            //return new ContentResult(){ Content = "<h3>Produtor -> Visualizar</h3>", ContentType = "text/html"};
        }

        private Produto getProduto()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Xbox One X",
                Descricao = "Jogue em 4k",
                Valor = 2000.00M
            };
        }
    }
}
