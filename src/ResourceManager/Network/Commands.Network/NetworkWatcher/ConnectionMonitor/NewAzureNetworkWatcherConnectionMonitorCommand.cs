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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByResource"),
        OutputType(typeof(PSConnectionMonitorResult))]
    public class NewAzureNetworkWatcherConnectionMonitorCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocation")]
        [LocationCompleterAttribute]
        [ValidateNotNull]
        public string Location { get; set; }

        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection monitor name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the connection monitor source.")]
        [ValidateNotNullOrEmpty]
        public string SourceResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Monitoring interval in seconds.")]
        [ValidateNotNullOrEmpty]
        public int? MonitoringIntervalInSeconds { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int SourcePort { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The ID of the connection monitor destination.")]
        [ValidateNotNullOrEmpty]
        public string DestinationResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Ip address of the connection monitor destination.")]
        [ValidateNotNullOrEmpty]
        public string DestinationAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination port.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Auto start.")]
        [ValidateNotNullOrEmpty]
        public bool? AutoStart { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public string resourceGroupName = string.Empty;
        public string networkWatcherName = string.Empty;

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Contains("SetByResource"))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                networkWatcherName = this.NetworkWatcher.Name;
            }
            else if (ParameterSetName.Contains("SetByName"))
            {
                resourceGroupName = this.ResourceGroupName;
                networkWatcherName = this.NetworkWatcherName;
            }
            else
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in the specified location");
                }

                resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                networkWatcherName = networkWatcher.Name;
            }

            var present = this.IsConnectionMonitorPresent(resourceGroupName, networkWatcherName, this.Name);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    var connectionMonitor = CreateConnectionMonitor();
                    WriteObject(connectionMonitor);
                },
                () => present);
        }

        private PSConnectionMonitorResult CreateConnectionMonitor()
        {
            MNM.ConnectionMonitor parameters = new MNM.ConnectionMonitor
            {
                Source = new MNM.ConnectionMonitorSource
                {
                    ResourceId = this.SourceResourceId,
                    Port = this.SourcePort
                },
                Destination = new MNM.ConnectionMonitorDestination
                {
                    ResourceId = this.DestinationResourceId,
                    Address = this.DestinationAddress,
                    Port = this.DestinationPort
                },
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            if (this.AutoStart != null)
            {
                parameters.AutoStart = this.AutoStart;
            }

            if (this.MonitoringIntervalInSeconds != null)
            {
                parameters.MonitoringIntervalInSeconds = this.MonitoringIntervalInSeconds;
            }

            PSConnectionMonitorResult getConnectionMonitor = new PSConnectionMonitorResult();

            // Execute the CreateOrUpdate Connection monitor call
            if (ParameterSetName.Contains("SetByResource"))
            {
                parameters.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByName"))
            {
                NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
                parameters.Location = networkWatcher.Location;
            }
            else
            {
                parameters.Location = this.Location;
            }

            this.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, this.Name, parameters);
            getConnectionMonitor = this.GetConnectionMonitor(resourceGroupName, networkWatcherName, this.Name);

            return getConnectionMonitor;
        }
    }
}
