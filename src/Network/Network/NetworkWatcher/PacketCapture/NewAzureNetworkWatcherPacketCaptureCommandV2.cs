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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherPacketCaptureV2", SupportsShouldProcess = true, DefaultParameterSetName = "SetByResource"),OutputType(typeof(PSPacketCaptureResult))]
    public class NewAzureNetworkWatcherPacketCaptureCommandV2 : PacketCaptureBaseCmdlet
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
        [LocationCompleter("Microsoft.Network/networkWatchers")]
        [ValidateNotNull]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The packet capture name.")]
        [ValidateNotNullOrEmpty]
        public string PacketCaptureName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target virtual machine ID or virtual machine scale set ID")]
        [ValidateNotNullOrEmpty]
        public string TargetId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage account Id.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage path.")]
        [ValidateNotNullOrEmpty]
        public string StoragePath { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Local file path.")]
        [ValidateNotNullOrEmpty]
        public string LocalFilePath { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bytes to capture per packet.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? BytesToCapturePerPacket { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Total bytes per session.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? TotalBytesPerSession { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time limit in seconds.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? TimeLimitInSeconds { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Scope of VMSS Instances to be Included or Excluded.")]
        [ValidateNotNull]
        public PSPacketCaptureMachineScope Scope { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Target Type of the Resource.")]
        [ValidateNotNullOrEmpty]
        public string TargetType { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Filters for packet capture session.")]
        [ValidateNotNull]
        public PSPacketCaptureFilter[] Filter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            string resourceGroupName;
            string name;

            if (string.Equals(this.ParameterSetName, "SetByLocation", StringComparison.OrdinalIgnoreCase))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                name = networkWatcher.Name;
            }
            else if (string.Equals(this.ParameterSetName, "SetByResource", StringComparison.OrdinalIgnoreCase))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                name = this.NetworkWatcher.Name;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                name = this.NetworkWatcherName;
            }

            var present = this.IsPacketCapturePresent(resourceGroupName, name, this.PacketCaptureName);

            if (!present)
            {
                ConfirmAction(
                    Properties.Resources.CreatingResourceMessage,
                    this.PacketCaptureName,
                    () =>
                    {
                        var packetCapture = CreatePacketCapture(resourceGroupName, name);
                        WriteObject(packetCapture);
                    });
            }
        }

        private PSPacketCaptureResult CreatePacketCapture(string resourceGroupName, string networkWatcherName)
        {
            MNM.PacketCapture packetCaptureProperties = new MNM.PacketCapture();

            if(this.BytesToCapturePerPacket != null)
            {
                packetCaptureProperties.BytesToCapturePerPacket = this.BytesToCapturePerPacket;
            }

            if (this.TotalBytesPerSession != null)
            {
                packetCaptureProperties.TotalBytesPerSession = this.TotalBytesPerSession;
            }

            if (this.TimeLimitInSeconds != null)
            {
                packetCaptureProperties.TimeLimitInSeconds = this.TimeLimitInSeconds;
            }

            packetCaptureProperties.Target = this.TargetId;

            packetCaptureProperties.StorageLocation = new MNM.PacketCaptureStorageLocation();
            packetCaptureProperties.StorageLocation.FilePath = this.LocalFilePath;
            packetCaptureProperties.StorageLocation.StorageId = this.StorageAccountId;
            packetCaptureProperties.StorageLocation.StoragePath = this.StoragePath;

            packetCaptureProperties.TargetType = MNM.PacketCaptureTargetType.AzureVM;

            if (!string.IsNullOrEmpty(this.TargetType))
            {
                if (this.TargetType.ToLower() == "vmss" || this.TargetType.ToLower() == "azurevmss")
                {
                    packetCaptureProperties.TargetType = MNM.PacketCaptureTargetType.AzureVMSS;
                }
            }

            if (this.Filter != null)
            {
                packetCaptureProperties.Filters = new List<MNM.PacketCaptureFilter>();
                foreach (PSPacketCaptureFilter filter in this.Filter)
                {
                    MNM.PacketCaptureFilter filterMNM = NetworkResourceManagerProfile.Mapper.Map<MNM.PacketCaptureFilter>(filter);
                    packetCaptureProperties.Filters.Add(filterMNM);
                }
            }

            if (this.Scope != null)
            {
                packetCaptureProperties.Scope = new MNM.PacketCaptureMachineScope();
                packetCaptureProperties.Scope.Include = this.Scope.Include;
                packetCaptureProperties.Scope.Exclude = this.Scope.Exclude;
            }

            PSPacketCaptureResult getPacketCapture = new PSPacketCaptureResult();

            // Execute the Create NetworkWatcher call
            this.PacketCaptures.Create(resourceGroupName, networkWatcherName, this.PacketCaptureName, packetCaptureProperties);
            getPacketCapture = this.GetPacketCapture(resourceGroupName, networkWatcherName, this.PacketCaptureName);

            return getPacketCapture;
        }
    }
}
