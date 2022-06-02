using GameProject.Json;
using Newtonsoft.Json;
using System.Net;

namespace GameProject.Infra
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var classe = ex.TargetSite.DeclaringType.FullName + "." + ex.TargetSite.Name;
                string dados = null;
                if (context.Request.QueryString.HasValue)
                    dados = context.Request.QueryString.Value;
                else
                    dados = context.Request.ToString();

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.BadRequest; // 500 if unexpected

            var result = JsonConvert.SerializeObject(new JsonRetornoDefault("Ocorreu um erro ao processar a solicitação."));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
