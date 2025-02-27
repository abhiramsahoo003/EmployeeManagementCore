namespace EmployeeManagementCore.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;
            context.Response.Headers.Add("X-Processing-Time-Milliseconds", elapsedTime.ToString());
        }
    }
}
