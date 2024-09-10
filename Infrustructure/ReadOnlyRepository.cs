﻿using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.ModelConfigs;
using Domain.SpecificationConfig;
using System.Data;

namespace Infrustructure;

public class ReadOnlyRepository<TEntity>(
    DbContext dbContext
    ) : RepositoryProperties<TEntity>(dbContext),IReadOnlyRepository<TEntity> where TEntity : Entity
{

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await SetAsNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await SetAsNoTracking.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(CancellationToken cancellationToken = default)
    {
        return await SetAsNoTracking.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<(int TotalCount, IReadOnlyList<TEntity> Data)> ListAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        var query = SetAsNoTracking.Specify(specification);

        var totalCount = 0;

        if (specification.IsPagingEnabled)
        {
            totalCount = await query.CountAsync(cancellationToken);
            query = query.Skip(specification.Skip).Take(specification.Take);
        }
        var data = await query.ToListAsync(cancellationToken);

        return (totalCount, data);
    }

   
}
