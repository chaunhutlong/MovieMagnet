using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace MovieMagnet;

public class MovieMagnetWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<MovieMagnetWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
