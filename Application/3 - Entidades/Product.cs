using Application._4___Entidades.Enums;
using Application._6___Validate;

namespace Application._4___Entidades
{
    public class Product : ValidatePorTipo
    {
        public string NomeProduct { get; set; }
        public TipoEnum Tipo { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public Usuario Proprietario { get; set; }

        public Product()
        {}

        public Product(Usuario proprietario , string nomeProduct, TipoEnum tipo, int quantidade, double preco)
        {
            Proprietario = proprietario;
            NomeProduct = nomeProduct;
            Tipo = tipo;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}
