using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja_Virtual.Libraries.Email;
using Loja_Virtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Loja_Virtual.Database;

namespace Loja_Virtual.Controllers
{
    public class HomeController : Controller
    {
        public LojaVirtualContext _banco;
        public HomeController(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var news = new NewsletterEmail() { Email = "fezao@gmail.com" };
            //return View(news);
         

            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsletterEmail newsletter)
        {
            //TODO- validações
            if (ModelState.IsValid)
            {
                //TODO - adição no banco de dados
                _banco.NewsletterEmails.Add(newsletter);
                _banco.SaveChanges();

                TempData["MSG_S"] = "E-mail cadastrado! Enviaremos promoções você, fique atento as novidades";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }


           
           
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {

            try
            {
                Contato contato = new Contato();
                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                var ListaMensagem = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid =  Validator.TryValidateObject(contato, contexto, ListaMensagem, true);


                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviada com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in ListaMensagem)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }

               

            }
            catch (Exception e){
                ViewData["MSG_E"] = "Opps! Tivemos um erro, tente novamente mais tarde";

                //TODO - implementar log
            }

            return View("Contato");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
