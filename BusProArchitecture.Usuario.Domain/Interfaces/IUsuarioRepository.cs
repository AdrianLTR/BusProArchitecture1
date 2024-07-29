using BusProArchitecture.common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProArchitecture.Usuario.Domain.Interfaces
{
   public interface IUsuarioRepository : IBaseRepository<Usuario.Domain.Entities.Usuario,int>
    {
        List<Usuario.Domain.Entities.Usuario> GetReservasByIdUsuario(int idUsuario);

    }
}
