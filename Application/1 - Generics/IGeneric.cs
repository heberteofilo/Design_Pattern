using Application._4___Entidades;
using System.Collections.Generic;

namespace Application._1___Generics
{
    public interface IGeneric<T> where T : class
    {
        List<Product> ConsultaProductsPorNome(string nomeProduto);
        List<Product> ConsultaProductsPorProprietario(string nomeProprietario);
        void AddProduct(Product product);
        string Delete(string nomeProprietario, string nomeProduto);
        List<Product> Listar();
        string Descricao(Product product);
    }
}
