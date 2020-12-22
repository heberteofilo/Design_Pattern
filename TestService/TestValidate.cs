using Application._4___Entidades;
using Application._5___Repositorio;
using Application._5___Services;
using Application._6___Validate;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void ValidadorDeStringTeste()
        {
            Assert.True(condition: _ValidatePorTipo.ValidadorDeString("Computador"));
        }

        [Fact]
        public void ValidadorDeDoubleTeste()
        {
            Assert.True(condition: _ValidatePorTipo.ValidadorDeDouble(1));
        }

    }
}
