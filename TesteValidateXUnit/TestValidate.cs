using Application._6___Validate;
using Xunit;

namespace TestService
{
    public class TestValidate
    {

        private readonly ValidatePorTipo _ValidatePorTipo;

        public TestValidate()
        {
            _ValidatePorTipo = new ValidatePorTipo();
        }

        [Theory]
        [InlineData("Entrada")]
        [InlineData("A")]
        [InlineData("123")]
        [Trait("ValidatePorTipo", "ValidadorDeStringTeste_Valido")]
        public void ValidadorDeStringTeste_Valido(string valor)
        {
            Assert.True(condition: _ValidatePorTipo.ValidadorDeString(valor));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("ValidatePorTipo", "ValidadorDeStringTeste_Invalido")]
        public void ValidadorDeStringTeste_Invalido(string valor)
        {
            Assert.False(condition: _ValidatePorTipo.ValidadorDeString(valor));
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-10.4)]
        [InlineData(0)]
        [InlineData(-0.1)]
        [Trait("ValidatePorTipo", "ValidadorDeDoubleTeste_Invalido")]
        public void ValidadorDeDoubleTeste_Invalido(double valor)
        {
            Assert.False(condition: _ValidatePorTipo.ValidadorDeDouble(valor));
        }

    }
}