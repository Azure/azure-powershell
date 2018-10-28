using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Management.Models;
using static Microsoft.WindowsAzure.Management.Models.SubscriptionServicePrincipalListResponse;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    public static class SubscriptionServicePrincipalExtensions
    {
        public static PSSubscriptionServicePrincipal ToPSSubscriptionServicePrincipal(this SubscriptionServicePrincipalGetResponse response)
        {
            if (response == null)
                return null;

            return new PSSubscriptionServicePrincipal()
            {
                Description = response.Description,
                ExtendedProperties = response.ExtendedProperties,
                ServicePrincipalId = response.ServicePrincipalId
            };
        }
    }
}
