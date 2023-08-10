using Microsoft.Extensions.Logging;

namespace Ecom.Core.DTOs.LoggingData

{
    public class LoggingDataDto
    {
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Method { get; set; }
        public string? Path { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public string? Exception { get; set; }
        public DateTime LogTime { get; set; }

        public LoggingDataDto()
        {
            
        }

        public LoggingDataDto(LogLevel logLevel, string? controllerName = null, string? actionName = null, string? method = null, string? path = null, string? exception = null)
        {
            ControllerName = controllerName;
            ActionName = actionName;
            Method = method;
            Path = path;
            LogLevel = logLevel;
            Message = $"API Call: {method} {path} -> {controllerName}.{actionName}";
            Exception = exception;
            LogTime = DateTime.Now;
        }
    }
}
