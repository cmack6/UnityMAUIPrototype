using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.Services.AddSingleton<LocalWebServer>();

        var app = builder.Build();

        var webServer = app.Services.GetRequiredService<LocalWebServer>();
        webServer.StartServer(); // Start the local server

        return app;
    }
}
