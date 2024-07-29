using BusProArchitecture.Usuario.Domain.Entities;

namespace BoletoBusMaMonolitica.Data.Models
{

    public class UsuarioGetModel : UsuarioBaseModel
    {

        public static UsuarioGetModel FromEntity(Usuario usuario)
        {
            return new UsuarioGetModel
            {

                IdUsuario = usuario.IdUsuario,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                TipoUsuario = usuario.TipoUsuario,                
               FechaCreacion = usuario.FechaCreacion
            };
        }
    }
}
