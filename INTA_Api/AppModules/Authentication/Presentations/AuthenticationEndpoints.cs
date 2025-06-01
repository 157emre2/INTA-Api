namespace INTA_Api.AppModules.Authentication;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
       var group = app.MapGroup("/api/authentication").WithTags("Authentication");

        group.MapPost("/login", async (IAuthService authService, UserRequestModel user) =>
        {
            var result = await authService.Login(user);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
        group.MapPost("/register", async (IAuthService authService, UserRequestModel user) =>
        {
            var result = await authService.Register(user);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
    }
}
