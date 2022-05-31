using System;

namespace Confitec.Core.Entities.Base
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
