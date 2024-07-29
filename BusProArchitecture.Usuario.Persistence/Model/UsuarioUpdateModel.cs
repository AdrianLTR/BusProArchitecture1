using BusProArchitecture.Usuario.Domain.Entities;
using BoletoBusMaMonolitica.Data.Models;
public class UsuarioUpdateModel : UsuarioBaseModel
{
    public UsuarioUpdateModel()
    {
    }
    public void UpdateEntity(Usuario usuario)
    {




        usuario.IdUsuario = this.IdUsuario;
        usuario.Nombres = this.Nombres;
        usuario.Apellidos = this.Apellidos;
        usuario.Correo = this.Correo;
        usuario.Clave = this.Clave;
        usuario.TipoUsuario = this.TipoUsuario;
        usuario.FechaCreacion = this.FechaCreacion;

    }
}