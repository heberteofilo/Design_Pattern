using Application._4___Entidades;
using Application._4___Entidades.Enums;
using Application._5___Repositorio;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Introdução
            /*
            Este é programa com algumas funcionalidades no console que desenvolvi
            para estudar a aplicação de Design Pattern para iniciantes, podendo
            ser escalado futuramente para melhores versões.
            */
            #endregion

            RepositorioProduct repositorioProduct = new RepositorioProduct();
            bool conectado = true;
            string menuOption;
            string nomeProprietario;
            string nomeProduto;
            List<Product> consulta;

            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("--------Aprendendo Design Patterns----------");
                Console.WriteLine("-----------Logistica de Produtos------------");
                Console.WriteLine("1 - Lista de produtos");
                Console.WriteLine("2 - Adicionar produto");
                Console.WriteLine("3 - Remover produto");
                Console.WriteLine("4 - Consultar por nome de produto");
                Console.WriteLine("5 - Consultar por nome de proprietário");
                Console.WriteLine("6 - Sair");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("--------------------------------------------");
                Console.Write("Opção: ");
                menuOption = Console.ReadLine();

                switch (menuOption)
                {

                    case "1":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("--------------Lista de Produto--------------");
                        var result = repositorioProduct.Listar();
                        foreach (var item in result)
                        {
                            Console.WriteLine(repositorioProduct.Descricao(item));
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("-------------Adicionar Produto--------------");
                        Console.Write("Quantos produtos deseja adicionar: ");
                        int quantProduto = int.Parse(Console.ReadLine());
                        for (int i = 1; i <= quantProduto; i++)
                        {
                            Console.Clear();
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("-------------Adicionar Produto--------------");
                            Console.Write($"Nome Proprietário #{i}: ");
                            nomeProprietario = Console.ReadLine();
                            Console.Write($"Nome Produto #{i}: ");
                            nomeProduto = Console.ReadLine();
                            Console.Write($"Preco Produto #{i}: ");
                            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write($"Quantidade Produto #{i}: ");
                            int quantidade = int.Parse(Console.ReadLine());
                            Console.Write($"Tipo Produto (NOVO/SEMI_NOVO/USADO) #{i}: ");
                            TipoEnum tipo = Enum.Parse<TipoEnum>(Console.ReadLine());
                            var data = new Product(new Usuario() { Nome = nomeProprietario }, nomeProduto, tipo, quantidade, preco);
                            repositorioProduct.AddProduct(data);
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("--------------Remover Produto---------------");
                        Console.Write("Qual produdo deseja remover: ");
                        string removerProduct = Console.ReadLine();
                        Console.Write("Qual nome do proprietário: ");
                        nomeProprietario = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine(repositorioProduct.Delete(nomeProprietario, removerProduct));                     
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("---------Consulta Por Nome Produto----------");
                        Console.Write("Qual nome do produto: ");
                        nomeProduto = Console.ReadLine();
                        consulta = repositorioProduct.ConsultaProductsPorNome(nomeProduto);
                        if (consulta.Count > 0)
                        {
                            foreach (var item in consulta)
                            {
                                Console.WriteLine(repositorioProduct.Descricao(item));
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Não encontrado!");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("---------Consulta Por Proprietário----------");
                        Console.Write("Qual nome do proprietário: ");
                        nomeProprietario = Console.ReadLine();
                        consulta = repositorioProduct.ConsultaProductsPorProprietario(nomeProprietario);
                        if (consulta.Count > 0)
                        {
                            foreach (var item in consulta)
                            {
                                Console.WriteLine(repositorioProduct.Descricao(item));
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Não encontrado!");
                            Console.ReadKey();
                        }
                        break;
                    case "6":
                        conectado = false;
                        break;
                    default:
                        break;
                }

            } while (conectado);
           
        }
    }
}
