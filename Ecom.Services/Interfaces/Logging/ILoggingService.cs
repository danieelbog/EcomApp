using Ecom.Core.DTOs.LoggingData;

namespace Ecom.Services.Interfaces.Logging
{
    public interface ILoggingService
    {
        Task<LoggingDataDto> SaveToDb(LoggingDataDto logging);
    }
}
