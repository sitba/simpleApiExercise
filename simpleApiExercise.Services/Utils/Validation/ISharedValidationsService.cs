using simpleApiExercise.DTOs.Providers;

namespace simpleApiExercise.Services.Utils.Validation
{
	public interface ISharedValidationsService
	{
        void ValidateNotFound(Object result, string entity, int id);
        void ValidateAlreadyDefined(List<CreateProviderDto> providers, string entity);
    }
}