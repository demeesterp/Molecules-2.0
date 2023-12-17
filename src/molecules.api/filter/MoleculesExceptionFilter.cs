using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using molecules.core.common.errorhandling;
using molecules.shared;

namespace molecules.api.filter
{
    /// <summary>
    /// Will postprocess the exception of a controller action
    /// </summary>
    public class MoleculesExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// process the exception
        /// </summary>
        /// <param name="context">The exception context</param>
        public void OnException(ExceptionContext context)
        {
            GetLogger(context)?.LogError(context.Exception, "An exception was handled by the global exception handler");
            if ( context.Exception is ValidationException validationException)
            {
                context.Result = new UnprocessableEntityObjectResult(new ServiceValidationError()
                {
                    ValidationErrors = validationException
                                        .Errors
                                        .Select(x => new ServiceValidationErrorItem(x.ErrorMessage,x.PropertyName))
                                        .ToList()
                });
            }
            else if (context.Exception is MoleculesResourceNotFoundException moleculesResourceNotFoundException)
            {
                context.Result = new NotFoundObjectResult(new ServiceError()
                {
                    DisplayMessage = moleculesResourceNotFoundException.Message
                });
            }
            else
            {
                context.Result = new ObjectResult(new ServiceError())
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            
            context.ExceptionHandled = true;
        }


        private IMoleculesLogger? GetLogger(ExceptionContext context)
        {
            return context.HttpContext.RequestServices.GetService(typeof(IMoleculesLogger)) as IMoleculesLogger;
        }
    }
}
