using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Filters;

namespace simpleApiExercise.ActionFilters
{
    public class InputValidationActionFilter : IActionFilter
    {
        // execute before controller action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string errors = string.Join(" | ", context.ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }

        //execute after controller action
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}