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
<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
=======
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
<<<<<<< HEAD
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"),OutputType(typeof(PSConnectionMonitorResult))]
    public class SetAzureNetworkWatcherConnectionMonitorCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
=======
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"),OutputType(typeof(PSConnectionMonitorResultV1),typeof(PSConnectionMonitorResultV2))]

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

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
            HelpMessage = "Resource ID.",
            ParameterSetName = "SetByResourceId")]
=======
            HelpMessage = "ConnectionMonitor resource ID.",
            ParameterSetName = "SetByResourceId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ConnectionMonitor resource ID.",
            ParameterSetName = "SetByResourceIdV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNull]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Connection monitor object.",
            ParameterSetName = "SetByInputObject")]
        [ValidateNotNull]
        public PSConnectionMonitorResult InputObject { get; set; }

        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
<<<<<<< HEAD
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByResource")]
=======
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByName")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.",
            ParameterSetName = "SetByLocation")]
<<<<<<< HEAD
        [ResourceNameCompleter("Microsoft.Network/networkWatchers/connectionMonitors", "ResourceGroupName", "NetworkWatcherName")]
=======
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
        [Parameter(
            Mandatory = true,
            HelpMessage = "The ID of the resource used as the source by connection monitor.",
            ParameterSetName = "SetByResourceId")]
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
        [Parameter(
            Mandatory = false,
            HelpMessage = "Monitoring interval in seconds. Default value is 60 seconds.",
            ParameterSetName = "SetByResourceId")]
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
        [Parameter(
            Mandatory = false,
            HelpMessage = "The source port used by connection monitor.",
            ParameterSetName = "SetByResourceId")]
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
            HelpMessage = "SThe ID of the resource used as the destination by connection monitor.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The ID of the resource used as the destination by connection monitor.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The ID of the resource used as the destination by connection monitor.",
            ParameterSetName = "SetByResourceId")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string DestinationResourceId { get; set; }

        [Parameter(
<<<<<<< HEAD
            Mandatory = false,
            HelpMessage = "The Ip address of the connection monitor destination.")]
=======
            Mandatory = true,
            HelpMessage = "The destination port used by connection monitor.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination port used by connection monitor.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination port used by connection monitor.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination port used by connection monitor.",
            ParameterSetName = "SetByResourceId")]
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
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ConnectionMonitor resource ID.",
            ParameterSetName = "SetByResourceId")]
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
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of test groups.",
            ParameterSetName = "SetByResourceIdV2")]
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
        [Parameter(
            Mandatory = false,
            HelpMessage = "Describes a connection monitor output destinations.",
            ParameterSetName = "SetByResourceIdV2")]
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
        [Parameter(
            Mandatory = false,
            HelpMessage = "ConnectionMonitor resource ID.",
            ParameterSetName = "SetByResourceIdV2")]
        public string Note { get; set; }

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
        [Parameter(
            Mandatory = false,
            HelpMessage = "ConnectionMonitor resource ID.",
            ParameterSetName = "SetByResourceId")]
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
        [Parameter(
            Mandatory = false,
            HelpMessage = "ConnectionMonitor resource ID.",
            ParameterSetName = "SetByResourceId")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "ConnectionMonitor resource ID.",
            ParameterSetName = "SetByResourceIdV2")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

