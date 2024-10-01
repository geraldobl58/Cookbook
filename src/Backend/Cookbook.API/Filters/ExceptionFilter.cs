using Cookbook.Communication.Responses;
using Cookbook.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Cookbook.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CookbookException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowException(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidateException)
            { 
                var exception = context.Exception as ErrorOnValidateException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
            }
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson("Houve um erro no servidor!"));
        }
    }
}
