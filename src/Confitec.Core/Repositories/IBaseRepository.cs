using Confitec.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Confitec.Core.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {

        Task<IReadOnlyList<TEntity>> BuscarTodosAsync();
        Task<IReadOnlyList<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);
        Task<TEntity> BuscarPorIdAsync(int id);
        Task<TEntity> AdicionarAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task RemoverAsync(TEntity entity);
    }
}
