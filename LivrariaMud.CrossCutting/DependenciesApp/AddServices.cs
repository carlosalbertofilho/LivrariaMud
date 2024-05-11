using Microsoft.Extensions.DependencyInjection;
using LivrariaMud.Application.Services;
using LivrariaMud.Application.Abstrations;
using LivrariaMud.Domain.Abstrations;
using LivrariaMud.Infrastructure.Repositories;

namespace LivrariaMud.CrossCutting.DependenciesApp;

public static class AddServices
{
    public static IServiceCollection AddServiceApp
        (this IServiceCollection service)
    {
        service.AddScoped<IBookRepository, BookRepository>();
        service.AddScoped<IBookService, BookServices>();
        return service;
    }
}
