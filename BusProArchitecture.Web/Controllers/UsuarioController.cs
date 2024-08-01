
using BusProArchitecture.Web.Models.Usuario;

namespace BusProArchitecture.Web.Controllers
{
    public class UsuarioController : BaseController<UsuarioGetModel, UsuarioSaveModel, UsuarioUpdateModel>
    {
        public UsuarioController() : base("http://localhost:5110/api/Usuario") { }

        protected override string GetAllUrl => "/GetUsuarios";
        protected override string GetByIdUrl => "/GetUsuario";
        protected override string CreateUrl => "/SaveUsuarios";
        protected override string UpdateUrl => "/UpdateUsuarios";
    }
}
