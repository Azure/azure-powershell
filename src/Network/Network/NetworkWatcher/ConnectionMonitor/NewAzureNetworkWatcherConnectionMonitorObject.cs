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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorObject))]
    public class AzureNetworkWatcherConnectionMonitorObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
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
        [LocationCompleter("Microsoft.Network/networkWatchers/connectionMonitors")]
        [ValidateNotNull]
        public string Location { get; set; }
  
        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor test groups.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor outputs.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.")]
        [ValidateNotNullOrEmpty]
        public string Note { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            PSNetworkWatcherConnectionMonitorObject CMObject = new PSNetworkWatcherConnectionMonitorObject()
            {
                NetworkWatcherName = this.NetworkWatcherName,
                ResourceGroupName = this.ResourceGroupName,
                Name = this.Name
            };

            if (ParameterSetName.Contains("SetByResource"))
            {
                CMObject.NetworkWatcherName = this.NetworkWatcher.Name;
                CMObject.ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                CMObject.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByName"))
            {
                MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
                CMObject.Location = networkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByLocation"))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                CMObject.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                CMObject.NetworkWatcherName = networkWatcher.Name;
                CMObject.Location = this.Location;
            }

            if (this.TestGroup != null)
            {
                CMObject.TestGroup = this.TestGroup;
            }

            if (this.Output != null)
            {
                CMObject.Output = this.Output;
            }

            if (this.Note != null)
            {
                CMObject.Notes = this.Note;
            }

            WriteObject(CMObject);
        }

        public bool Validate()
        {
            return ValidateConnectionMonitorV1V2Parameters(null, null, 
                null, null, null, this.TestGroup, this.Output);
        }
    }
}