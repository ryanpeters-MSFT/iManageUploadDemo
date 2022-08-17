using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddHttpClient();
                services.AddTransient<HttpClientUpload>();
            });

        var app = builder.Build();

        var uploadClient = app.Services.GetService<HttpClientUpload>();

        uploadClient.UploadFileAsync().GetAwaiter().GetResult();
    }
}