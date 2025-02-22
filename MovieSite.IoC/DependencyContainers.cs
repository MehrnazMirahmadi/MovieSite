using Microsoft.Extensions.DependencyInjection;
using MovieSite.Application.Interfaces.FilmInterfaces;
using MovieSite.Application.Interfaces.FilmInterfaces.Services.FilmServices;
using MovieSite.Data.Repository;
using MovieSite.Data.Repository.Box;
using MovieSite.Data.Repository.FilmRepository;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.BoxInterfaces;
using MovieSite.Domain.Interfaces.FilmInterfaces;



namespace MovieSite.IoC
{
    public class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // ثبت Repository جنریک
            services.AddScoped<IBoxRepository, BoxRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmServices, FilmServices>();
        }

    }
}
