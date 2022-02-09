using System.Net;
using System.Text.Json;
using ExceptionHandlingTutorial.CustomExceptions;
using ExceptionHandlingTutorial.Dtos;

namespace ExceptionHandlingTutorial.Middlewares
{
    public class CustomExceptionHandlerMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BadHttpRequestException e)
            {

                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new UniversalResponseDto()
                {
                    statusCode = (int) HttpStatusCode.BadRequest,
                    message = e.Message,
                    success = false
                });
            }
            catch (CustomUnprocessableEntityException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new UniversalResponseDto()
                {
                    statusCode = (int)HttpStatusCode.UnprocessableEntity,
                    message = e.Message,
                    success = false,
                    data = e.ErrorsList
                });
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new UniversalResponseDto()
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = e.Message,
                    success = false
                });
            }
        }
    }
}
