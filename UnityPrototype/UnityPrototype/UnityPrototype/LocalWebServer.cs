using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

public class LocalWebServer
{
    private IHost? _host;
    private readonly string _url = "http://localhost:5000";

    public void StartServer()
    {
        string unityBuildPath = @"C:\Users\wolfm\OneDrive\Documents\GitHub\UnityMAUIPrototype\BallBouncing";

        if (!Directory.Exists(unityBuildPath))
        {
            throw new DirectoryNotFoundException($"The directory '{unityBuildPath}' does not exist.");
        }
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IWebHost>(_ => new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls(_url)
                    .Configure(app =>
                    {
                        app.UseStaticFiles(new StaticFileOptions
                        {
                            FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(unityBuildPath),
                            RequestPath = ""
                        });
                    })
                    .Build());
            })
            .Build();

        Task.Run(() => _host.Run());
    }
}
