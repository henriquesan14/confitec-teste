using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using Confitec.Infrastructure.Context;

namespace Confitec.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ConfitecContext context) : base(context)
        {

        }
    }
}
