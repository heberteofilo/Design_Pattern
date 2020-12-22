using Application._2___Interfaces;
using Application._4___Entidades;
using System.Collections.Generic;

namespace Application._5___Services._5._1___Interfaces
{
    public interface IProductService : IProduct
    {
        List<Product> ConsultaProductsPorNome(string nomeProduto);
        List<Product> ConsultaProductsPorProprietario(string nomeProprietario);
    }
}
