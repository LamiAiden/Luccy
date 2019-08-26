using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Luccy.EntityFramework.Repositories
{
    public abstract class LuccyRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<LuccyDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected LuccyRepositoryBase(IDbContextProvider<LuccyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class LuccyRepositoryBase<TEntity> : LuccyRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected LuccyRepositoryBase(IDbContextProvider<LuccyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
