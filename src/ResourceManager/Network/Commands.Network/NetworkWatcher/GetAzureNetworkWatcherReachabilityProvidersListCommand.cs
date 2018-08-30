﻿// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.Automation
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherReachabilityProvidersList", DefaultParameterSetName = "SetByName"), OutputType(typeof(PSAvailableProvidersList))]
    public class GetAzureRmNetworkWatcherAvailableProviders : NetworkWatcherBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network watcher resource.",
            ParameterSetName = "SetByResource")]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("ResourceName", "Name")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocation")]
        [LocationCompleter("Microsoft.Network/networkWatchers")]
        [ValidateNotNull]
        public string NetworkWatcherLocation { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id of network watcher resource.",
            ParameterSetName = "SetByResourceId")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Optional Azure regions to scope the query to.")]
        [LocationCompleter("Microsoft.Network/networkWatchers")]
        public List<string> Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the country.")]
        public string Country { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the state.")]
        public string State { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the city.")]
        public string City { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vAvailableProvidersListParameters = new AvailableProvidersListParameters
            {
                AzureLocations = this.Location,
                Country = this.Country,
                State = this.State,
                City = this.City,
            };

            if (string.Equals(this.ParameterSetName, "SetByLocation", StringComparison.OrdinalIgnoreCase))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.NetworkWatcherLocation);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.NetworkWatcherLocation);
                }

                ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                NetworkWatcherName = networkWatcher.Name;
            }

            if (string.Equals(this.ParameterSetName, "SetByResource", StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                NetworkWatcherName = this.NetworkWatcher.Name;
            }

            if (string.Equals(this.ParameterSetName, "SetByResourceId", StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                NetworkWatcherName = resourceInfo.ResourceName;
            }

            var vNetworkWatcherResult = this.NetworkClient.NetworkManagementClient.NetworkWatchers.ListAvailableProviders(ResourceGroupName, NetworkWatcherName, vAvailableProvidersListParameters);
            var vNetworkWatcherModel = NetworkResourceManagerProfile.Mapper.Map<PSAvailableProvidersList>(vNetworkWatcherResult);
            WriteObject(vNetworkWatcherModel);
        }
    }
}
