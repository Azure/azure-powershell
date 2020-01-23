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
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"),
                                                                       OutputType(typeof(PSConnectionMonitorResultV1)),
                                                                       OutputType(typeof(PSConnectionMonitorResultV2))]

    public class SetAzureNetworkWatcherConnectionMonitorCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByConnectionMonitorV1")]
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByConnectionMonitorV2")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        [LocationCompleter("Microsoft.Network/networkWatchers/connectionMonitors")]
        [ValidateNotNull]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource ID.",
            ParameterSetName = "SetByResourceId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource ID.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource ID.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource ID.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNull]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Connection monitor object.",
            ParameterSetName = "SetByInputObject")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Connection monitor object.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Connection monitor object.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        [ValidateNotNull]
        public PSConnectionMonitorResult InputObject { get; set; }

        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers/connectionMonitors", "ResourceGroupName", "NetworkWatcherName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource ID of the connection monitor source endpoint.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource ID of the connection monitor source endpoint.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource ID of the connection monitor source endpoint.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource ID of the connection monitor source endpoint.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNullOrEmpty]
        public string SourceResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Monitoring interval in seconds. Default value is 60 seconds.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Monitoring interval in seconds. Default value is 60 seconds.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Monitoring interval in seconds. Default value is 60 seconds.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Monitoring interval in seconds. Default value is 60 seconds.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNullOrEmpty]
        public int? MonitoringIntervalInSeconds { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The source port.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The source port.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The source port.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The source port.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int SourcePort { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The resource ID of the connection monitor destination endpoint.",
             ParameterSetName = "SetByResource")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "The resource ID of the connection monitor destination endpoint.",
             ParameterSetName = "SetByName")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "The resource ID of the connection monitor destination endpoint.",
             ParameterSetName = "SetByLocation")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "The resource ID of the connection monitor destination endpoint.",
             ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNullOrEmpty]
        public string DestinationResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address of the connection monitor destination endpoint.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address of the connection monitor destination endpoint.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address of the connection monitor destination endpoint.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address of the connection monitor destination endpoint.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNullOrEmpty]
        public string DestinationAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination port.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination port.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination port.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination port.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor test groups.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor test groups.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor test groups.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor test groups.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor outputs.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor outputs.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor outputs.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor outputs.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        public string Note { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Configure connection monitor, but do not start it")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ConfigureOnly { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public string connectionMonitorName;

        public override void Execute()
        {
            base.Execute();

            Validate();

            connectionMonitorName = this.Name;
            string resourceGroupName = this.ResourceGroupName;
            string networkWatcherName = this.NetworkWatcherName;
            bool connectionMonitorV2 = false;

            if (ParameterSetName.Contains("SetByResourceId"))
            {
                ConnectionMonitorDetails connectionMonitorDetails = new ConnectionMonitorDetails();
                connectionMonitorDetails = this.GetConnectionMonitorDetails(this.ResourceId);

                connectionMonitorName = connectionMonitorDetails.ConnectionMonitorName;
                resourceGroupName = connectionMonitorDetails.ResourceGroupName;
                networkWatcherName = connectionMonitorDetails.NetworkWatcherName;
            }
            else if (ParameterSetName.Contains("SetByResource"))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                networkWatcherName = this.NetworkWatcher.Name;
            }
            else if (ParameterSetName.Contains("SetByInputObject"))
            {
                ConnectionMonitorDetails connectionMonitorDetails = new ConnectionMonitorDetails();
                connectionMonitorDetails = this.GetConnectionMonitorDetails(this.InputObject.Id);

                connectionMonitorName = connectionMonitorDetails.ConnectionMonitorName;
                resourceGroupName = connectionMonitorDetails.ResourceGroupName;
                networkWatcherName = connectionMonitorDetails.NetworkWatcherName;

                if (this.InputObject.GetType() == typeof(PSConnectionMonitorResultV1))
                {
                    PSConnectionMonitorResultV1 InputObjectV1 = (PSConnectionMonitorResultV1)this.InputObject;

                    this.ResourceId = InputObjectV1.Source.ResourceId;
                    this.SourceResourceId = InputObjectV1.Source.ResourceId;

                    this.SourcePort = InputObjectV1.Source.Port ?? default(int);

                    this.DestinationResourceId = InputObjectV1.Destination.ResourceId;
                    this.DestinationAddress = InputObjectV1.Destination.Address;
                    this.DestinationPort = InputObjectV1.Destination.Port;
                    this.MonitoringIntervalInSeconds = InputObjectV1.MonitoringIntervalInSeconds;
                }
                else if (this.InputObject.GetType() == typeof(PSConnectionMonitorResultV2))
                {
                    PSConnectionMonitorResultV2 InputObjectV2 = (PSConnectionMonitorResultV2)this.InputObject;

                    this.TestGroup = InputObjectV2.TestGroups;
                    this.Output = InputObjectV2.Outputs;
                    this.Note = InputObjectV2.Note;
                }
            }
            else if (ParameterSetName.Contains("SetByLocation"))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                networkWatcherName = networkWatcher.Name;
            }

            if (TestGroup != null && TestGroup.Any() ||
                (InputObject != null && this.InputObject.GetType() == typeof(PSConnectionMonitorResultV2)))
            {
                connectionMonitorV2 = true;
            }

            var present = this.IsConnectionMonitorPresent(resourceGroupName, networkWatcherName, connectionMonitorName, connectionMonitorV2);

            if (!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var connectionMonitor = UpdateConnectionMonitor(resourceGroupName, networkWatcherName, connectionMonitorV2);

            if (connectionMonitorV2 == true)
            {
                WriteObject(((PSConnectionMonitorResultV2)connectionMonitor));
            }
            else
            {
                WriteObject(((PSConnectionMonitorResultV1)connectionMonitor));
            }
        }

        private PSConnectionMonitorResult UpdateConnectionMonitor(string resourceGroupName, string networkWatcherName, bool connectionMonitorV2 = false)
        {
            MNM.ConnectionMonitor parameters = new MNM.ConnectionMonitor
            {
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            if (!string.IsNullOrEmpty(Note))
            {
                parameters.Notes = this.Note;
            }

            if (connectionMonitorV2 == true)
            {
                UpdateConnectionMonitorV2Parameters(this.TestGroup, this.Output, parameters);
            }

            if (this.ConfigureOnly)
            {
                parameters.AutoStart = false;
            }

            if (this.MonitoringIntervalInSeconds != null)
            {
                parameters.MonitoringIntervalInSeconds = this.MonitoringIntervalInSeconds;
            }

            PSConnectionMonitorResult getConnectionMonitor = new PSConnectionMonitorResult();

            // Execute the CreateOrUpdate Connection monitor call
            if (ParameterSetName.Contains("SetByResource") && !ParameterSetName.Contains("SetByResourceId"))
            {
                parameters.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByLocation"))
            {
                parameters.Location = this.Location;
            }
            else
            {
                MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(resourceGroupName, networkWatcherName);
                parameters.Location = networkWatcher.Location;
            }

            if (connectionMonitorV2)
            {
                this.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, parameters);

                getConnectionMonitor = this.GetConnectionMonitor(resourceGroupName, networkWatcherName, connectionMonitorName, connectionMonitorV2);
            }
            else
            {
                parameters.Source = new MNM.ConnectionMonitorSource
                {
                    ResourceId = this.SourceResourceId,
                    Port = this.SourcePort
                };
                parameters.Destination = new MNM.ConnectionMonitorDestination
                {
                    ResourceId = this.DestinationResourceId,
                    Address = this.DestinationAddress,
                    Port = this.DestinationPort,
                };

                ConnectionMonitorResult connectionMonitorResult = this.ConnectionMonitors.CreateOrUpdateV1(resourceGroupName, networkWatcherName, connectionMonitorName, parameters).Result;

                getConnectionMonitor = MapConnectionMonitorResultToPSConnectionMonitorResultV1(connectionMonitorResult);
            }

            return getConnectionMonitor;
        }

        public bool Validate()
        {
            if (InputObject != null)
            {
                if (this.InputObject.GetType() == typeof(PSConnectionMonitorResultV1))
                {
                    PSConnectionMonitorResultV1 InputObjectV1 = (PSConnectionMonitorResultV1)this.InputObject;

                    return ValidateConnectionMonitorV1V2Parameters(InputObjectV1.Source.ResourceId, InputObjectV1.Destination.ResourceId,
                    null, InputObjectV1.Destination.Address,
                    InputObjectV1.MonitoringIntervalInSeconds, this.TestGroup, this.Output);
                }
                else if (this.InputObject.GetType() == typeof(PSConnectionMonitorResultV2))
                {
                    PSConnectionMonitorResultV2 InputObjectV2 = (PSConnectionMonitorResultV2)this.InputObject;

                    return ValidateConnectionMonitorV1V2Parameters(null, null,
                    null, null,
                    null, InputObjectV2.TestGroups, InputObjectV2.Outputs);
                }
                else
                {
                    throw new ArgumentException("Unrecognized InputObject type.");
                }
            }
            else
            {
                return ValidateConnectionMonitorV1V2Parameters(this.SourceResourceId, this.DestinationResourceId,
                this.InputObject, this.DestinationAddress,
                this.MonitoringIntervalInSeconds, this.TestGroup, this.Output);
            }
        }
    }
}
