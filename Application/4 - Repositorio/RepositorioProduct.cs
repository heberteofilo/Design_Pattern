using Application._1___Generics;
using Application._2___Interfaces;
using Application._4___Entidades;
using Application._4___Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace Application._5___Repositorio
{
    public class RepositorioProduct : IGeneric<Product>, IProduct
    {
        public List<Product> Products { get; set; }

        public RepositorioProduct()
        {
            Products = new List<Product>()
            {
                new Product(new Usuario(){ Nome = "Rodrigo" }, "Mesa", Enum.Parse<TipoEnum>("USADO"),  2,  120.0),
                new Product(new Usuario(){ Nome = "Fabio" }, "Mesa", Enum.Parse<TipoEnum>("NOVO"),  1,  320.0),
                new Product(new Usuario(){ Nome = "Jose" }, "Cadeira", Enum.Parse<TipoEnum>("SEMI_NOVO"),  5,  70.0),
                new Product(new Usuario(){ Nome = "Ana" }, "Armario", Enum.Parse<TipoEnum>("USADO"),  7,  520.0),
                new Product(new Usuario(){ Nome = "Carlos" }, "Mesa", Enum.Parse<TipoEnum>("SEMI_NOVO"),  4,  220.0),
            };
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public List<Product> ConsultaProductsPorNome(string nomeProduto)
        {
            var data = Products.Select(p => p).Where(p => p.NomeProduct == nomeProduto).ToList();
            return data;
        }

        public List<Product> ConsultaProductsPorProprietario(string nomeProprietario)
        {
            var data = Products.Select(p => p).Where(p => p.Proprietario.Nome == nomeProprietario).ToList();
            return data;
        }

        public string Delete(string nomeProprietario, string nomeProduto)
        {
            var product = Products.Find(p =>
                p.Proprietario.Nome == nomeProprietario &&
                p.NomeProduct == nomeProduto);
            if (product != null)
            {
                Products.Remove(product);
                return "Finalizado com sucesso!";
            } else
            {
                return "Não encontrado!";
            }    
        }

        public List<Product> Listar()
        {
            var data = Products.ToList();
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
