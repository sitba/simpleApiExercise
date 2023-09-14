using simpleApiExercise.DTOs.Providers;

namespace simpleApiExercise.Services.Providers
{
	public interface IProviderService
	{
        List<CreateProviderResponseDto> Import(List<CreateProviderDto> providers);
        public GetProviderDto Get(int id);
    }
}