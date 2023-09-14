using System.ComponentModel.DataAnnotations;
using simpleApiExercise.Common.Exceptions;

namespace simpleApiExercise.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IExceptionHandler _exceptionHandler)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await _exceptionHandler.HandleNotFoundExceptionAsync(context, ex);
            }
            catch (ValidationException ex)
            {
                await _exceptionHandler.HandleValidationExceptionAsync(context, ex);
            }
            catch (FluentValidation.ValidationException ex)
            {
                await _exceptionHandler.HandleValidationExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await _exceptionHandler.HandleExceptionAsync(context, ex);
            }
        }
    }

    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}