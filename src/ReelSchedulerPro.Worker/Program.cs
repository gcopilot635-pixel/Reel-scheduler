using ReelSchedulerPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

Host.CreateDefaultBuilder(args)
    .UseSerilog((context, configuration) =>
        configuration
            .WriteTo.Console()
            .MinimumLevel.Information())
    .ConfigureServices((context, services) =>
    {
        // Add DbContext
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection") ?? "Host=localhost;Database=ReelSchedulerPro;Username=postgres;Password=postgres";
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddHostedService<Worker>();
    })
    .Build()
    .RunAsync();