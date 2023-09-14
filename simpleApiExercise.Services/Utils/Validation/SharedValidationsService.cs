using simpleApiExercise.Common.Exceptions;
using simpleApiExercise.Database;
using simpleApiExercise.DTOs.Providers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace simpleApiExercise.Services.Utils.Validation
{
	public class SharedValidationsService : ISharedValidationsService
    {
        public void ValidateAlreadyDefined(List<CreateProviderDto> providers, string entity)
        {
            var ids = providers.Select(provider => { return provider.Id; }).ToList();
            var existingIds = new List<int>();
            using (var db = new ProvidersContext())
            {
                existingIds = db.Providers.Select(provider => provider.Id)
                                          .Where(id => ids.Contains(id))
                                          .ToList();
            }
            if (existingIds.Count > 0)
            {
                string alreadyDefinedMessage = $"{entity} with id: {JsonSerializer.Serialize(existingIds)} already defined. Import aborted.";
                throw new ValidationException(alreadyDefinedMessage);
            }
        }

        public void ValidateNotFound(Object result, string entity, int id)
        {
            if (result is null)
            {
                string notFoundMessage = $"The {entity.ToLower()} '{id}' not found.";
                throw new NotFoundException(notFoundMessage);
            }
        }
    }
}

