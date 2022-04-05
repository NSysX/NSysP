using Application.Exceptions;
using Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json;
using WebAPI.Extensions;

namespace WebAPI.Middleware
{
    public class ManejadorErroresMiddleware
    {
        private readonly RequestDelegate _next;

        public ManejadorErroresMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await this._next(httpContext);
            }
            catch (Exception error)
            {
                // necesitamos Arrojar algo
                var respuesta = httpContext.Response;
                respuesta.ContentType = "application/json";

                // se le va a dar un modelo  a la respuesta
                var respuestaModelo = new Respuesta<string>()
                {
                    Succeeded = false,
                    Message = error?.Message
                };

                switch (error)
                {
                    case ExcepcionDeApi e:
                        // perzonalidado
                        // se empieza a llenar el objeto ModeloRespuesta
                        respuesta.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case ExcepcionDeValidacion e:
                        // validacion personalizada error
                        // se agrega el modelo
                        respuesta.StatusCode = StatusCodes.Status400BadRequest;
                        respuestaModelo.Errors = e.Errores;
                        break;
                    case KeyNotFoundException e:
                        // no se encontro 
                        respuesta.StatusCode = StatusCodes.Status404NotFound;
                        // aqui agarra el error que tenemos por default de modeloRespuesta
                        break;
                    case DbUpdateException e:
                        respuesta.StatusCode = StatusCodes.Status400BadRequest;
                        respuestaModelo.Errors = new();
                        respuestaModelo.Message = String.Format(CultureInfo.CurrentCulture, e.Message);
                        respuestaModelo.Errors.Add(e.ObtenTodosLosMsjs()); // .InnerException.Message
                        break;
                    default:
                        // excepcion no manejada
                        respuesta.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                var resultado = JsonSerializer.Serialize(respuestaModelo);
                await respuesta.WriteAsync(resultado);
            }
        }
    }
}
