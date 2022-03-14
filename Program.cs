using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GerenciadorDeCursos
{
    /* LEMBRAR DE TIRAR A SENHA DA STRING DO SQL SERVER NO APPLICATIONCONTEXT */
    public class Program : MetodosDeEdicao
    {
        public static void Main(string[] args)
        {
            using Data.ApplicationContext db = new Data.ApplicationContext();

            //InserirUsuario("Pedro Souza", "1234567", CargoFuncionario.Professor);
            //InserirUsuario("Juliana Castro", "1234567", CargoFuncionario.Secretaria);
            //InserirUsuario("Paula Borges", "1234567", CargoFuncionario.Gerente);
            //InserirCurso("Desenvolvimento de Software", 150, StatusCurso.Previsto);

            //RemoverUsuario(4);
            //RemoverUsuario(5);
            //RemoverUsuario(6);

            bool migracoesPendentes = db.Database.GetPendingMigrations().Any();
            if (migracoesPendentes)
                System.Console.WriteLine("ATENÇÃO! \nExistem migrações pendentes!");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
