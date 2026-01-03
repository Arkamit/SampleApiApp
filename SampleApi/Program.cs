using SampleApi.Endpoints;
using SampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.MapAllHealthChecks();

app.ApplyCorsConfig();
app.AddRootEndpoints();
app.AddErrorEndpoints();
app.AddMoviesEndpoints();

app.Run();