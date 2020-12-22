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
    public class RepositorioProduct
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

    }
}
