using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Bliss.Api.Configurations
{
    public static class ControllerSetup
    {
        public static void AddController(this IServiceCollection services)
        {
            services.AddControllers()
            .AddDataAnnotationsLocalization()
            .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public static void UseController(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
