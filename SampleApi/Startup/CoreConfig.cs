using Scalar.AspNetCore;

namespace SampleApi.Startup;

public static class CoreConfig
{
    private const string AllowAllCorsPolicy = "AllowAll";

    public static void AddCorsServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AllowAllCorsPolicy, policy =>
            {
                policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }

    public static void ApplyCorsConfig(this WebApplication app)
    {
        app.UseCors(AllowAllCorsPolicy);
    }
}
