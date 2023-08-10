using Ecom.Repository.Interfaces;
using WebApp.BFF.Database;

namespace Ecom.Repository.Impl.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcomContext _context;
        private ILoggingRepository _loggingRepository;

        public UnitOfWork(EcomContext context)
        {
            _context = context;
        }

        public ILoggingRepository LoggingRepository
        {
            get { return _loggingRepository = _loggingRepository ?? new LoggingRepository(_context); }
        }


        public void SaveChanges()
            => _context.SaveChanges();

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public void Dispose() 
            => _context.Dispose();

        public void Rollback()
            => _context.Dispose();

        public async Task RollbackAsync()
            => await _context.DisposeAsync();
    }
}
