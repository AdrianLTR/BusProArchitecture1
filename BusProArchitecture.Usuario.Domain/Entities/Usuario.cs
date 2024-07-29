
using BusProArchitecture.common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusProArchitecture.Usuario.Domain.Entities
{
    public class Usuario : AuditEntity<int>
    {
        [Column("IdUsuario")]
        public override int Id { get; set; }

        public int IdUsuario { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }
        public string? Correo { get; set; }

        public string? Clave { get; set; }

        public string? TipoUsuario { get; set; }

        public DateTime FechaCreacion { get; set; }
       
    }
}
