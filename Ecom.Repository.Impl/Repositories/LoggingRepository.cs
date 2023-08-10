using Ecom.Core.Models.Logging;
using Ecom.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using WebApp.BFF.Database;

namespace Ecom.Repository.Impl.Repositories
{
    public class LoggingRepository : GenericRepository<LoggingData>, ILoggingRepository
    {
        public LoggingRepository(EcomContext context) : base(context)
        {
        }
    }
}
