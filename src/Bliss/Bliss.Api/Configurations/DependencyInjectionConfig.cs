using Bliss.Business.Interfaces.Notification;
using Bliss.Business.Interfaces.Repositories;
using Bliss.Business.Interfaces.Services;
using Bliss.Business.Notification;
using Bliss.Business.Services;
using Bliss.Data.Context;
using Bliss.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bliss.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BlissContext>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IChoiceRepository, ChoiceRepository>();

            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<INotifier, Notifier>();
        }
    }
}