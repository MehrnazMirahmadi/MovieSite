using MovieSite.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security;

namespace MovieSite.BootStrap;

public static class BootStrap
{
    public static void WireUP(IServiceCollection services, string ConnectionString, string SecurityConnection)
    {
        services.AddDbContext<MovieDbContext>(op => { op.UseSqlServer(ConnectionString); }, ServiceLifetime.Scoped);
        services.AddDbContext<SecurityContext>(s => { s.UseSqlServer(SecurityConnection); }, ServiceLifetime.Scoped);

    }
}