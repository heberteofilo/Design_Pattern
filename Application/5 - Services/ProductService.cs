using Application._4___Entidades;
using Application._5___Repositorio;
using Application._5___Services._5._1___Interfaces;
using Application._6___Validate;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Application._5___Services
{
    public class ProductService : IProductService
    {
        private readonly RepositorioProduct _RepositorioProduct;
        private readonly ValidatePorTipo _ValidatePorTipo;

        public ProductService()
        {}

        public ProductService(RepositorioProduct RepositorioProduct, ValidatePorTipo ValidatePorTipo)
        {
            _RepositorioProduct = RepositorioProduct;
            _ValidatePorTipo = ValidatePorTipo;
        }

        public string AddProduct(Product product)
        {
            var validarPreco = _ValidatePorTipo.ValidadorDeDouble(product.Preco);
            if (validarPreco)
            { 
                _RepositorioProduct.Products.Add(product);
                return "Produto adicionado com sucesso!";
            }
            return "Valor deve ser maior do que 0.";
        }

        public List<Product> ConsultaProductsPorNome(string nomeProduto)
        {
            var validarNomeProduct = _ValidatePorTipo.ValidadorDeString(nomeProduto);
            if (validarNomeProduct)
            {
                var data = _RepositorioProduct.Products.Select(p => p).Where(p => p.NomeProduct == nomeProduto).ToList();
                return data;
            }

            List<Product> errorProduct = new List<Product>();
            errorProduct.Add(new Product() { ErrorMessage = _ValidatePorTipo.ValidarPorTipos.FirstOrDefault(p => p.ErrorMessage == "Preencha o campo devidamente.").ErrorMessage });
            return errorProduct;
        }

        public List<Product> ConsultaProductsPorProprietario(string nomeProprietario)
        {
            var data = _RepositorioProduct.Products.Select(p => p).Where(p => p.Proprietario.Nome == nomeProprietario).ToList();
            return data;
        }

        public string Delete(string nomeProprietario, string nomeProduto)
        {
            var product = _RepositorioProduct.Products.Find(p =>
                p.Proprietario.Nome == nomeProprietario &&
                p.NomeProduct == nomeProduto);
            if (product != null)
            {
                _RepositorioProduct.Products.Remove(product);
                return "Finalizado com sucesso!";
            }
            else
            {
                return "Não encontrado!";
            }
        }

        public List<Product> Listar()
        {
            var data = _RepositorioProduct.Products.ToList();
            return data;
        }

        public string Descricao(Product product)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.Append($"Proprietário:{product.Proprietario.Nome} -");
            sb.Append($"- Produto:{product.NomeProduct} ");
            sb.Append($"- Preço:{product.Preco.ToString("F2", CultureInfo.InvariantCulture)} ");
            sb.Append($"- Tipo:{product.Tipo} ");
            sb.Append($"- Quantidade:{product.Quantidade} ");

            return sb.ToString();
        }
    }
}
