using Chirpel2._0_Common.Models;
using System.Text.Json;

namespace Chirpel2._0.Middlewares
{
    public class ExceptionHandler
    {
        private RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException ex)
            {   
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = ex.StatusCode;
                if (ex.StatusCode == 401 || ex.StatusCode == 402 || ex.StatusCode == 404 || ex.StatusCode == 409 || ex.StatusCode == 500)
                {
                    await response.WriteAsync(JsonSerializer.Serialize(ex.Message));
                    return;
                }
                await response.WriteAsync("");
            }
        }
    }
}
