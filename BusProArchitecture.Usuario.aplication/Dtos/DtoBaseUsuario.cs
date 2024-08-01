using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProArchitecture.Usuario.Application.Dtos
{
    internal class DtoBaseUsuario : DtoBase
    {

        public string? Title { get; set; }
        public int Credits { get; set; }
        public int IdUsuario { get; set; }

    }
}
