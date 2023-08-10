using Ecom.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ILoggingRepository LoggingRepository { get; }
    void SaveChanges();
    void Rollback();
    Task SaveChangesAsync();
    Task RollbackAsync();
}