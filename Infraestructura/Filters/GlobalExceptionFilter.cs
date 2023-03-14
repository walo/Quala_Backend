using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infraestructura.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var validation = new
                {
                    Status = 404,
                    successful = false,
                    Message = exception.Message,
                    data = new string[0]
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            if (context.Exception.GetType() == typeof(NotFoundException))
            {
                var exception = context.Exception;
                var validation = new
                {
                    Status = 404,
                    successful = false,
                    Message = exception.Message,
                    Detail = exception.Message,
                    data = new string[0]
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new NotFoundObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.ExceptionHandled = true;
            }
            else if (context.Exception.GetType() == typeof(DbUpdateException))
            {
                var exception = (DbUpdateException)context.Exception;
                var validation = new
                {
                    Status = HttpStatusCode.BadRequest,
                    successful = false,
                    Message = exception.Message,
                    Detail = exception.InnerException.Message,
                    data = new string[0]
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            else if (context.Exception.GetType() == typeof(UnauthorizedAccessException))
            {
                var exception = context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "No autorizado",
                    Detail = exception.Message,
                    exception.InnerException.Message
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new UnauthorizedObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
