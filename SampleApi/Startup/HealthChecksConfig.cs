using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using SampleApi.HealthChecks;

namespace SampleApi.Startup;

public static class HealthChecksConfig
{
    public static void AddAllHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<HealthyHealthCheck>("Healthy Health Check", tags: ["healthy"])
            .AddCheck<UnhealthyHealthCheck>("Unhealthy Health Check", tags: ["unhealthy"])
            .AddCheck<DegardedHealthCheck>("Degraded Health Check", tags: ["degraded"])
            .AddCheck<RandomHealthCheck>("Random Health Check", tags: ["random"]);
    }

    public static void MapAllHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/health/healthy", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("healthy")
        });
        app.MapHealthChecks("/health/degraded", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("degraded")
        });
        app.MapHealthChecks("/health/unhealthy", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("unhealthy")
        });
        app.MapHealthChecks("/health/random", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("random")
        });
        app.MapHealthChecks("/health/ui", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/healthy/ui", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("healthy"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/degraded/ui", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("degraded"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/unhealthy/ui", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("unhealthy"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/random/ui", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("random"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}