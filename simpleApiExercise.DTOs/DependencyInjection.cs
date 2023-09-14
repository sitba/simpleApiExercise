using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using simpleApiExercise.DTOs.Providers;

namespace simpleApiExercise.DTOs
{
	public static class DependencyInjection
	{
        public static void ConfigureDtoValidations(this IServiceCollection services)
        {
			services.AddScoped<IValidator<CreateProviderDto>, CreateProviderDtoValidator>();
            services.AddScoped<IValidator<List<CreateProviderDto>>, CreateProviderDtoListValidator>();
        }
	}
}