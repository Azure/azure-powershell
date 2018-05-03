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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmNetworkWatcherConnectivity", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSConnectivityInformation))]

    public class TestAzureNetworkWatcherConnectivity : NetworkWatcherBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
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
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the resource from which a connectivity check will be initiated.")]
        [ValidateNotNullOrEmpty]
        public string SourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The source port from which a connectivity check will be performed.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int SourcePort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ID of the resource to which a connection attempt will be made.")]
        [ValidateNotNullOrEmpty]
        public string DestinationId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address or URI the resource to which a connection attempt will be made.")]
        [ValidateNotNullOrEmpty]
        public string DestinationAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Port on which check connectivity will be performed.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Protocal configuration on which check connectivity will be performed.")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherProtocolConfiguration ProtocolConfiguration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            MNM.ConnectivityParameters parameters = new MNM.ConnectivityParameters();

            parameters.Source = new MNM.ConnectivitySource();
            parameters.Source.ResourceId = this.SourceId;
            parameters.Source.Port = this.SourcePort;

            parameters.Destination = new MNM.ConnectivityDestination();
            parameters.Destination.ResourceId = this.DestinationId;
            parameters.Destination.Address = this.DestinationAddress;
            parameters.Destination.Port = this.DestinationPort;

            if (this.ProtocolConfiguration !=null && string.Equals(this.ProtocolConfiguration.Protocol, "Http", StringComparison.OrdinalIgnoreCase))
            {
                IList<MNM.HTTPHeader> headers = new List<MNM.HTTPHeader>();
                if (this.ProtocolConfiguration.Header != null)
                {
                    foreach (DictionaryEntry entry in this.ProtocolConfiguration.Header)
                    {
                        headers.Add(new MNM.HTTPHeader((string)entry.Key, (string)entry.Value));
                    }
                }

                MNM.HTTPConfiguration httpConfiguration = new MNM.HTTPConfiguration(this.ProtocolConfiguration.Method, headers, this.ProtocolConfiguration.ValidStatusCode.OfType<int?>().ToList());
                parameters.ProtocolConfiguration = new MNM.ProtocolConfiguration(httpConfiguration);
            }

            MNM.ConnectivityInformation result = new MNM.ConnectivityInformation();
            if (string.Equals(this.ParameterSetName, "SetByLocation", StringComparison.OrdinalIgnoreCase))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                this.NetworkWatcherName = networkWatcher.Name;
                result = this.NetworkWatcherClient.CheckConnectivity(this.ResourceGroupName, this.NetworkWatcherName, parameters);
            }
            else if (string.Equals(this.ParameterSetName, "SetByResource", StringComparison.OrdinalIgnoreCase))
            {
                result = this.NetworkWatcherClient.CheckConnectivity(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, parameters);
            }
            else
            {
                result = this.NetworkWatcherClient.CheckConnectivity(this.ResourceGroupName, this.NetworkWatcherName, parameters);
            }

            PSConnectivityInformation psResult = NetworkResourceManagerProfile.Mapper.Map<PSConnectivityInformation>(result);

            WriteObject(psResult);
        }
    }
}
