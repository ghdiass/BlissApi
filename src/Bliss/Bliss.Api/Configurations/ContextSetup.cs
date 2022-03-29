using Bliss.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bliss.Api.Configurations
{
    public static class ContextSetup
    {
        public static void AddBlissContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlissContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
