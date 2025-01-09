using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _context; 


        public CarrinhoCompra(AppDbContext context)
        {
            this._context = context;
        }

        public string CarrinhoCOmpraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

    }
}
