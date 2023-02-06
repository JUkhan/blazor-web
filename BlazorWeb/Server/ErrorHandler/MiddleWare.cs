using System.Text.Json;


namespace GlobalErrorHandling.Extensions
{
  public class ErrorDetails
  {
    public int StatusCode { get; set; }
    public List<string> ErrorMessages { set; get; } = new();

    public override string ToString()
    {
      return JsonSerializer.Serialize(this, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
    }
  }
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    //private readonly ILoggerManager _logger;

    public ExceptionMiddleware(RequestDelegate next)
    {
      //_logger = logger;
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception ex)
      {
        //_logger.LogError($"Something went wrong: {ex}");
        await HandleExceptionAsync(httpContext, ex);
      }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      context.Response.ContentType = "application/json";

      var res = new ErrorDetails();
      res.StatusCode = context.Response.StatusCode;
      switch (exception)
      {
        case FluentValidation.ValidationException:
          res.StatusCode = 500;
          var ex = exception as FluentValidation.ValidationException;
          if (ex != null)
            res.ErrorMessages = ex.Errors.Select(m => m.ErrorMessage).ToList();
          break;

        default:
          res.ErrorMessages.Add(exception.Message);
          break;
      }
      context.Response.StatusCode = res.StatusCode;
      await context.Response.WriteAsync(res.ToString());
    }
  }
}