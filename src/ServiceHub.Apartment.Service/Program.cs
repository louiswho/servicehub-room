using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceHub.Apartment.Service.Controllers;

namespace ServiceHub.Apartment.Service
{
  public static class Program
  {
    private static readonly ILoggerFactory _loggerFactory = new LoggerFactory();
    private static readonly IQueueClient _queueClient = new QueueClient(_connectionString, _queueName);
    private static readonly string _connectionString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING");
    private static readonly string _queueName = Environment.GetEnvironmentVariable("SERVICE_BUS_QUEUE_NAME");
    
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
      QueueAsync().GetAwaiter().GetResult();
    }

    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseApplicationInsights(Environment.GetEnvironmentVariable("INSTRUMENTATION_KEY"))
        .UseStartup<Startup>()
        .Build();
    
    private static async Task QueueAsync()
    {
      var queue = new QueueController(_loggerFactory);
      await Task.Run(() => {});
    }
  }
}
