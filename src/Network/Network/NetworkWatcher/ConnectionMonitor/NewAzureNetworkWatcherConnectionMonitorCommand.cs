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
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
<<<<<<< HEAD
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"),OutputType(typeof(PSConnectionMonitorResult))]
=======
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSConnectionMonitorResultV1), typeof(PSConnectionMonitorResultV2))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class NewAzureNetworkWatcherConnectionMonitorCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
<<<<<<< HEAD
=======
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResourceV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
<<<<<<< HEAD
=======
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByNameV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
<<<<<<< HEAD
=======
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByNameV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocation")]
<<<<<<< HEAD
=======
        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocationV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [LocationCompleter("Microsoft.Network/networkWatchers/connectionMonitors")]
        [ValidateNotNull]
        public string Location { get; set; }

        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
<<<<<<< HEAD
            HelpMessage = "The connection monitor name.")]
=======
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByResourceV2")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByNameV2")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByLocationV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
<<<<<<< HEAD
            Mandatory = true,
            HelpMessage = "The ID of the connection monitor source.")]
=======
              Mandatory = true,
              HelpMessage = "The ID of the resource used as the source by connection monitor.",
              ParameterSetName = "SetByResource")]
        [Parameter(
              Mandatory = true,
              HelpMessage = "The ID of the resource used as the source by connection monitor.",
              ParameterSetName = "SetByName")]
        [Parameter(
              Mandatory = true,
              HelpMessage = "The ID of the resource used as the source by connection monitor.",
              ParameterSetName = "SetByLocation")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string SourceResourceId { get; set; }

        [Parameter(
            Mandatory = false,
<<<<<<< HEAD
            HelpMessage = "Monitoring interval in seconds. Default value is 60 seconds.")]
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public int? MonitoringIntervalInSeconds { get; set; }

        [Parameter(
            Mandatory = false,
<<<<<<< HEAD
            HelpMessage = "Source port.")]
=======
            HelpMessage = "The source port used by connection monitor.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The source port used by connection monitor.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The source port used by connection monitor.",
            ParameterSetName = "SetByLocation")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int SourcePort { get; set; }

        [Parameter(
<<<<<<< HEAD
             Mandatory = false,
             HelpMessage = "The ID of the connection monitor destination.")]
=======
            Mandatory = false,
            HelpMessage = "The ID of the resource used as the destination by connection monitor.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The ID of the resource used as the destination by connection monitor.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The ID of the resource used as the destination by connection monitor.",
            ParameterSetName = "SetByLocation")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string DestinationResourceId { get; set; }

        [Parameter(
<<<<<<< HEAD
            Mandatory = false,
            HelpMessage = "The Ip address of the connection monitor destination.")]
=======
            Mandatory = true,
            HelpMessage = "The destination port used by connection monitor..",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination port used by connection monitor.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination port used by connection monitor.",
            ParameterSetName = "SetByLocation")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Address of the connection monitor destination (IP or domain name).",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Address of the connection monitor destination (IP or domain name).",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Address of the connection monitor destination (IP or domain name).",
            ParameterSetName = "SetByLocation")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string DestinationAddress { get; set; }

        [Parameter(
<<<<<<< HEAD
            Mandatory = false,
            HelpMessage = "Destination port.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Configure connection monitor, but do not start it")]
=======
            Mandatory = true,
            HelpMessage = "The list of test groups.",
            ParameterSetName = "SetByResourceV2")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of test groups.",
            ParameterSetName = "SetByNameV2")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of test groups.",
            ParameterSetName = "SetByLocationV2")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorTestGroupObject[] TestGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Describes a connection monitor output destinations.",
            ParameterSetName = "SetByResourceV2")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Describes a connection monitor output destinations.",
            ParameterSetName = "SetByNameV2")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Describes a connection monitor output destinations.",
            ParameterSetName = "SetByLocationV2")]
        public PSNetworkWatcherConnectionMonitorOutputObject[] Output { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByResourceV2")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByNameV2")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByLocationV2")]
        public string Note { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Connection monitor object.",
            ParameterSetName = "SetByConnectionMonitorV2Object")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorObject ConnectionMonitor { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Configure connection monitor, but do not start it.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Configure connection monitor, but do not start it.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Configure connection monitor, but do not start it.",
            ParameterSetName = "SetByLocation")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public SwitchParameter ConfigureOnly { get; set; }

        [Parameter(
            Mandatory = false,
<<<<<<< HEAD
            HelpMessage = "A hashtable which represents resource tags.")]
=======
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
            ParameterSetName = "SetByResourceV2")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = "SetByNameV2")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = "SetByLocationV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

