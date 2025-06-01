using Microsoft.AspNetCore.Routing;

namespace INTA_Api.AppModules.Modules;

public static class ModuleEndpoints
{
    public static void MapModuleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/modules").WithTags("Modules");

        group.MapGet("/getAllModulesWithLang", async (IModuleService moduleService, int lang) =>
        {
            var result = await moduleService.GetModulesWithLang(lang);
            return result.IsSuccess ? Results.Ok(result) : Results.NotFound(result);
        });

        group.MapPost("/addModule", async (IModuleService moduleService, AddModuleRequestViewModel module) =>
        {
            var result = await moduleService.AddModule(module);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
    }
}
