using System.Text.Json.Serialization;
using FluentValidation;
using simpleApiExercise.Model.Providers;

namespace simpleApiExercise.DTOs.Providers
{
	public class CreateProviderDto
	{
        public CreateProviderDto() { }
        public CreateProviderDto(int? id, string name, string postalAddress, DateTime createdDate, TypeEnum type)
        {
            Id = id;
            Name = name;
            PostalAddress = postalAddress;
            CreatedDate = createdDate;
            Type = type;
        }

        [JsonPropertyName("provider_id")]
        public int? Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("postal_address")]
        public string PostalAddress { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedDate { get; set; }
        [JsonPropertyName("type")]
        public TypeEnum Type { get; set; }
    }

    public class CreateProviderDtoValidator : AbstractValidator<CreateProviderDto>
    {
        public CreateProviderDtoValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class CreateProviderDtoListValidator : AbstractValidator<List<CreateProviderDto>>
    {
        public CreateProviderDtoListValidator()
        {
            RuleForEach(createProviderDto => createProviderDto).SetValidator(new CreateProviderDtoValidator());
        }
    }
}