using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Apartment.Service.Controllers
{
  public abstract class BaseController : Controller
  {
    protected readonly ILogger logger;
    protected readonly IQueueClient queueClient;
    protected readonly string connectionString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING");
    protected readonly string queueName = Environment.GetEnvironmentVariable("SERVICE_BUS_QUEUE_NAME");

    protected BaseController(ILoggerFactory loggerFactory)
    {
      logger = loggerFactory.CreateLogger(this.GetType().Name);
      queueClient = new QueueClient(connectionString, queueName);
    }
  }
}
