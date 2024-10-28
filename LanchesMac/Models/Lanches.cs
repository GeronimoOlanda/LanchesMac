namespace LanchesMac.Models
{
    public class Lanches
    {
        public int LancheId { get; set; }
        public string  Nome { get; set; }
        public string  DescricaoCurta { get; set; }
        public string  DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string  ImagemURL { get; set; }
        public string  ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        //Referencia a Categoria

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
