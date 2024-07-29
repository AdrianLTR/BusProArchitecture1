using BusProArchitecture.Usuario.Domain.Entities;

namespace BoletoBusMaMonolitica.Data.Models
{
    public class UsuarioSaveModel : UsuarioBaseModel
    {
        public UsuarioSaveModel() { }

        public Usuario ToEntity()
        {
            return new Usuario
            {


                IdUsuario = this.IdUsuario,
                Nombres = this.Nombres,
                Apellidos = this.Apellidos,
                Correo = this.Correo,
                Clave = this.Clave,
                TipoUsuario = this.TipoUsuario,
                FechaCreacion = this.FechaCreacion


            };
        }
    }
}
