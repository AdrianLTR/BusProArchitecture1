using BusProArchitecture.Web.Models.Base;

namespace BusProArchitecture.Web.Models.Usuario
{
    public class UsuarioGetModel : UsuarioModel {}
    public class UsuarioListGetResult : BaseResult<List<UsuarioGetModel>> { }
    public class UsuarioGetResult : BaseResult<UsuarioGetModel> { }
}

