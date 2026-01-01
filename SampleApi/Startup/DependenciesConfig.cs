using SampleApi.Data;

namespace SampleApi.Startup;
public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiServices();
        builder.Services.AddCorsServices();
        builder.Services.AddTransient<MoviesData>();
    }
}
