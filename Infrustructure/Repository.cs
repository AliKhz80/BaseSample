using Domain.Interfaces;
using Domain.ModelConfigs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;

namespace Infrustructure
{
    public class Repository<TEntity>(
        DbContext _Dbcontext,
        ICurrentUser currentUser
        ) : ReadOnlyRepository<TEntity>(_Dbcontext),
    IRepository<TEntity> where TEntity : Entity
    {



        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is TrackableEntity trackable)
            {
                trackable.Created(currentUser.UserName);
            }

            await Set.AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is TrackableEntity trackable)
            {
                trackable.Updated(currentUser.UserName);
            }

            await Task.Run(() =>
            {
                Set.Update(entity);
            }, cancellationToken);
        }

       

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is TrackableEntity trackable)
            {
                trackable.Deleted(currentUser.UserName);

                await Task.Run(() =>
                {
                    Set.Update(entity);
                }, cancellationToken);
            }
            else
            {
                await Task.Run(() =>
                {
                    Set.Remove(entity);
                }, cancellationToken);
            }
        }

    }
}