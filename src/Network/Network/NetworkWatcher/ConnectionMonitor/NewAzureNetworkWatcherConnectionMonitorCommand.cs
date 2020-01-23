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
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSConnectionMonitorResultV1), typeof(PSConnectionMonitorResultV2))]
    public class NewAzureNetworkWatcherConnectionMonitorCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
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
        [LocationCompleter("Microsoft.Network/networkWatchers/connectionMonitors")]
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
              Mandatory = false,
              HelpMessage = "The ID of the connection monitor source.",
              ParameterSetName = "SetByResource")]
        [Parameter(
              Mandatory = false,
              HelpMessage = "The ID of the connection monitor source.",
              ParameterSetName = "SetByName")]
        [Parameter(
              Mandatory = false,
              HelpMessage = "The ID of the connection monitor source.",
              ParameterSetName = "SetByLocation")]
        [Parameter(
              Mandatory = false,
              HelpMessage = "The ID of the connection monitor source.",
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
            HelpMessage = "Source port.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int SourcePort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "The ID of the connection monitor destination.",
             ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNullOrEmpty]
        public string DestinationResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination port.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination port.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination port.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination port.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address of the connection monitor destination.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address of the connection monitor destination.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address of the connection monitor destination.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The Ip address of the connection monitor destination.",
            ParameterSetName = "SetByConnectionMonitorV1")]
        [ValidateNotNullOrEmpty]
        public string DestinationAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of test group.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of test group.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of test group.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of test group.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection monitor output.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection monitor output.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection monitor output.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection monitor output.",
            ParameterSetName = "SetByConnectionMonitorV2")]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Notes associated with connection monitor.",
            ParameterSetName = "SetByLocation")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        public override void Execute()
        {
            base.Execute();

            Validate();

            string resourceGroupName = this.ResourceGroupName;
            string networkWatcherName = this.NetworkWatcherName;
            bool connectionMonitorV2 = false;

            if (ParameterSetName.Contains("SetByResource"))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                networkWatcherName = this.NetworkWatcher.Name;
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

            if (TestGroup != null && TestGroup.Any())
            {
                connectionMonitorV2 = true;
            }

            var present = this.IsConnectionMonitorPresent(resourceGroupName, networkWatcherName, this.Name, connectionMonitorV2);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    var connectionMonitor = CreateConnectionMonitor(resourceGroupName, networkWatcherName, connectionMonitorV2);
                    WriteObject(connectionMonitor);
                },
                () => present);
        }

        private PSConnectionMonitorResult CreateConnectionMonitor(string resourceGroupName, string networkWatcherName, bool connectionMonitorV2 = false)
        {
            MNM.ConnectionMonitor parameters = new MNM.ConnectionMonitor
            {
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            if (!string.IsNullOrEmpty(this.Note))
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

           if (connectionMonitorV2)
            {
               // This is only used for testing. Do not remove
               //  string str = JsonConvert.SerializeObject(parameters, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
               //  WriteObject(str);
                this.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, this.Name, parameters);
                getConnectionMonitor = this.GetConnectionMonitor(resourceGroupName, networkWatcherName, this.Name, connectionMonitorV2);
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
                    Port = this.DestinationPort
                };

                ConnectionMonitorResult connectionMonitorResult = this.ConnectionMonitors.CreateOrUpdateV1(resourceGroupName, networkWatcherName, this.Name, parameters).Result;
                getConnectionMonitor = MapConnectionMonitorResultToPSConnectionMonitorResultV1(connectionMonitorResult);
            }

            return (getConnectionMonitor);
        }

        public bool Validate()
        {
            return ValidateConnectionMonitorV1V2Parameters(this.SourceResourceId, this.DestinationResourceId, 
                null, this.DestinationAddress, 
                this.MonitoringIntervalInSeconds, this.TestGroup, this.Output);
        }
    }
}