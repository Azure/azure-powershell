
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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Net;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class ConnectionMonitorBaseCmdlet : NetworkBaseCmdlet
    {
        public IConnectionMonitorsOperations ConnectionMonitors
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ConnectionMonitors;
            }
        }

        public bool IsConnectionMonitorPresent(string resourceGroupName, string name, string connectionMonitorName)
        {
            try
            {
                GetConnectionMonitor(resourceGroupName, name, connectionMonitorName);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSConnectionMonitorResult GetConnectionMonitor(string resourceGroupName, string name, string connectionMonitorName)
        {
            ConnectionMonitorResult connectionMonitor = this.ConnectionMonitors.Get(resourceGroupName, name, connectionMonitorName);
            PSConnectionMonitorResult psConnectionMonitor = NetworkResourceManagerProfile.Mapper.Map<PSConnectionMonitorResult>(connectionMonitor);

            return psConnectionMonitor;
        }

        public ConnectionMonitorDetails GetConnectionMonitorDetails(string resourceId)
        {
            ConnectionMonitorDetails cmDetails = new ConnectionMonitorDetails();

            ResourceIdentifier connectionMonitorInfo = new ResourceIdentifier(resourceId);

            cmDetails.ConnectionMonitorName = connectionMonitorInfo.ResourceName;
            cmDetails.ResourceGroupName = connectionMonitorInfo.ResourceGroupName;

            string parent = connectionMonitorInfo.ParentResource;
            string[] tokens = parent.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            cmDetails.NetworkWatcherName = tokens[1];

            return cmDetails;
        }

        public MNM.NetworkWatcher GetNetworkWatcherByLocation(string location)
        {
            var nwList = this.NetworkClient.NetworkManagementClient.NetworkWatchers.ListAll();
            foreach (var nw in nwList)
            {
                if (nw.Location == location)
                {
                    return nw;
                }
            }

            return null;
        }
    }
}