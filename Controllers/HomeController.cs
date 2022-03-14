using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GerenciadorDeCursos.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous] //qualquer pessoa
        public string Anonimo() => "Anônimo";

        [HttpGet]
        [Route("secretaria")]
        [Authorize(Roles = "Secretaria")]
        public string Secretaria() => "Secretaria";

        [HttpGet]
        [Route("gerente")]
        [Authorize(Roles = "Gerente")]
        public string Gerente() => "Gerente";
    }
}
