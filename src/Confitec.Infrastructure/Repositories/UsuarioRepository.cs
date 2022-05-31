using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using Confitec.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ConfitecContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Usuario>> BuscarTodosAsync(int pageSize, int pageNumber)
        {
            return await _context.Set<Usuario>()
                .AsNoTracking()
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }
    }
}
