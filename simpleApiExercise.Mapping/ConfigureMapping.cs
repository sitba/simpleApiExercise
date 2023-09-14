using Microsoft.Extensions.DependencyInjection;

namespace simpleApiExercise.Mapping
{
	public static class ConfigureMapping
	{
        public static void RegisterAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}