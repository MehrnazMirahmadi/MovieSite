using MovieSite.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MovieSite.BootStrap
{
    public static class BootStrap
    {
        public static void WireUP(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<MovieDbContext>(op => { op.UseSqlServer(ConnectionString); }, ServiceLifetime.Scoped);
        }
    }
}
