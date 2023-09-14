using System.Text.Json.Serialization;

namespace simpleApiExercise.DTOs.Providers
{
	public class GetProviderDto
	{
        public GetProviderDto() { }

        public GetProviderDto(int id, string name, string postalAddress, DateTime createdDate)
        {
            Id = id;
            Name = name;
            PostalAddress = postalAddress;
            CreatedDate = createdDate;
        }

        [JsonPropertyName("provider_id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("postal_address")]
        public string PostalAddress { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedDate { get; set; }
    }
}

