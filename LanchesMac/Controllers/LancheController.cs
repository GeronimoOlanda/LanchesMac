using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;

        public LancheController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }
        //o nome da view será o nome do metodo aonde tem um return View()
        // o sistema vai procurar por um cshtml chamado List.cshtml
        public IActionResult List()
        {
            ViewData["Titulo"] = "Todos os Lanches";
            ViewData["Data"] = DateTime.Now;

            var lanches = _lanchesRepository.Lanches; //acessando lanches
            var totalLanches = lanches.Count();


            //O Nome da variavel como no exemplo abaixo, a gente cria diretamente no viewBag e chama da view.
            ViewBag.Total = "Total de lanches : ";
            ViewBag.TotalLanches = totalLanches;

            return View(lanches); //retornando para a view os dados.
        }
    }
}
