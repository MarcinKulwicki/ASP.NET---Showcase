using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Web_App___Showcase.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _stopWatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopWatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();

            await next.Invoke(context);

            _stopWatch.Stop();
            _logger.LogInformation($"Request [{context.Request.Method}] at [{context.Request.Path}] took {GetTime(_stopWatch)} ms");
        }

        private string GetTime(Stopwatch stopwatch)
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}.{1:000}",
            ts.Seconds,
            ts.Milliseconds);

            return elapsedTime;
        }
    }
}
