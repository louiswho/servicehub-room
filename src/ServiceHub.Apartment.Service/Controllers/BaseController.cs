using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Apartment.Service.Controllers
{
  public abstract class BaseController : Controller
  {
    protected readonly ILogger logger;
    private static readonly ILoggerFactory loggerFactory = new LoggerFactory();

    protected BaseController()
    {
      logger = loggerFactory.CreateLogger(this.GetType().Name);
    }
  }
}
