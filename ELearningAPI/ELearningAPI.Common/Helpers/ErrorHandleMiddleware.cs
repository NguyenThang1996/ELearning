using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
namespace ELearningAPI.Common.Helpers
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>Initializes a new instance of the <see cref="ErrorHandlerMiddleware" /> class.</summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>Invokes the specified context.</summary>
        /// <param name="context">The context.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                switch (ex)
                {
                    case AppException eex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        _logger.LogError(ex, ex.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                ExceptionLog.GetException(ex, "ErrorHandlerMiddleware", "Invoke");
                //await using (StreamWriter sr = File.AppendText("LogException.txt"))
                //{

                //    sr.WriteLine("=>" + DateTime.Now + " " + " An Error occurred: " + ex.StackTrace +
                //        " Message: " + ex.Message + "\n\n");
                //    sr.Flush();
                //}
                //var result = JsonSerializer.Serialize(new { message = error?.Message });
                //await response.WriteAsync(result);
            }
        }
    }
}
