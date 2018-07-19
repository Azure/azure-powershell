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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmNetworkWatcherPacketCapture", SupportsShouldProcess = true, DefaultParameterSetName = "SetByResource")]
    public class RemoveAzureNetworkWatcherPacketCaptureCommand : PacketCaptureBaseCmdlet
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
            ValueFromPipeline = true,
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
            HelpMessage = "The packet capture name.")]
        [ValidateNotNullOrEmpty]
        public string PacketCaptureName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            ConfirmAction(
                Properties.Resources.RemoveResourceMessage,
                this.PacketCaptureName,
                () =>
                {
                    if (string.Equals(this.ParameterSetName, "SetByLocation", StringComparison.OrdinalIgnoreCase))
                    {
                        var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                        if (networkWatcher == null)
                        {
                            throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                        }

                        this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                        this.NetworkWatcherName = networkWatcher.Name;
                        this.PacketCaptures.Delete(this.ResourceGroupName, this.NetworkWatcherName, this.PacketCaptureName);
                    }
                    else if (string.Equals(this.ParameterSetName, "SetByResource", StringComparison.OrdinalIgnoreCase))
                    {
                        this.PacketCaptures.Delete(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, this.PacketCaptureName);
                    }
                    else
                    {
                        this.PacketCaptures.Delete(this.ResourceGroupName, this.NetworkWatcherName, this.PacketCaptureName);
                    }
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
