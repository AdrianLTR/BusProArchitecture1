
namespace BusProArchitecture.Usuario.Persistence.Exceptions
{
    using BusProArchitecture.Usuario.Domain.Entities;

    public class UsuarioException : Exception
    {
        public UsuarioException(string message) : base(message)
        {
        }

        public static void VerifyExistence(Usuario usuario, int idUsuario)
        {
            if (usuario == null)
            {
                throw new UsuarioException($"El asiento con la id {idUsuario} no está registrado.");
            }
        }


    }
}
    