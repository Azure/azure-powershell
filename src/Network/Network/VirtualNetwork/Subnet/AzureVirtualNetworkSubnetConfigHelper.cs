using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureVirtualNetworkSubnetConfigHelper
    {
        public void ConfigureServiceEndpoint(string[] serviceEndpoint, PSResourceId networkIdentifier, PSServiceEndpoint[] serviceEndpointConfig, PSSubnet subnet)
        {
            subnet.ServiceEndpoints = new List<PSServiceEndpoint>();
            if (serviceEndpoint != null)
            {
                foreach (var item in serviceEndpoint)
                {
                    var service = new PSServiceEndpoint();
                    service.Service = item;
                    if (networkIdentifier != null)
                    {
                        service.NetworkIdentifier = new PSResourceId();
                        service.NetworkIdentifier = networkIdentifier;
                    }
                    subnet.ServiceEndpoints.Add(service);
                }
            }

            if (serviceEndpointConfig != null)
            {
                foreach (var item in serviceEndpointConfig)
                {
                    var service = new PSServiceEndpoint();
                    service.Service = item.Service;
                    if (item.NetworkIdentifier != null)
                    {
                        RemoveExistingServiceWithoutIdentifier(subnet, item);
                        service.NetworkIdentifier = new PSResourceId();
                        service.NetworkIdentifier = item.NetworkIdentifier;
                    }
                    subnet.ServiceEndpoints.Add(service);
                }
            }
        }

        public bool MultipleNetworkIdentifierExists(PSServiceEndpoint[] serviceEndpointConfig)
        {
            return serviceEndpointConfig?.Select(s => s.NetworkIdentifier).Where(id => id != null).GroupBy(p => p.Id).Count() > 1;
        }

        private void RemoveExistingServiceWithoutIdentifier(PSSubnet subnet, PSServiceEndpoint item)
        {
            //delete any existing Service with the same name but without NetworkIdentier
            var existingService = subnet.ServiceEndpoints.FirstOrDefault(s => s.Service == item.Service && s.NetworkIdentifier == null);
            if (existingService != null)
            {
                subnet.ServiceEndpoints.Remove(existingService);
            }
        }
    }
}
