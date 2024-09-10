using Domain.ModelConfigs;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure;

public class RepositoryProperties<TEntity>(
    DbContext dbContext
    ) where TEntity : Entity
{
    protected readonly DbContext _dbContext = dbContext;

    protected DbSet<TEntity> Set => _dbContext.Set<TEntity>();

    protected IQueryable<TEntity> SetAsNoTracking
    {
        get
        {
            var query = Set.AsNoTracking();

            if (typeof(TEntity).IsSubclassOf(typeof(TrackableEntity)))
            {
                query = query.Where(e => !(e as TrackableEntity)!.IsDeleted);
            }

            return query;
        }
    }
}
