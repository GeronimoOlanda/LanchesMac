using LanchesMac.Models;

namespace LanchesMac.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanches> lanches { get; set; }
        public string CategoriaAtual { get; set; }


    }
}
