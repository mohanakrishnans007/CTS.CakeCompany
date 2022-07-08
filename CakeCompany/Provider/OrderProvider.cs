
using CakeCompany.Models;

namespace CakeCompany.Provider;

/// <summary>
/// OrderProvider - Gets all the needed order data loaded
/// </summary>
internal class OrderProvider
{
    public static Order[] GetLatestOrders()
    {
        return new Order[]
        {
            new("CakeBox", DateTime.Now, 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25)
        };
    }

}


