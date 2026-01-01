using SampleApi.Endpoints;
using SampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.ApplyCorsConfig();
app.AddRootEndpoints();
app.AddMoviesEndpoints();

app.Run();