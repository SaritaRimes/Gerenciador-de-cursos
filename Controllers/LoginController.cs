using System.Linq;
using GerenciadorDeCursos.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost] //o metodo post faz o recebimento de informacoes
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario model)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            // Recupera o usuario
            List<Usuario> usuario = (from c in db.Usuarios where c.Username == model.Username && c.Role == model.Role select c).ToList();

            // Verifica se o usuario existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos." });

            // Verifica se ha mais do que um usuario com o mesmo nome e funcao
            if (usuario.Count > 1)
                return BadRequest(new { message = "Usuário duplicado." });

            // Pega o único elemento da lista
            Usuario usuarioFinal = usuario[0];

            // Gera o token
            string token = TokenController.GenerateToken(usuarioFinal);

            // Ocultar a senha do usuario
            model.Password = "";

            // Retorna os dados
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}