<<<<<<< HEAD
            string resourceGroupName = this.ResourceGroupName;
            string networkWatcherName = this.NetworkWatcherName;

            if (ParameterSetName.Contains("SetByResource"))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                networkWatcherName = this.NetworkWatcher.Name;
=======
            if (ParameterSetName.Contains("SetByResource"))
            {
                this.ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                this.NetworkWatcherName = this.NetworkWatcher.Name;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
            else if (ParameterSetName.Contains("SetByLocation"))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
<<<<<<< HEAD
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                networkWatcherName = networkWatcher.Name;
            }

            var present = this.IsConnectionMonitorPresent(resourceGroupName, networkWatcherName, this.Name);

=======
                    throw new PSArgumentException(Properties.Resources.NoNetworkWatcherFound);
                }

                this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                this.NetworkWatcherName = networkWatcher.Name;
            }
            else if (ParameterSetName.Contains("SetByConnectionMonitorV2Object"))
            {
                if (string.IsNullOrEmpty(this.ConnectionMonitor.ResourceGroupName) || string.IsNullOrEmpty(this.ConnectionMonitor.NetworkWatcherName))
                {
                    throw new PSArgumentException(Properties.Resources.MissingBaseParametersInConnectionMonitor);
                }

                this.ResourceGroupName = this.ConnectionMonitor.ResourceGroupName;
                this.NetworkWatcherName = this.ConnectionMonitor.NetworkWatcherName;
                this.Name = this.ConnectionMonitor.Name;
            }

            var present = this.IsConnectionMonitorPresent(this.ResourceGroupName, this.NetworkWatcherName, this.Name);

            bool isConnectionMonitorV2 = ParameterSetName.Contains("V2") ? true : false;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
<<<<<<< HEAD
                    var connectionMonitor = CreateConnectionMonitor(resourceGroupName, networkWatcherName);
=======
                    var connectionMonitor = CreateConnectionMonitor(this.ResourceGroupName, this.NetworkWatcherName, isConnectionMonitorV2);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    WriteObject(connectionMonitor);
                },
                () => present);
        }

<<<<<<< HEAD
        private PSConnectionMonitorResult CreateConnectionMonitor(string resourceGroupName, string networkWatcherName)
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
            if (ParameterSetName.Contains("SetByResource"))
            {
                parameters.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByName"))
            {
                MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
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
=======
        private PSConnectionMonitorResult CreateConnectionMonitor(string resourceGroupName, string networkWatcherName, bool isConnectionMonitorV2)
        {
            MNM.ConnectionMonitor connectionMonitor;
            if (isConnectionMonitorV2)
            {
                if (ParameterSetName.Contains("SetByConnectionMonitorV2Object"))
                {
                    this.TestGroup = this.ConnectionMonitor.TestGroups?.ToArray();
                    this.Output = this.ConnectionMonitor.Outputs?.ToArray();
                    this.Note = this.ConnectionMonitor.Notes;
                }

                this.ValidateConnectionMonitorV2Request(this.TestGroup, this.Output);
                connectionMonitor = this.PopulateConnectionMonitorParametersFromV2Request(this.TestGroup, this.Output, this.Note);
            }
            else
            {
                connectionMonitor = new ConnectionMonitor()
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
                    AutoStart = this.ConfigureOnly.IsPresent,
                    MonitoringIntervalInSeconds = this.MonitoringIntervalInSeconds
                };
            }

            connectionMonitor.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            if (ParameterSetName.Contains("SetByResource"))
            {
                connectionMonitor.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByName") || ParameterSetName.Contains("SetByConnectionMonitorV2Object"))
            {
               MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
               connectionMonitor.Location = networkWatcher.Location;
            }
            else
            {
                connectionMonitor.Location = this.Location;
            }

            PSConnectionMonitorResult psConnectionMonitorResult;
            if (isConnectionMonitorV2)
            {
               // This is only used for testing. Do not remove
               // string str = JsonConvert.SerializeObject(parameters, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
               // WriteObject(str);
                this.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, this.Name, connectionMonitor);
                psConnectionMonitorResult = this.GetConnectionMonitor(resourceGroupName, networkWatcherName, this.Name, isConnectionMonitorV2);
            }
            else
            {
                ConnectionMonitorResult connectionMonitorResult = this.ConnectionMonitors.CreateOrUpdateV1(resourceGroupName, networkWatcherName, this.Name, connectionMonitor).Result;
                psConnectionMonitorResult = MapConnectionMonitorResultToPSConnectionMonitorResultV1(connectionMonitorResult);
            }

            return (psConnectionMonitorResult);
        }
    }
}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
