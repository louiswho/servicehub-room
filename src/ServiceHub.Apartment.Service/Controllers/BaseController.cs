using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Apartment.Service.Controllers
{
  public abstract class BaseController : Controller
  {
    protected readonly ILogger logger;
    protected readonly IQueueClient queueClient;
    protected abstract void UseReceiver();
    protected abstract void UseSender();

    protected BaseController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
    {
      logger = loggerFactory.CreateLogger(this.GetType().Name);
      queueClient = queueClientSingleton;
    }

    protected virtual async Task ReceiverMessageProcessAsync(Message message, CancellationToken cancellationToken)
    {
      logger.LogInformation(message.MessageId);
      await queueClient.CompleteAsync(message.SystemProperties.LockToken);
    }

    protected virtual async Task SenderMessageProcessAsync(Message message)
    {
      logger.LogInformation(message.MessageId);
      await queueClient.SendAsync(message);
    }

    protected virtual async Task ReceiverExceptionHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
      logger.LogError(exceptionReceivedEventArgs.Exception.ToString());
      await Task.CompletedTask;
    }
  }
}
