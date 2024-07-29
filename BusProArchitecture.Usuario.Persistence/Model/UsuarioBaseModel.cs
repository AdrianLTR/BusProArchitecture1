using BusProArchitecture.Usuario.Domain.Entities;
using System.ComponentModel.DataAnnotations;
namespace BoletoBusMaMonolitica.Data.Models
{
    public class UsuarioBaseModel 
    {
        [Key] public int IdUsuario { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }
        public string? Correo { get; set; }

        public string? Clave { get; set; }

        public string? TipoUsuario { get; set; }

        public DateTime FechaCreacion { get; set; }



    }
}