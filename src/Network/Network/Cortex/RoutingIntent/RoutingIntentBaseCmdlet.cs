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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class RoutingIntentBaseCmdlet : NetworkBaseCmdlet
    {
        public IRoutingIntentOperations RoutingIntentClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.RoutingIntent;
            }
        }

        public PSRoutingIntent ToPsRoutingIntent(MNM.RoutingIntent routingIntent)
        {
            var psRoutingIntent = NetworkResourceManagerProfile.Mapper.Map<PSRoutingIntent>(routingIntent);

            return psRoutingIntent;
        }

        public PSRoutingIntent GetRoutingIntent(string resourceGroupName, string virtualHubName, string name)
        {
            var routingIntent = RoutingIntentClient.Get(resourceGroupName, virtualHubName, name);
            var psRoutingIntent = ToPsRoutingIntent(routingIntent);

            return psRoutingIntent;
        }

        public List<PSRoutingIntent> ListRoutingIntents(string resourceGroupName, string virtualHubName)
        {
            var routingIntents = RoutingIntentClient.List(resourceGroupName, virtualHubName);

            List<PSRoutingIntent> routingIntentsToReturn = new List<PSRoutingIntent>();
            if (routingIntents != null)
            {
                foreach (MNM.RoutingIntent routingIntent in routingIntents)
                {
                    routingIntentsToReturn.Add(ToPsRoutingIntent(routingIntent));
                }
            }

            return routingIntentsToReturn;
        }

        public PSRoutingIntent CreateOrUpdateRoutingIntent(string resourceGroupName, string virtualHubName, string routingIntentName, PSRoutingIntent routingIntent)
        {
            var routingIntentModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RoutingIntent>(routingIntent);
            var routingIntentCreated = RoutingIntentClient.CreateOrUpdate(resourceGroupName, virtualHubName, routingIntentName, routingIntentModel);
            return ToPsRoutingIntent(routingIntentCreated);
        }

        public bool IsRoutingIntentPresent(string resourceGroupName, string parentHubName)
        {
            return ListRoutingIntents(resourceGroupName, parentHubName).Count > 0;
        }

        public void IsParentVirtualHubPresent(string resourceGroupName, string parentHubName)
        {
            // Get the virtual hub - this will throw not found if the resource does not exist
            PSVirtualHub resolvedVirtualHub = new VirtualHubBaseCmdlet().GetVirtualHub(resourceGroupName, parentHubName);
            if (resolvedVirtualHub == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentVirtualHubNotFound);
            }
        }
    }
}