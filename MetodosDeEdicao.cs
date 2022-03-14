using System.Collections.Generic;
using GerenciadorDeCursos.Domain;
using GerenciadorDeCursos.ValueObjects;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GerenciadorDeCursos
{
    public class MetodosDeEdicao
    {
        /* Metodo para inserir cursos na tabela */
        public static void InserirCurso(string titulo, int duracao, StatusCurso status)
        {
            Curso curso = new Curso()
            {
                Titulo = titulo,
                DuracaoEmHoras = duracao,
                Status = status
            };

            using Data.ApplicationContext db = new Data.ApplicationContext();

            db.Cursos.Add(curso);

            db.SaveChanges();
        }

        /* Metodo para consultar cursos por titulo na tabela Cursos */
        [HttpGet]
        [Route("consultacursoportitulo")]
        [AllowAnonymous]
        public static List<Curso> ConsultarCursoPorTitulo(string titulo)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            List<Curso> cursos = (from c in db.Cursos where c.Titulo == titulo select c).ToList();

            return cursos;
        }

        /* Metodo para consultar cursos por status na tabela Cursos */
        [HttpGet]
        [Route("consultacursoporstatus")]
        [AllowAnonymous]
        public static List<Curso> ConsultarCursoPorStatus(StatusCurso status)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            List<Curso> cursos = (from c in db.Cursos where c.Status == status select c).ToList();

            return cursos;
        }

        /* Metodo para excluir cursos por titulo */
        [HttpGet]
        [Route("excluicursoportitulo")]
        [Authorize(Roles = "gerente")]
        public static void ExcluirCursoPorTitulo(string titulo)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            List<Curso> curso = (from c in db.Cursos where c.Titulo == titulo select c).ToList();

            db.Cursos.RemoveRange(curso);

            db.SaveChanges();
        }

        /* Metodo para excluir cursos por Id */
        [HttpGet]
        [Route("excluircursosporid")]
        [Authorize(Roles = "gerente")]
        public static void ExcluirCursoPorId(int id)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            Curso curso = db.Cursos.Find(id);

            db.Cursos.Remove(curso);

            db.SaveChanges();
        }

        /* Metodo para atualizar o status de um curso */
        [HttpGet]
        [Route("atualizarstatuscurso")]
        [Authorize(Roles = "secretaria, gerente")]
        public static void AtualizarStatusCurso(int id, StatusCurso status)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            Curso curso = db.Cursos.Find(id);

            curso.Status = status;

            db.SaveChanges();
        }

        /* Metodo para inserir usuarios na tabela Usuario */
        public static void InserirUsuario(string username, string password, CargoFuncionario role)
        {
            Usuario user = new Usuario()
            {
                Username = username,
                Password = password,
                Role = role
            };

            using Data.ApplicationContext db = new Data.ApplicationContext();

            db.Usuarios.Add(user);

            db.SaveChanges();
        }

        /* Metodo para remover usuarios da tabela Usuario */
        public static void RemoverUsuario(int indexKey)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            Usuario user = db.Usuarios.Find(indexKey);

            db.Usuarios.Remove(user);

            db.SaveChanges();
        }

        /* Metodo para consultar usuarios na tabela Usuario */
        public static List<Usuario> ConsultarUsuario(string username, CargoFuncionario role)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            List<Usuario> usuario = (from c in db.Usuarios where c.Username == username && c.Role == role select c).ToList();

            return usuario;
        }
    }
}