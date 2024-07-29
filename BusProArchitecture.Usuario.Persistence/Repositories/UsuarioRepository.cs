

using BusProArchitecture.Usuario.Persistence.Exceptions;
using BusProArchitecture.Usuario.Domain.Interfaces;
using BusProArchitecture.Usuario.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BusProArchitecture.Usuario.Persistence.Repositories
{

using BusProArchitecture.Usuario.Domain.Entities;

    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly BoletoBusContext context;

        public UsuarioRepository(BoletoBusContext context)
        {
            this.context = context;
        }

        public Usuario GetEntityby(int Id)
        {
            var usuario = context.Usuarios.Find(Id);
            UsuarioException.VerifyExistence(usuario, Id);
            return usuario;
        }

        public bool Exist(Expression<Func<Usuario, bool>> filter)
        {
            return context.Usuarios.Any(filter);
        }




        public List<Usuario> GetAll()
        {
            return context.Usuarios.ToList();
        }

        public List<Usuario> GetReservasByIdUsuario(int IdUsuario)
        {
            return context.Usuarios.Where(a => a.IdUsuario == IdUsuario).ToList();
        }



        public void Remove(Usuario entity)
        {
            context.Usuarios.Remove(entity);
            context.SaveChanges();
        }

        public void Save(Usuario entity)
        {
            context.Usuarios.Add(entity);
            context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            var existingUsuario = context.Usuarios.Find(entity.Id);
            UsuarioException.VerifyExistence(existingUsuario, entity.Id);

            existingUsuario.Id = entity.Id;
            existingUsuario.IdUsuario = entity.IdUsuario;
            existingUsuario.Nombres = entity.Nombres;
            existingUsuario.Apellidos = entity.Apellidos;
            existingUsuario.Correo = entity.Correo;
            existingUsuario.Clave = entity.Clave;
            existingUsuario.TipoUsuario = entity.TipoUsuario;


            context.Usuarios.Update(existingUsuario);
            context.SaveChanges();
        }
    }
}
