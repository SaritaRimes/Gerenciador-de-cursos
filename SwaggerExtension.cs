using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GerenciadorDeCursos
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "GerenciadorDeCursos", Version = "v1"});
            });
        }
    }
}