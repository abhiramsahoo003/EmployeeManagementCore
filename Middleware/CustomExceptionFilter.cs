using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementCore.Middleware
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log the exception (e.g., using Serilog, NLog, etc.)
            Console.WriteLine($"Exception: {context.Exception.Message}");

            // Modify the response
            context.Result = new ObjectResult(new
            {
                Message = "An error occurred while processing your request.",
                Details = context.Exception.Message
            })
            {
                StatusCode = 500
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }
    }
}
