using CakeCompany.Constants;
using CakeCompany.Models;

namespace CakeCompany.Provider;

/// <summary>
/// TransportProvider - will be used to decide on mode of transport
/// </summary>
internal class TransportProvider
{
    /// <summary>
    /// CheckForAvailability - Checks for availabilit and Mode of Transport based on quantity
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    public static string CheckForAvailability(List<Product> products)
    {
        if (products.Sum(p => p.Quantity) < 1000)
        {
            return CakeCompanyConstants.Van;
        }

        if (products.Sum(p => p.Quantity) > 1000 && products.Sum(p => p.Quantity) < 5000)
        {
            return CakeCompanyConstants.Truck;
        }

        return CakeCompanyConstants.Ship;
    }
}
