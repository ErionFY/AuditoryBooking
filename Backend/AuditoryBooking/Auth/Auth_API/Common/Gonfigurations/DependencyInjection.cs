using Auth_DAL;
using Microsoft.EntityFrameworkCore;

namespace Auth_API.Common.Configuration;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration){

        string connectionString = configuration.GetConnectionString("AuthConnection");
        services.AddDbContext<AuthDbContext>(options => { options.UseNpgsql(connectionString); });

        return services;
    }




}
