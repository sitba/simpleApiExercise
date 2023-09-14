using System.ComponentModel.DataAnnotations;
using simpleApiExercise.Common.Exceptions;

namespace simpleApiExercise.Middlewares
{
	public interface IExceptionHandler
	{
        Task HandleExceptionAsync(HttpContext context, Exception ex);
        Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException ex);
        Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex);
        Task HandleValidationExceptionAsync(HttpContext context, FluentValidation.ValidationException ex);
    }
}