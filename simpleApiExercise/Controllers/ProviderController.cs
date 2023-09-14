using Microsoft.AspNetCore.Mvc;
using simpleApiExercise.DTOs.Providers;
using simpleApiExercise.Services.Providers;

namespace simpleApiExercise.Controllers
{
    [ApiController]
    [Route("providers")]
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var providerDtoResult = _providerService.Get(id);
            return Ok(providerDtoResult);
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import([FromBody] List<CreateProviderDto> providers)
        {
            var newProviders = _providerService.Import(providers);
            return Ok(newProviders);
        }
    }
}