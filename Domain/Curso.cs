using GerenciadorDeCursos.ValueObjects;

namespace GerenciadorDeCursos.Domain
{
    public class Curso
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int DuracaoEmHoras { get; set; }
        public StatusCurso Status { get; set; }
    }
}