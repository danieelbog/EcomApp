using AutoMapper;
using Ecom.Core.DTOs.LoggingData;
using Ecom.Core.Models.Logging;
using Ecom.Services.Exceptions.Exception;
using Ecom.Services.Interfaces.Logging;

namespace Ecom.Services.Impl.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoggingService(IUnitOfWork unitOfWork, IMapper mapper)
        {   
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LoggingDataDto> SaveToDb(LoggingDataDto logging)
        {
            _unitOfWork.LoggingRepository.Add(_mapper.Map<LoggingData>(logging));
            await _unitOfWork.SaveChangesAsync();
            return logging;
        }
    }
}
