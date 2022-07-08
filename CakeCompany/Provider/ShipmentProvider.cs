using CakeCompany.Models;
using CakeCompany.Models.Transport;
using CakeCompany.Constants;
using Microsoft.Extensions.Logging;
using CakeCompany.Logging;

namespace CakeCompany.Provider;

/// <summary>
/// ShipmentProvider -  will provide shipment details based on the orders received
/// </summary>
public class ShipmentProvider
{
    //Private Logger variables
    private static readonly ILoggerFactory _loggerFactory = LoggingProvider.SetLogger();
    private static readonly ILogger _logger = _loggerFactory.CreateLogger<ShipmentProvider>();


    /// <summary>
    /// GetShipment - will get the orders process for shipment
    /// </summary>
    public static void GetShipment()
    {
        //Call order to get new orders  
        var orders = OrderProvider.GetLatestOrders();

        if (!orders.Any())
        {            
            _logger.LogError(CakeCompanyConstants.NoOrdersFoundError);
            return;
        }

        List<Product> products = ValidateOrderAndBake(orders);
        GetTransportAndDeliver(products);
    }

    /// <summary>
    /// ValidateOrderAndBake- Validate the orders and send for baking
    /// </summary>
    /// <param name="orders"></param>
    /// <returns></returns>
    private static List<Product> ValidateOrderAndBake(Order[] orders)
    {
        var cancelledOrders = new List<Order>();
        var products = new List<Product>();

        foreach (var order in orders)
        {
            var cakeProvider = new CakeProvider();
            var estimatedBakeTime = cakeProvider.Check(order);

            if (estimatedBakeTime > order.EstimatedDeliveryTime)
            {
                cancelledOrders.Add(order);
                _logger.LogError(CakeCompanyConstants.OrderCancellationBakeTimeError + order);
                continue;
            }


            if (!PaymentProvider.Process(order).IsSuccessful)
            {
                cancelledOrders.Add(order);
                _logger.LogError(CakeCompanyConstants.OrderCancellationCreditError + order);
                continue;
            }

            var product = cakeProvider.Bake(order);
            products.Add(product);
        }

        return products;
    }

    /// <summary>
    /// GetTransportAndDeliver - Will Deliver the products based on the Transport decided.
    /// </summary>
    /// <param name="products"></param>
    public static void GetTransportAndDeliver(List<Product> products)
    {
        var transport = TransportProvider.CheckForAvailability(products);

        switch (transport)
        {
            case CakeCompanyConstants.Van:
                var van = new Van();
                van.Deliver(products);
                _logger.LogInformation(CakeCompanyConstants.OrderSuccessVanDelivery);
                break;

            case CakeCompanyConstants.Truck:
                var truck = new Truck();
                truck.Deliver(products);
                _logger.LogInformation(CakeCompanyConstants.OrderSuccessTruckDelivery);
                break;

            default:
                var ship = new Ship();
                ship.Deliver(products);
                _logger.LogInformation(CakeCompanyConstants.OrderSuccessShipDelivery);
                break;
        }
    }
}
