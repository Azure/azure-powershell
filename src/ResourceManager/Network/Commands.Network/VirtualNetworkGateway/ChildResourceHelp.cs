// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using System;

namespace Microsoft.Azure.Commands.Network
{
    public static class ChildResourceHelp
    {
        //vnetGatewayIpConfig.Id =
        //        ChildResourceHelper.GetResourceNotSetId(
        //            this.NetworkClient.NetworkManagementClient.SubscriptionId,
        //            Microsoft.Azure.Commands.Network.Properties.Resources.VirtualNetworkGatewayIpConfigName,
        //            this.Name);

        public static string GetResourceId(
            string subscriptionId,
            string resourceGroupName,
            string virtualNetworkGatewayName,
            string resource,
            string resourceName)
        {
            return string.Format(
                Microsoft.Azure.Commands.Network.Properties.Resources.VirtualNetworkGatewayChildResourceId,
                subscriptionId,
                resourceGroupName,
                virtualNetworkGatewayName,
                resource,
                resourceName);
        }

        public static string GetResourceNotSetId(string subscriptionId, string resource, string resourceName)
        {
            return string.Format(
                Microsoft.Azure.Commands.Network.Properties.Resources.VirtualNetworkGatewayChildResourceId,
                subscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                Microsoft.Azure.Commands.Network.Properties.Resources.VirtualNetworkGatewayNameNotSet,
                resource,
                resourceName);
        }

        private static string NormalizeVirtualNetworkGatewayChildResourceIds(string id, string resourceGroupName, string VirtualNetworkGatewayName)
        {
            id = NormalizeId(id, "resourceGroups", resourceGroupName);
            id = NormalizeId(id, "virtualNetworkGateways", VirtualNetworkGatewayName);

            return id;
        }

        private static string NormalizeId(string id, string resourceName, string resourceValue)
        {
            int startIndex = id.IndexOf(resourceName, StringComparison.OrdinalIgnoreCase) + resourceName.Length + 1;
            int endIndex = id.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            // Replace the following string '/{value}/'
            startIndex--;
            string orignalString = id.Substring(startIndex, endIndex - startIndex + 1);

            return id.Replace(orignalString, string.Format("/{0}/", resourceValue));
        }

        public static void NormalizeChildResourcesId(PSVirtualNetworkGateway virtualNetworkGateway)
        {
            // Normalize FrontendIpconfig
            if (virtualNetworkGateway.IpConfigurations != null)
            {
                foreach (var ipConfig in virtualNetworkGateway.IpConfigurations)
                {
                    ipConfig.Id = string.Empty;
                }
            }
        }
    }
}
