using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        //IEumerable permite somente leitura e iterações simples
        IEnumerable<Categoria> Categorias { get; }
    }
}
