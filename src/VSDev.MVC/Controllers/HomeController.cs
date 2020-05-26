using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VSDev.MVC.ViewModels;

namespace VSDev.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Error/{id:int}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int id)
        {
            ErrorViewModel error = new ErrorViewModel();
            error.StatusCode = id;

            if (id == 500)
            {
                error.Titulo = "Ops! Ocorreu um problema";
                error.Descricao = "Desculpe-nos o transtorno. Estamos trabalhando para corrigir o problema.";
            }
            else if (id == 404)
            {
                error.Titulo = "Ops! Página não encontrada";
                error.Descricao = "A página que você busca não existe. Para dúvidas, entre em contato com o nosso suporte.";
            }
            else if (id == 403)
            {
                error.Titulo = "Ops! Acesso negado";
                error.Descricao = "Você não possui permissão para prosseguir. Para dúvidas, entre em contato com o nosso suporte.";
            }
            else
            {
                return RedirectToAction(nameof(Error), 500);
            }

            return View(error);
        }
    }
}
