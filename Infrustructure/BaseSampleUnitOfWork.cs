using Domain.Interfaces;
using Domain.Interfaces.BusinessIRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrustructure
{
    public class BaseSampleUnitOfWork : IBaseSampleUnitOfWork
    {
        private readonly BaseProjectDBContext _context;

        public BaseSampleUnitOfWork(
            BaseProjectDBContext context,
            ISampleModelRepository _sampleModelRepository)
        {
            _context = context;
            SampleModelRepository = _sampleModelRepository;

        }


        public ISampleModelRepository SampleModelRepository { get; }

        public void Commit() => _context.SaveChanges();

        public void Rollback() => _context.Database.RollbackTransaction();// Rollback changes if needed

        public async Task RollbackAsync() => await _context.Database.RollbackTransactionAsync();

        public async Task CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

        public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

    }
}
