using AutoMapper;
using simpleApiExercise.DTOs.Providers;
using simpleApiExercise.Model.Providers;

namespace simpleApiExercise.Mapping.Profiles
{
	public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<CreateProviderDto, Provider>().
                ForMember(dest => dest.Type, act => act.MapFrom(src => Enum.GetName(typeof(TypeEnum), src.Type)));
            CreateMap<Provider, GetProviderDto>();
            CreateMap<Provider, CreateProviderResponseDto>();
        }
	}
}