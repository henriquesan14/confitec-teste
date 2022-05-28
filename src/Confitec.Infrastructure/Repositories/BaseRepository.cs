using Confitec.Core.Entities;
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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly ConfitecContext _context;
        private readonly DbSet<TEntity> _entity;

        public BaseRepository(ConfitecContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            await _entity.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _entity.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entity.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await _entity.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task Remover(int id)
        {
            var entity = await ObterPorId(id);
            _entity.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
