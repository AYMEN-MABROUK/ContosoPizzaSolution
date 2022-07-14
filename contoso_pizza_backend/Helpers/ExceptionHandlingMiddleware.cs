
using System.Net;
using System.Text.Json;
using contoso_pizza_backend.Models.DTO.Response;

namespace contoso_pizza_backend.Helpers
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware (ILogger<ExceptionHandlingMiddleware> logger)
        {
             _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //var action=context.Items["action"].ToString();
            try
            {
                await next(context);
            }
            catch (ApplicationNotFoundException ex)
            {
                var responseCode = (int)HttpStatusCode.NotFound;
                context.Response.StatusCode = responseCode;
                var action = context.Items["action"]==null? "": context.Items["action"].ToString(); 
                //_logger.LogError(ex.ToString(),action); 
                var response= new ResponseFailure(ex.Message, action, responseCode);
                string jsonResponse= JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }
            catch (ApplicationValidationException ex)
            {
                var responseCode = (int)HttpStatusCode.BadRequest;
                context.Response.StatusCode = responseCode;
                var action = context.Items["action"]==null? "": context.Items["action"].ToString(); 
               // _logger.LogError(ex.ToString(),action); 
                var response= new ResponseFailure(ex.Message, action, responseCode);
                string jsonResponse= JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }
            catch (Exception ex)
            {
                var responseCode = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = responseCode;
                var action = context.Items["action"]==null? "": context.Items["action"].ToString(); 
               // _logger.LogError(ex.ToString(),action); 
                var response= new ResponseFailure(ex.ToString() , action, responseCode);
                string jsonResponse= JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}