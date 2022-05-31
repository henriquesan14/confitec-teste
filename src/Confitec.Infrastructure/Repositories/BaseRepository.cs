using Confitec.Core.Entities.Base;
using Confitec.Core.Repositories;
using Confitec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Confitec.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly ConfitecContext _context;
        private readonly DbSet<TEntity> _entity;

        public BaseRepository(ConfitecContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public async Task<IReadOnlyList<TEntity>> BuscarTodosAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }


        public async Task<IReadOnlyList<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                    string includeString = null,
                                    bool disableTracking = true)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> BuscarPorIdAsync(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<TEntity> AdicionarAsync(TEntity entity)
        {
            entity.CriadoEm = DateTime.Now;
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AtualizarAsync(TEntity entity)
        {
            entity.AtualizadoEm = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
