using CalculadoraCDB.Domain.Commands;
using CalculadoraCDB.Tests.Model;

namespace CalculadoraCDB.Tests.CommandTests
{
    public class CalculadoraCommandTests
    {
        private readonly CalculadoraCommand _calculo = new CalculadoraModelBuilder().Build();
        private readonly CalculadoraCommandValidator _validador = new CalculadoraCommandValidator();

        [Fact]
        public void CommandDeveSerValido()
        {
            var result = _validador.Validate(_calculo);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void CommandDeveSerInvalido_ValorNegativo()
        {
            _calculo.Valor = -1;
            var result = _validador.Validate(_calculo);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void CommandDeveSerInvalido_PrazoInvalido()
        {
            _calculo.Prazo = 1;
            var result = _validador.Validate(_calculo);

            Assert.False(result.IsValid);
        }
    }
}
