using MediatR;
using System.Reflection;
using WebsiteStatusAPI.Controllers;

public class Startup
{ 

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public static IConfiguration Configuration { get; private set; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<WebsiteStatusController>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(WebsiteStatusController).GetTypeInfo().Assembly));
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}