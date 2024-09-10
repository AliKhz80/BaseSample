using Domain.Interfaces.BusinessIRepositories;

namespace Domain.Interfaces
{
    public interface IBaseSampleUnitOfWork : IDisposable
    {

        public ISampleModelRepository SampleModelRepository { get; }
       

        void Commit();

        public Task CommitAsync();

        void Rollback();

        public Task RollbackAsync();

        public Task BeginTransactionAsync();

    }
}
