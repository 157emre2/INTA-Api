using DotNetEnv;
using INTA_Api.DependencyRegistrar;
using INTA_Api.EntitySettings;
using Microsoft.EntityFrameworkCore;
using SwaggerThemes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

Env.Load();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(Env.GetString("DB_CONN_STRING"),
        new MySqlServerVersion(new Version(8, 0, 41))));

DependencyRegistrar.RegisterServices(builder.Services);

builder.Configuration["Jwt:Key"] = Env.GetString("JWT_KEY");
builder.Configuration["Jwt:Issuer"] = Env.GetString("JWT_ISSUER");
builder.Configuration["Jwt:Audience"] = Env.GetString("JWT_AUDIENCE");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(Theme.UniversalDark);
}

DependencyRegistrar.RegisterEndpoints(app);

app.UseCors();

app.Run();
