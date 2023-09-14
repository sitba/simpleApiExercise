using System.Text.Json.Serialization;

namespace simpleApiExercise.DTOs.Providers
{
	public class CreateProviderResponseDto
	{
        public CreateProviderResponseDto() { }

        public CreateProviderResponseDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonPropertyName("provider_id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}