<<<<<<< HEAD
        public string connectionMonitorName;

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public override void Execute()
        {
            base.Execute();

<<<<<<< HEAD
            connectionMonitorName = this.Name;
            string resourceGroupName = this.ResourceGroupName;
            string networkWatcherName = this.NetworkWatcherName;

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            if (ParameterSetName.Contains("SetByResourceId"))
            {
                ConnectionMonitorDetails connectionMonitorDetails = new ConnectionMonitorDetails();
                connectionMonitorDetails = this.GetConnectionMonitorDetails(this.ResourceId);

<<<<<<< HEAD
                connectionMonitorName = connectionMonitorDetails.ConnectionMonitorName;
                resourceGroupName = connectionMonitorDetails.ResourceGroupName;
                networkWatcherName = connectionMonitorDetails.NetworkWatcherName;
            }
            else if (ParameterSetName.Contains("SetByResource"))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                networkWatcherName = this.NetworkWatcher.Name;
=======
                this.Name = connectionMonitorDetails.ConnectionMonitorName;
                this.ResourceGroupName = connectionMonitorDetails.ResourceGroupName;
                this.NetworkWatcherName = connectionMonitorDetails.NetworkWatcherName;
            }
            else if (ParameterSetName.Contains("SetByResource"))
            {
                this.ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                this.NetworkWatcherName = this.NetworkWatcher.Name;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
            else if (ParameterSetName.Contains("SetByInputObject"))
            {
                ConnectionMonitorDetails connectionMonitorDetails = new ConnectionMonitorDetails();
                connectionMonitorDetails = this.GetConnectionMonitorDetails(this.InputObject.Id);

<<<<<<< HEAD
                connectionMonitorName = connectionMonitorDetails.ConnectionMonitorName;
                resourceGroupName = connectionMonitorDetails.ResourceGroupName;
                networkWatcherName = connectionMonitorDetails.NetworkWatcherName;
=======
                this.Name = connectionMonitorDetails.ConnectionMonitorName;
                this.ResourceGroupName = connectionMonitorDetails.ResourceGroupName;
                this.NetworkWatcherName = connectionMonitorDetails.NetworkWatcherName;
                this.Location = this.InputObject.Location;

                if (this.InputObject is PSConnectionMonitorResultV1 connectionMonitorV1)
                {
                    this.SourceResourceId = connectionMonitorV1.Source.ResourceId;
                    this.SourcePort = connectionMonitorV1.Source.Port ?? 0;
                    this.DestinationResourceId = connectionMonitorV1.Destination.ResourceId;
                    this.DestinationAddress = connectionMonitorV1.Destination.Address;
                    this.DestinationPort = connectionMonitorV1.Destination.Port;
                    this.MonitoringIntervalInSeconds = connectionMonitorV1.MonitoringIntervalInSeconds;
                }
                else if (this.InputObject is PSConnectionMonitorResultV2 connectionMonitorV2)
                {
                    this.TestGroup = connectionMonitorV2.TestGroups?.ToArray();
                    this.Output = connectionMonitorV2.Outputs?.ToArray();
                    this.Note = connectionMonitorV2.Notes;
                }
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

            var present = this.IsConnectionMonitorPresent(resourceGroupName, networkWatcherName, connectionMonitorName);

            if (!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var connectionMonitor = UpdateConnectionMonitor(resourceGroupName, networkWatcherName);
            WriteObject(connectionMonitor);
        }

        private PSConnectionMonitorResult UpdateConnectionMonitor(string resourceGroupName, string networkWatcherName)
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

            this.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, parameters);
            getConnectionMonitor = this.GetConnectionMonitor(resourceGroupName, networkWatcherName, connectionMonitorName);

            return getConnectionMonitor;
        }
    }
}
=======
                    throw new PSArgumentException(Properties.Resources.NoNetworkWatcherFound);
                }

                this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                this.NetworkWatcherName = networkWatcher.Name;
            }

            bool isConnectionMonitorV2 = ParameterSetName.Contains("V2") || (this.InputObject != null && this.InputObject is PSConnectionMonitorResultV2);

            if (!this.IsConnectionMonitorPresent(this.ResourceGroupName, this.NetworkWatcherName, this.Name))
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorNotFound);
            }

            var connectionMonitor = UpdateConnectionMonitor(isConnectionMonitorV2);

            if (isConnectionMonitorV2)
            {
                WriteObject((PSConnectionMonitorResultV2)connectionMonitor);
            }
            else
            {
                WriteObject((PSConnectionMonitorResultV1)connectionMonitor);
            }
        }

        private PSConnectionMonitorResult UpdateConnectionMonitor(bool isConnectionMonitorV2)
        {
            MNM.ConnectionMonitor connectionMonitor;
            if (isConnectionMonitorV2)
            {
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
                    AutoStart = this.ConfigureOnly ? false : true,
                    MonitoringIntervalInSeconds = this.MonitoringIntervalInSeconds
                };
            }

            connectionMonitor.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            if (!string.IsNullOrEmpty(this.Location))
            {
                connectionMonitor.Location = this.Location;
            }
            else if (this.NetworkWatcher != null)
            {
                connectionMonitor.Location = this.NetworkWatcher.Location;
            }
            else
            {
                MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
                connectionMonitor.Location = networkWatcher.Location;
            }

            PSConnectionMonitorResult psConnectionMonitorResult;
            if (isConnectionMonitorV2)
            {
                this.ConnectionMonitors.CreateOrUpdate(this.ResourceGroupName, this.NetworkWatcherName, this.Name, connectionMonitor);
                psConnectionMonitorResult = this.GetConnectionMonitor(this.ResourceGroupName, this.NetworkWatcherName, this.Name, isConnectionMonitorV2);
            }
            else
            {
                ConnectionMonitorResult connectionMonitorResult = this.ConnectionMonitors.CreateOrUpdateV1(this.ResourceGroupName, this.NetworkWatcherName, this.Name, connectionMonitor).Result;
                psConnectionMonitorResult = MapConnectionMonitorResultToPSConnectionMonitorResultV1(connectionMonitorResult);
            }

            return (psConnectionMonitorResult);
        }
    }
}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
