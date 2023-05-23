using CalculadoraCDB.Domain.Commands;
using CalculadoraCDB.Domain.ViewModel;
using MediatR;

namespace CalculadoraCDB.Domain.Handlers
{
    public class CalculadoraHandler : IRequestHandler<CalculadoraCommand, GenericoCommand>
    {
        private const decimal TB = 1.08M;
        private const decimal CDI = 0.009M;

        public Task<GenericoCommand> Handle(CalculadoraCommand request, CancellationToken cancellationToken)
        {
            var result = new CalculadoraResponse();
            result.ValorBruto = CalcularCDB(request);
            var rendimento = result.ValorBruto - request.Valor;
            result.ValorLiquido = CalcularValorLiquido(request.Prazo, result.ValorBruto, rendimento);

            ArredondarDuasCasas(result);
            return Task.FromResult(new GenericoCommand(true, "Calculado com sucesso", result));
        }

        private decimal CalcularCDB(CalculadoraCommand request)
        {
            decimal valorInicial = request.Valor;
            decimal valorFinal = decimal.Zero;

            for (int i = 1; i <= request.Prazo; i++)
            {
                valorFinal = valorInicial * (1 + (TB * CDI));

                valorInicial = valorFinal;
            }

            return valorFinal;
        }

        private decimal CalcularValorLiquido(int prazo, decimal valorBruto, decimal rendimento)
        {
            switch (prazo)
            {
                case <= 6:
                    return valorBruto - (rendimento * 0.225M);
                case <= 12:
                    return valorBruto - (rendimento * 0.2M);
                case <= 24:
                    return valorBruto - (rendimento * 0.175M);
                default:
                    return valorBruto - (rendimento * 0.15M);
            }
        }

        private CalculadoraResponse ArredondarDuasCasas(CalculadoraResponse request)
        {
            request.ValorBruto = Math.Round(request.ValorBruto, 2, MidpointRounding.ToEven);
            request.ValorLiquido = Math.Round(request.ValorLiquido, 2, MidpointRounding.ToEven);

            return request;
        }
    }
}
