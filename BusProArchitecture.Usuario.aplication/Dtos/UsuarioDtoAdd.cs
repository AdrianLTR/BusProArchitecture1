using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProArchitecture.Usuario.Application.Dtos
{
    public record UsuarioDtoAdd(


         int IdUsuario,
        string? Nombres,
        string? Apellidos,
        string? Correo,
        string? Clave,
        string? TipoUsuario,

       DateTime FechaCreacion


       );
}
