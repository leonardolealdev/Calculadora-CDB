using CalculadoraCDB.Domain.Commands;
using CalculadoraCDB.Domain.Handlers;
using CalculadoraCDB.Domain.ViewModel;
using CalculadoraCDB.Tests.Model;

namespace CalculadoraCDB.Tests.HandlerTests
{
    public class CalculoHandlerTests
    {
        private readonly CalculadoraCommand _calculo = new CalculadoraModelBuilder().Build();
        private readonly CalculadoraHandler _handler = new CalculadoraHandler();
        private GenericoCommand _result = new GenericoCommand();

        [Fact]
        public async void CalcularaSucesso()
        {
            _result = await _handler.Handle(_calculo, CancellationToken.None);
            Assert.True(_result.Success);
        }

        [Theory]
        [InlineData(1049.55, 1038.40, 5)]
        [InlineData(1059.76, 1046.31, 6)]
        [InlineData(1019.53, 1015.14, 2)]
        public async Task CalcularComPrazo_MenorIgual6Meses(decimal valorBruto, decimal valorLiquido, int prazo)
        {
            _calculo.Prazo = prazo;
            _result = await _handler.Handle(_calculo, CancellationToken.None);
            var result = (CalculadoraResponse)_result.Data;
 
            Assert.Equal(valorBruto, result.ValorBruto);
            Assert.Equal(valorLiquido, result.ValorLiquido);
        }

        [Theory]
        [InlineData(1070.06, 1056.05, 7)]
        [InlineData(1090.96, 1072.77, 9)]
        [InlineData(1101.56, 1081.25, 10)]
        public async Task CalcularComPrazo_MenorIgual12Meses(decimal valorBruto, decimal valorLiquido, int prazo)
        {
            _calculo.Prazo = prazo;
            _result = await _handler.Handle(_calculo, CancellationToken.None);
            var result = (CalculadoraResponse)_result.Data;

            Assert.Equal(valorBruto, result.ValorBruto);
            Assert.Equal(valorLiquido, result.ValorLiquido);
        }

        [Theory]
        [InlineData(1145.02, 1119.64, 14)]
        [InlineData(1201.76, 1166.45, 19)]
        [InlineData(1249.17, 1205.57, 23)]
        public async Task CalcularComPrazo_MenorIgual24Meses(decimal valorBruto, decimal valorLiquido, int prazo)
        {
            _calculo.Prazo = prazo;
            _result = await _handler.Handle(_calculo, CancellationToken.None);
            var result = (CalculadoraResponse)_result.Data;

            Assert.Equal(valorBruto, result.ValorBruto);
            Assert.Equal(valorLiquido, result.ValorLiquido);
        }

        [Theory]
        [InlineData(1336.68, 1286.18, 30)]
        [InlineData(1545.41, 1463.60, 45)]
        [InlineData(3192.38, 2863.53, 120)]
        public async Task CalcularComPrazo_MaiorQue24Meses(decimal valorBruto, decimal valorLiquido, int prazo)
        {
            _calculo.Prazo = prazo;
            _result = await _handler.Handle(_calculo, CancellationToken.None);
            var result = (CalculadoraResponse)_result.Data;

            Assert.Equal(valorBruto, result.ValorBruto);
            Assert.Equal(valorLiquido, result.ValorLiquido);
        }
    }
}
