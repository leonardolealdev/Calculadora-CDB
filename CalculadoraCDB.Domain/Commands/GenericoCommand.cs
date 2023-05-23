using CalculadoraCDB.Domain.Commands.Contracts;

namespace CalculadoraCDB.Domain.Commands
{
    public class GenericoCommand : ICommandResult
    {
        public GenericoCommand() { }
        public GenericoCommand(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
