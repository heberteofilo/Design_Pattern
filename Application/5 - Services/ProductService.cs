using Application._2___Interfaces;
using Application._4___Entidades;
using Application._5___Repositorio;
using Application._5___Services._5._1___Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Application._5___Services
{
    public class ProductService : IProductService
    {
        private readonly RepositorioProduct _RepositorioProduct;

        public ProductService(RepositorioProduct RepositorioProduct)
        {
            _RepositorioProduct = RepositorioProduct;
        }

        public void AddProduct(Product product)
        {
            _RepositorioProduct.Products.Add(product);
        }

        public List<Product> ConsultaProductsPorNome(string nomeProduto)
        {
            var data = _RepositorioProduct.Products.Select(p => p).Where(p => p.NomeProduct == nomeProduto).ToList();
            return data;
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
