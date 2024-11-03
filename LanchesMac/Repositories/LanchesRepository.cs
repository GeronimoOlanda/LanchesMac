using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LanchesRepository : ILanchesRepository
    {
        private readonly AppDbContext _appDbContext;

        public LanchesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Lanches> Lanches => _appDbContext.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanches> LanchesFavoritos => _appDbContext.Lanches.
                                    Where(l => l.IsLanchePreferido).
                                    Include(c => c.Categoria);

        public Lanches GetLanchesById(int lancheId)
        {
            return _appDbContext.Lanches.FirstOrDefault(x => x.LancheId == lancheId);
        }
    }
}
