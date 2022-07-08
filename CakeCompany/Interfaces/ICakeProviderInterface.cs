

using CakeCompany.Models;

namespace CakeCompany.Interfaces
{
    /// <summary>
    /// ICakeProviderInterface- Interface for Cake provider class
    /// </summary>
    public interface ICakeProviderInterface
    {
        DateTime Check(Order order);
        Product Bake(Order order);
    }
}
