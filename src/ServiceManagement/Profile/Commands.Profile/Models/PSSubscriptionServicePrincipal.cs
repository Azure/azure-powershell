using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.WindowsAzure.Management.Models.SubscriptionServicePrincipalListResponse;

namespace Microsoft.WindowsAzure.Commands.Profile.Models
{
    public class PSSubscriptionServicePrincipal
    {
        public PSSubscriptionServicePrincipal() { }

        public PSSubscriptionServicePrincipal(ServicePrincipal servicePrincipal)
        {
            Description = servicePrincipal.Description;
            ExtendedProperties = servicePrincipal.ExtendedProperties;
            ServicePrincipalId = servicePrincipal.ServicePrincipalId;
        }

        public string Description { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; set; }

        public string ServicePrincipalId { get; set; }
    }
}
