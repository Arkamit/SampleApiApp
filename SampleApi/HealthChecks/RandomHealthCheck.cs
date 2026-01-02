using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SampleApi.HealthChecks;
public class RandomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync
        (HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        int randomValue = Random.Shared.Next(1, 4);

        return randomValue switch
        {
            1 => Task.FromResult(
                HealthCheckResult.Healthy("The check indicates a random healthy result.")),
            2 => Task.FromResult(
                HealthCheckResult.Degraded("The check indicates a random degraded result.")),
            3 => Task.FromResult(
                HealthCheckResult.Unhealthy("The check indicates a random unhealthy result.")),
            _ => Task.FromResult(
                HealthCheckResult.Healthy("The check indicates a random default result.")),
        };
    }
}
