﻿using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _context; 

        public CarrinhoCompra(AppDbContext context)
        {
            this._context = context;
        }

        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }


        //obtem os carrinhos criados pelo cliente na sessão ao acesso ao site
        public static CarrinhoCompra GetCarrinho (IServiceProvider services)
        {
            //define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            AppDbContext context = services.GetService<AppDbContext>();

            //obtem ou gera o id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId,
            };
        
        }


        //incluindo itens no carrinho
        public void AdicionarAoCarrinho(Lanches lanche)
        {
            var carrinhoCompraItem = _context.carrinhoCompraItens.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId &&
                s.CarrinhoCompraId == CarrinhoCompraId);

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _context.carrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _context.SaveChanges();
        }
    }
}
