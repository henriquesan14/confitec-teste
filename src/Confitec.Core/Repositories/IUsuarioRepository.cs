using Confitec.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Core.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<IReadOnlyList<Usuario>> BuscarTodosAsync(int pageSize, int pageNumber);
    }
}
