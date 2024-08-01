using BusProArchitecture.Usuario.aplication.Base;
using BusProArchitecture.Usuario.aplication.Interfaces;
using Microsoft.Extensions.Logging;
using BusProArchitecture.Usuario.Application.Dtos;

using BusProArchitecture.Usuario.aplication.Extensions;
using BusProArchitecture.Usuario.Domain.Interfaces;



namespace BusProArchitecture.Usuario.aplication.Services
{
  
    using BusProArchitecture.Usuario.aplication.Dtos;
    using BusProArchitecture.Usuario.Domain.Entities;


    public class UsuarioService : IUsuarioService
    {


        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;


        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)


        {
            this.usuarioRepository = usuarioRepository;

            this.logger = logger;
        }

        private ServiceResult Execute(Func<ServiceResult> action, string errorMessage)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = action();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = errorMessage;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        private ServiceResult Validate(Func<bool> condition, string errorMessage)
        {
            ServiceResult result = new ServiceResult();
            if (condition())
            {
                result.Success = false;
                result.Message = errorMessage;
                return result;
            }
            result.Success = true;
            return result;
        }

        public ServiceResult GetUsuarios()
        {
            return Execute(() => {
                var usuarios = usuarioRepository.GetAll();
                var result = new ServiceResult
                {
                    Data = usuarios.Select(usuario => new UsuarioDtoGet(
                        usuario.Id,
                        usuario.IdUsuario,
                        usuario.Nombres,
                        usuario.Apellidos,
                        usuario.Correo,
                        usuario.Clave,
                        usuario.TipoUsuario,
                        usuario.FechaCreacion


                    )).ToList()
                };
                return result;
            }, "Hubo un error durante la obtención del Usuarios.");
        }

        public ServiceResult GetUsuario(int id)
        {
            return Execute(() => {
                var usuario = usuarioRepository.GetEntityby(id);
                if (usuario == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Usuario no encontradao."
                    };
                }
                var result = new ServiceResult
                {
                    Data = new UsuarioDtoGet(
                          usuario.Id,
                        usuario.IdUsuario,
                        usuario.Nombres,
                        usuario.Apellidos,
                        usuario.Correo,
                        usuario.Clave,
                        usuario.TipoUsuario,
                        usuario.FechaCreacion
                    )
                };
                return result;
            }, "Ocurrió un error obteniendo el Usuario.");
        }

        public ServiceResult UpdateUsuario(UsuarioDtoUpdate usuarioUpdate)
        {
            return Execute(() => {
                var validationResult = Validate(() => usuarioUpdate == null, "Los datos del Usuario no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => usuarioUpdate.IdUsuario <= 0, "El Id del Usuario es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => usuarioUpdate.Nombres == null, "El Nombre es requerido.");
                if (!validationResult.Success) return validationResult;

                var usuario = usuarioRepository.GetEntityby(usuarioUpdate.IdUsuario);
                if (usuario == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "usuario no encontrado."
                    };
                }
                usuarioUpdate.UpdateEntity(usuario);

                usuarioRepository.Update(usuario);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error actualizando los datos.");
        }

        public ServiceResult RemoveUsuario(UsuarioDtoRemove usuarioRemove)
        {
            return Execute(() => {
                var validationResult = Validate(() => usuarioRemove == null, "Los datos del usuario no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                var usuario = usuarioRepository.GetEntityby(usuarioRemove.IdUsuario);
                if (usuario == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Usuario no encontrado."
                    };
                }
                usuarioRepository.Remove(usuario);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error removiendo los datos.");
        }

        public ServiceResult SaveUsuario(UsuarioDtoAdd usuarioAdd)
        {
            return Execute(() => {
                var validationResult = Validate(() => usuarioAdd == null, "Los datos del Usuario no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => usuarioAdd.IdUsuario <= 0, "El Id del Usuario es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => usuarioAdd.Nombres == null, "El Nombre es requerido.");
                if (!validationResult.Success) return validationResult;

                var usuarioEntity = new Usuario
                {
                    



                   IdUsuario=usuarioAdd.IdUsuario,
                    Nombres= usuarioAdd.Nombres,
                    Apellidos= usuarioAdd.Apellidos,
                    Correo= usuarioAdd.Correo,
                    Clave= usuarioAdd.Clave,
                    TipoUsuario= usuarioAdd.TipoUsuario,
                     FechaCreacion = DateTime.Now






                };

                usuarioRepository.Save(usuarioEntity);
                return new ServiceResult { Success = true, Data = usuarioEntity };
            }, "Ocurrió un error grabando los datos.");
        }






    }
}
