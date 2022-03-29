using Bliss.Business.Interfaces.Repositories;
using Bliss.Data.Context;
using Bliss.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bliss.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            //Context
            services.AddScoped<BlissContext>();

            //Repository
            services.AddScoped<IQuestionRepository, QuestionRepository>();
        }
    }
}