using BusProArchitecture.Usuario.Domain.Entities;

namespace BoletoBusMaMonolitica.Data.Models
{
    public class UsuarioModel  : Usuario
    {


        
       
         public static UsuarioModel FromEntity(Usuario usuario)
        {
            return new UsuarioModel
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
