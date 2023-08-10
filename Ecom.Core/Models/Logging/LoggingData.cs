using Microsoft.Extensions.Logging;

namespace Ecom.Core.Models.Logging
{
    public class LoggingData
    {
        public Guid Id { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Method { get; set; }
        public string? Path { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public string? Exception { get; set; }
        public DateTime LogTime { get; set; }
    }
}
