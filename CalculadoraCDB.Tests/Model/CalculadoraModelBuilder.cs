using CalculadoraCDB.Domain.Commands;

namespace CalculadoraCDB.Tests.Model
{
    public class CalculadoraModelBuilder
    {
        public CalculadoraCommand Build()
        {
            return new CalculadoraCommand(1000, 50);
        }
    }
}
