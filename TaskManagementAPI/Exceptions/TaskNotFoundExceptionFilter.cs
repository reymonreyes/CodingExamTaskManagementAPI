using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace TaskManagementAPI.Exceptions
{
    public class TaskNotFoundExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if(context.Exception is TaskNotFoundException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.NotFound, context.Exception.Message);
            }
            else
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }
        }
    }
}