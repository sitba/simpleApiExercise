namespace simpleApiExercise.Common.Exceptions
{
	public static class Text
	{
		public static class ErrorCodes
		{
            public const string NotFound = "NotFound";
            public const string BadRequest = "Bad Request";
            public const string InternalError = "InternalServerError";
        }

        public static class ErrorDescriptions
        {
            public const string InternalError = "An error server occured.";
        }
    }
}

