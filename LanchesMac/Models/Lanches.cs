using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanches
    {
        [Key]
        public int LancheId { get; set; }
        [Required(ErrorMessage = "O nome do lanche deve ser informada.")]
        [Display(Name = "Nome do lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no maximo {2}")]
        public string  Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada.")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} Caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no maximo {1} Caracteres")]
        public string  DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Descrição detalhada do lanche deve ser informada.")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada deve ter no maximo {1} caracteres")]
        public string  DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(1,999.99, ErrorMessage = "Preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminha da Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no maximo {1} caracteres")]
        public string  ImagemURL { get; set; }

        [Display(Name = "Caminho da Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no maximo {1} caracteres")]
        public string  ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        //Referencia a Categoria

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
