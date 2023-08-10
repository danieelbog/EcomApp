using AutoMapper;
using Ecom.Core.DTOs.LoggingData;
using Ecom.Core.Models.Logging;

namespace Ecom.Core.Mapping.Logging
{
    public class LoggingProfile : Profile
    {
        public LoggingProfile() 
        { 
            CreateMap<LoggingDataDto, LoggingData>();
            CreateMap<LoggingData, LoggingDataDto>();
        }
    }
}
