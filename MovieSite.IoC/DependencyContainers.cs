using Microsoft.Extensions.DependencyInjection;
using MovieSite.Application.Interfaces.FilmInterfaces;
using MovieSite.Application.Services.FilmServices;
using MovieSite.Data.Repository.Box;
using MovieSite.Data.Repository.FilmRepository;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.BoxInterfaces;
using MovieSite.Domain.Interfaces.FilmInterfaces;



namespace MovieSite.IoC
{
    public class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddTransient<IBoxRepository, BoxRepository>();
            service.AddTransient<IFilmRepository, FilmRepository>();
            service.AddTransient<IFilmServices, FilmServices>();
        }
    }
}
