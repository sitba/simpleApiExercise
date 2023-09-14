using Microsoft.Extensions.DependencyInjection;
using simpleApiExercise.Services.Providers;
using simpleApiExercise.Services.Utils.Validation;

namespace simpleApiExercise.Services
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<ISharedValidationsService, SharedValidationsService>();
        }
    }
}
