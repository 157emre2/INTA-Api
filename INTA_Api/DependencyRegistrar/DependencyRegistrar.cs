using Core;
using INTA_Api.AppModules.Authentication;
using INTA_Api.AppModules.Modules;
using INTA_Api.DbOperations;

namespace INTA_Api.DependencyRegistrar;

public static class DependencyRegistrar
{
    public static void RegisterServices(IServiceCollection services)
    {
        #region AppModules
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IModuleService, ModuleService>();

        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();
        #endregion
        #region Core
        services.AddScoped<IJwtService, JwtService>();
        #endregion
        #region DbOperations
        services.AddScoped(typeof(IDbOperations<>), typeof(DbOperations<>));
        #endregion

    }

    public static void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapAuthenticationEndpoints();
        app.MapModuleEndpoints();
    }
}
