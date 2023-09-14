using System.Text.Json.Serialization;

namespace simpleApiExercise.Common.Exceptions
{
	public class ExceptionResponse
	{
        public ExceptionResponse(string errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
        [JsonPropertyName("errorDescription")]
        public string ErrorDescription { get; set; }
    }
}