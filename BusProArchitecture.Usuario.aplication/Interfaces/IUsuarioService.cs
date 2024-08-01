

using BusProArchitecture.Usuario.Application.Dtos;

using BusProArchitecture.Usuario.aplication.Base;



namespace BusProArchitecture.Usuario.aplication.Interfaces
{

   

    public interface IUsuarioService
    {


        ServiceResult GetUsuarios();
        ServiceResult GetUsuario(int id);
        ServiceResult UpdateUsuario(UsuarioDtoUpdate usuarioUpdate);
        ServiceResult RemoveUsuario(UsuarioDtoRemove usuarioRemove);
        ServiceResult SaveUsuario(UsuarioDtoAdd usuarioAdd);


    }
}
