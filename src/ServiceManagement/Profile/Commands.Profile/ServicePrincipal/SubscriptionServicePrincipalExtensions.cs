using Microsoft.WindowsAzure.Management.Models;
using static Microsoft.WindowsAzure.Management.Models.SubscriptionServicePrincipalListResponse;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    public static class SubscriptionServicePrincipalExtensions
    {
        public static ServicePrincipal ToSubscriptionServicePrincipal(this SubscriptionServicePrincipalGetResponse response)
        {
            if (response == null)
                return null;

            return new ServicePrincipal()
            {
                Description = response.Description,
                ExtendedProperties = response.ExtendedProperties,
                ServicePrincipalId = response.ServicePrincipalId
            };
        }
    }
}
