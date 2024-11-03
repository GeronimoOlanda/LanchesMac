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
            var lanches = _lanchesRepository.Lanches; //acessando lanches
            return View(lanches); //retornando para a view os dados.
        }
    }
}
