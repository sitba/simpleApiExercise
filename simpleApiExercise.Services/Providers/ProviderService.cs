using simpleApiExercise.DTOs.Providers;
using simpleApiExercise.Database;
using simpleApiExercise.Model.Providers;
using simpleApiExercise.Services.Utils.Validation;
using AutoMapper;

namespace simpleApiExercise.Services.Providers
{
    public class ProviderService: IProviderService
    {
        private readonly ISharedValidationsService _sharedValidationService;
        private readonly IMapper _mapper;

        public ProviderService(ISharedValidationsService sharedValidationService, IMapper mapper)
        {
            _sharedValidationService = sharedValidationService;
            _mapper = mapper;
        }

        public List<CreateProviderResponseDto> Import(List<CreateProviderDto> providers)
        {
            _sharedValidationService.ValidateAlreadyDefined(providers, nameof(Provider));
            var newProviders = _mapper.Map<List<Provider>>(providers);
            using (var db = new ProvidersContext())
            {
                db.Providers.AddRange(newProviders);
                db.SaveChanges();
            }
            List<CreateProviderResponseDto> createdProviders = _mapper.Map<List<CreateProviderResponseDto>>(newProviders);
            return createdProviders;
        }

        public GetProviderDto Get(int id)
        {
            Provider? provider;
            using (var db = new ProvidersContext())
            {
                db.Providers.RemoveRange(db.Providers.ToList());
                db.SaveChanges();
                //provider = db.Providers.Find(id);
            }
            return new GetProviderDto();
            //_sharedValidationService.ValidateNotFound(provider, nameof(Provider), id);
            //var result = _mapper.Map<GetProviderDto>(provider);  
            //return result;
        }
    }
}