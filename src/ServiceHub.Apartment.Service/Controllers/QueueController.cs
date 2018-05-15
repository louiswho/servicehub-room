using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
      var messageHandlerOptions = new MessageHandlerOptions(queue.ReceiverExceptionHandler)
      {
        AutoComplete = false,
        MaxConcurrentCalls = 1
      };

      _queueClient.RegisterMessageHandler(queue.ReceiverMessageHandler, messageHandlerOptions);
    }

    private async Task ReceiverExceptionHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
      logger.LogError(exceptionReceivedEventArgs.Exception.ToString());
      await Task.CompletedTask;
    }

    private async Task ReceiverMessageHandler(Message message, CancellationToken cancellationToken)
    {
      logger.LogInformation(message.SystemProperties.SequenceNumber.ToString());
      JsonConvert.DeserializeObject(Encoding.UTF8.GetString(message.Body));

      await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
    }
  }
}
