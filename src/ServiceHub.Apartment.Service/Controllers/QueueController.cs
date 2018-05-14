using Microsoft.Extensions.Logging;

namespace ServiceHub.Apartment.Service.Controllers
{
  public class QueueController : BaseController
  {
    public QueueController(ILoggerFactory loggerFactory) : base(loggerFactory) {}
  }
}
