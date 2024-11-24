using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text;

namespace Middleware
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestResponseMiddleware> logger;

        public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }


        public async Task Invoke(HttpContext context)
        {


            var originalBodyStream = context.Response.Body;
            logger.LogInformation($"Query Keys:{context.Request.QueryString}");


            MemoryStream requestBody = new MemoryStream();
            await context.Request.Body.CopyToAsync( requestBody );
            requestBody.Seek( 0, SeekOrigin.Begin );
            string requestTest = await new StreamReader( requestBody ).ReadToEndAsync();
            requestBody.Seek(0, SeekOrigin.Begin);

            var tempStream = new MemoryStream();
            context.Response.Body = tempStream;


            await next.Invoke(context);


            context.Response.Body.Seek(0, SeekOrigin.Begin);
            String responseText = await new StreamReader(context.Response.Body, Encoding.UTF8).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            await context.Response.Body.CopyToAsync(originalBodyStream);

            logger.LogInformation($"Request:{requestTest}");
            logger.LogInformation($"Response:{responseText}");
        }
    }
}
