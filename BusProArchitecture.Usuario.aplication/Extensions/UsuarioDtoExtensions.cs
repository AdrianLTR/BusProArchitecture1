using BusProArchitecture.Usuario.Application.Dtos;

namespace BusProArchitecture.Usuario.aplication.Extensions
{

    using BusProArchitecture.Usuario.Domain.Entities;  

    public static class UsuarioDtoExtentions
    {


        public static Usuario ToEntity(this UsuarioDtoAdd usuarioDto)
        {
            return new Usuario
            {
                IdUsuario = usuarioDto.IdUsuario,
                Nombres = usuarioDto.Nombres,
                Apellidos = usuarioDto.Apellidos
            };
        }

        public static void UpdateEntity(this UsuarioDtoUpdate usuarioDto, Usuario usuario)
        {



            usuario.IdUsuario = usuarioDto.IdUsuario;
            usuario.Nombres = usuarioDto.Nombres;
            usuario.Apellidos = usuarioDto.Apellidos;


        }
    }
}
