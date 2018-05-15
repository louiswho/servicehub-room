using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceHub.Apartment.Service.Controllers;

namespace ServiceHub.Apartment.Service
{
  public static class Program
  {
    private static readonly QueueController _queueController;

    static Program()
    {
      _queueController = new QueueController();
    }

    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
      _queueController.UseReceiver();
      _queueController.UseSender();
    }

    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseApplicationInsights(Environment.GetEnvironmentVariable("INSTRUMENTATION_KEY"))
        .UseStartup<Startup>()
        .Build();
  }
}
