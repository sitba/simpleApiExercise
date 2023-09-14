using simpleApiExercise.Common.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace simpleApiExercise.Middlewares
{
	public class ExceptionHandler: IExceptionHandler
	{
        public Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ExceptionResponse response = new ExceptionResponse(Text.ErrorCodes.InternalError, Text.ErrorDescriptions.InternalError);
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        public Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";
            ExceptionResponse response = new ExceptionResponse(Text.ErrorCodes.NotFound, ex.Message);
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        public Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            // it is generally understood that 400 means Bad Request and 401 means Unauthorized.
            // however, this project requires we define 401 for Bad Request
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            ExceptionResponse response = new ExceptionResponse(Text.ErrorCodes.BadRequest, ex.Message);
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        public Task HandleValidationExceptionAsync(HttpContext context, FluentValidation.ValidationException ex)
        {
            // it is generally understood that 400 means Bad Request and 401 means Unauthorized.
            // however, this project requires we define 401 for Bad Request
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            ExceptionResponse response = new ExceptionResponse(Text.ErrorCodes.BadRequest, ex.Message);
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

