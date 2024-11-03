using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        //Acessa a tabela categorias e retorna a coleção para a gente.
        //retorna todas as  categorias da tabela categoria.
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
