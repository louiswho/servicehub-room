using Microsoft.Extensions.Logging;

namespace ServiceHub.Room.Service
{
    public static class ServiceLogging
    {
        private static ILoggerFactory _factory = null;
        private static string _category;

        public static void Configure(string category)
        {
            _category = category;
        }

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new LoggerFactory();
                }

                return _factory;
            }

            set => _factory = value;
        }

        public static ILogger Create()
        {
            return LoggerFactory.CreateLogger(_category);
        }
    }
}