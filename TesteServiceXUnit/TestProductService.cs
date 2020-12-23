using Application._5___Services;
using System;
using Xunit;
using System.Linq;

namespace TesteServiceXUnit
{
    public class TestProductService
    {
        private readonly ProductService _ProductService;

        public TestProductService()
        {
            _ProductService = new ProductService();
        }

        [Theory]
        [InlineData("Mesa")] // produto cadastrado inicialmente
        [InlineData("Cadeira")] // produto cadastrado inicialmente
        [InlineData("Armario")] // produto cadastrado inicialmente
        [Trait("ProductService", "TesteConsultaProductsPorNome_ProdutoCadastrado")]
        public void TesteConsultaProductsPorNome_ProdutoCadastrado(string valor)
        {
            // consulta repositorio e repassa o teste para a função
            var data = _ProductService.ConsultaProductsPorNome(valor);
            // recebe o error message
            var errorMessage = data.FirstOrDefault().ErrorMessage;
            // verifica se é nulo ou tem message
            Assert.True(condition: errorMessage == null);
        }

        [Theory]
        [InlineData("Computador")] // produto não cadastrado inicialmente
        [InlineData("Celular")] // produto não cadastrado inicialmente
        [InlineData("Notebook")] // produto não cadastrado inicialmente
        [Trait("ProductService", "TesteConsultaProductsPorNome_ProdutoNaoCadastrado")]
        public void TesteConsultaProductsPorNome_ProdutoNaoCadastrado(string valor)
        {
            // consulta repositorio e repassa o teste para a função
            var data = _ProductService.ConsultaProductsPorNome(valor);
            // recebe o error message
            var errorMessage = data.FirstOrDefault().ErrorMessage;
            // verifica se é nulo ou tem message
            Assert.True(condition: errorMessage != null);
        }

    }
}
