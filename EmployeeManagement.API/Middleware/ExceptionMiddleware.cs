using System.Text.Json;
using EmployeeManagement.Application.Exceptions;
using Microsoft.Identity.Client;

namespace EmployeeManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        //objeto que representa toda la informacion de la peticion HTTP actual:
        //incluye datos de la solicitur(headers, metodo, ruta, cuerpo, etc.)
        //Datos de respuesta (status code, headers, body, etc.)
        //Usuario autenticad
        //Servicios y dependencias
        //informacion de la sesion
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                switch (ex)
                {
                    case EmailAlreadyExistsException:
                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                        break;
                    case EmployeeDontExistsException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                var respone = new { error = ex.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(respone));
            }
        }
    }
}