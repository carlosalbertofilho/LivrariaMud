using LivrariaMud.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LivrariaMud.CrossCutting.DependenciesApp;

public static class AddDb
{
    public static IServiceCollection AddDbApp
        (this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString  = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Não consegue conectar no banco de dados!");

        service.AddDbContext<LivrariaMudContext>( options =>
            options.UseSqlServer( connectionString ) );

        return service;
    }
}
