using CodeChallenge1.Repositories;
using CodeChallenge1.Services.Services;
using CodeChallenge1.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

void ConfigureHost(ConfigureHostBuilder host)
{

}

// Set up services
void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            b =>
            {
                b.MigrationsAssembly("CodeChallenge1.Repositories");
            })
        );

    // Dependency injections
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<ICupService, CupService>();
}

// Set up the HTTP request and response pipeline
void ConfigurePipeline(WebApplication app)
{
    if (!app.Environment.IsProduction())
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();
    }

    app.UseAuthorization();
    app.MapControllers();

}

// Migration on startup information
void ExecuteMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}

var builder = WebApplication.CreateBuilder(args);

// Set up the application
ConfigureHost(builder.Host);
ConfigureServices(builder);

var app = builder.Build();

// Execute migrations on startup
ExecuteMigrations(app);

// Set up the pipeline
ConfigurePipeline(app);

app.Run();