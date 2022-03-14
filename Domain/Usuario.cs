using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using GerenciadorDeCursos.ValueObjects;

namespace GerenciadorDeCursos.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonConverter(typeof(StringEnumConverter))] //converte enum para string
        public CargoFuncionario Role { get; set; }
    }
}