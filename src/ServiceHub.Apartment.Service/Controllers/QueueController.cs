using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Apartment.Service.Controllers
{
  public class QueueController : BaseController
  {
    private static readonly IQueueClient _queueClient = new QueueClient(_connectionString, _queueName);
    private static readonly string _connectionString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING");
    private static readonly string _queueName = Environment.GetEnvironmentVariable("SERVICE_BUS_QUEUE_NAME");

    public QueueController(ILoggerFactory loggerFactory) : base(loggerFactory) {}

    public static void UseMessagingQueue()
    {
      var queue = new QueueController(new LoggerFactory());
      var messageHandlerOptions = new MessageHandlerOptions(queue.ExceptionHandler)
      {
        AutoComplete = false,
        MaxConcurrentCalls = 1
      };

      _queueClient.RegisterMessageHandler(queue.MessageHandler, messageHandlerOptions);
    }

    private async Task ExceptionHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
      await Task.Run(() => throw new NotImplementedException());
    }

    private async Task MessageHandler(Message message, CancellationToken cancellationToken)
    {
      await Task.Run(() => throw new NotImplementedException());
    }
  }
}
