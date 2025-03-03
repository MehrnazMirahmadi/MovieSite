using Microsoft.Extensions.DependencyInjection;
using MovieSite.Application.Interfaces.FilmInterfaces;
using MovieSite.Application.Interfaces.FilmInterfaces.Services.FilmServices;
using MovieSite.Application.Interfaces.TagInterfaces;
using MovieSite.Application.Interfaces.TagInterfaces.TagService;
using MovieSite.Data.Repository;
using MovieSite.Data.Repository.Box;
using MovieSite.Data.Repository.FilmRepository;
using MovieSite.Data.Repository.FilmTagRepository;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.BoxInterfaces;
using MovieSite.Domain.Interfaces.FilmInterfaces;
using MovieSite.Domain.Interfaces.TagInterfaces;



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
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagServices, TagServices>();
        }

    }
}
