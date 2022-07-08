using CakeCompany.Models;

namespace CakeCompany.Provider;

/// <summary>
/// PaymentProvider - Process payment to check for the client validity
/// </summary>
internal class PaymentProvider
{
    public static PaymentIn Process(Order order)
    {
        if (order.ClientName.Contains("Important"))
        {
            return new PaymentIn
            {
                HasCreditLimit = false,
                IsSuccessful = true
            };
        }

        return new PaymentIn
        {
            HasCreditLimit = true,
            IsSuccessful = true
        };
    }
}