using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class PopularLanches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, DescricaoCurta, DescricaoDetalhada, EmEstoque, ImagemThumbnailUrl, ImagemURL, IsLanchePreferido, Nome, Preco) VALUES " +
                "(1, 'Pão, Hamburguer, ovo, batata palha, salsicha', 'Delicioso pao de hamburguer', 1, 'https://www.minhareceita.com.br/app/uploads/2021/02/shutterstock_1490753552-scaled.jpg', 'https://www.minhareceita.com.br/app/uploads/2021/02/shutterstock_1490753552-scaled.jpg', 0, 'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, DescricaoCurta, DescricaoDetalhada, EmEstoque, ImagemThumbnailUrl, ImagemURL, IsLanchePreferido, Nome, Preco) VALUES " +
               "(2, 'Pão, Hamburguer, ovo, batata palha, salsicha', 'Delicioso pao de hamburguer', 2, 'https://www.minhareceita.com.br/app/uploads/2021/02/shutterstock_1490753552-scaled.jpg', 'https://www.minhareceita.com.br/app/uploads/2021/02/shutterstock_1490753552-scaled.jpg', 0, 'Cheese Salada', 12.50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
