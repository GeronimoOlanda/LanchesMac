using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ILanchesRepository 
    {
        //somente leitura
        IEnumerable<Lanches> Lanches { get; }

        IEnumerable<Lanches> LanchesFavoritos { get; }

        Lanches GetLanchesById(int lancheId);
    }
}
