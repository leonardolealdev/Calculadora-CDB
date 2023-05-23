using FluentValidation;
using MediatR;

namespace CalculadoraCDB.Domain.Commands
{
    public class CalculadoraCommand : IRequest<GenericoCommand>
    {
        public CalculadoraCommand(decimal valor, int prazo)
        {
            Valor = valor;
            Prazo = prazo;
        }

        public decimal Valor { get; set; }

        public int Prazo { get; set; }
    }

    public class CalculadoraCommandValidator : AbstractValidator<CalculadoraCommand>
    {
        public CalculadoraCommandValidator()
        {
            RuleFor(r => r.Valor).NotNull().WithMessage("O Valor é obrigatório")
                .Must(ValorPositivo).WithMessage("Valor deve ser positivo");
            RuleFor(r => r.Prazo).NotNull().WithMessage("O Prazo é obrigatório")
                 .Must(PrazoMaiorQueUm).WithMessage("Prazo deve ser maior que 1 mês");
        }

        private static bool ValorPositivo(decimal valor)
        {
            return valor > 0;
        }

        private static bool PrazoMaiorQueUm(int prazo)
        {
            return prazo > 1;
        }
    }
}
