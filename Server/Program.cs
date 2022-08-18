using Microsoft.AspNetCore.Http.Features;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddHttpClient();

        builder.Services.Configure<FormOptions>(f =>
        {
            f.MultipartBodyLengthLimit = long.MaxValue;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}