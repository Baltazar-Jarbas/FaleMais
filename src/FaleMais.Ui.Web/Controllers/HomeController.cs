using Microsoft.AspNetCore.Mvc;
using FaleMais.Ui.Web.Models;
using FaleMais.Domain.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FaleMais.Ui.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITarifaService _service;

        public HomeController(ITarifaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            PrepareForm();
            return View();
        }

        [HttpPost]
        public IActionResult Index(CalculoModel request)
        {
            PrepareForm();
            request.Valor = _service.SimularPreco(request.Origem, request.Destino, request.Duracao);
            request.ValorFaleMais = _service.SimularPrecoFaleMais(request.Origem, request.Destino, request.Duracao, request.PlanoId);
            return View(request);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("sistema-indisponivel")]
        public IActionResult SystemUnavailable()
        {
            var modelErro = new ErrorViewModel
            {
                Message = "O sistema está temporariamente indisponível, isto pode ocorrer em momentos de sobrecarga de usuários.",
                Title = "Sistema indisponível.",
                ErroCode = 500
            };

            return View("Error", modelErro);
        }


        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Message = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Title = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Message =
                    "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Title = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Message = "Você não tem permissão para fazer isto.";
                modelErro.Title = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
        
        private void PrepareForm()
        {
            ViewBag.Locais = _service.GetLocais().Select(x => new SelectListItem { Value = x, Text = x}).OrderBy(x => x.Text);
            ViewBag.Planos = _service.GetPlanos().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });
        }
    }
}
