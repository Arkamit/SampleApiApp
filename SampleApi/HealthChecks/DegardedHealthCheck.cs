using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SampleApi.HealthChecks;
public class DegardedHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync
        (HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            HealthCheckResult.Degraded("The check indicates a degraded result."));
    }
}
