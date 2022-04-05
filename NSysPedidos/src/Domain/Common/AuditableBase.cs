using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableBase
    {
        public virtual int Id { get; set; }
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaDeCreacion { get; set; }
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime? FechaModificacion { get; set; }
    }
}
