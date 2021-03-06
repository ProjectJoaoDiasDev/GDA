using GDA.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GDA.Web.Filters
{
    /// <summary>
    /// The custom exception filter.
    /// </summary>
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Ons the exception.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            if (isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;
                var message = context.Exception is DomainException ? context.Exception.Message : "An error ocurred";
                context.Result = new JsonResult(message);
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
