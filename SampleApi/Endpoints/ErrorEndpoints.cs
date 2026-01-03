namespace SampleApi.Endpoints;

public static class ErrorEndpoints
{
    public static void AddErrorEndpoints(this WebApplication app)
    {
        app.MapGet("/error/{code}", (int code) =>
        {
            return code switch
            {
                400 => Results.BadRequest(),
                401 => Results.Unauthorized(),
                403 => Results.Forbid(),
                404 => Results.NotFound(),
                _ => Results.StatusCode(code),
            };
        });
    }
}
