using JustInTimeUser.Domain.Repositories;
using JustInTimeUser.Domain.Repositories.User;
using JustInTimeUser.Infrastructure.DataAccess;
using JustInTimeUser.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JustInTimeUser.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var connectionString = "Server=localhost;Database=justintimeusers;Uid=root;Pwd=admin;";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

        services.AddDbContext<JustInTimeUserDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseMySql(connectionString, serverVersion);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}
