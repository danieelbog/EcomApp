using Ecom.Core.DTOs.LoggingData;
using Ecom.Services.Interfaces.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecom.BFF.Attributes
{
    public class LogAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LogAttribute> _logger;
        private readonly ILoggingService _loggingService;
        public LogAttribute(ILogger<LogAttribute> logger, ILoggingService loggingService)
        {
            _logger = logger;
            _loggingService = loggingService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var loggingData = new LoggingDataDto(LogLevel.Information, context.Controller.GetType().Name, context.ActionDescriptor.DisplayName, context.HttpContext.Request.Method, context.HttpContext.Request.Path);
            _logger.LogInformation(loggingData.Message);
            _loggingService.SaveToDb(loggingData);
            base.OnActionExecuting(context);
        }
    }
}
