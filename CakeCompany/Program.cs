// See https://aka.ms/new-console-template for more information

using CakeCompany.Constants;
using CakeCompany.Logging;
using CakeCompany.Provider;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {
        //Used LoggerFactory to log messages
        ILoggerFactory loggerFactory = LoggingProvider.SetLogger();
        ILogger logger = loggerFactory.CreateLogger<Program>();    

        logger.LogInformation(CakeCompanyConstants.OrderDetails);
        ShipmentProvider.GetShipment();        
    }

}
