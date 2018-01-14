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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkWatcherPacketCapture", SupportsShouldProcess = true, DefaultParameterSetName = "SetByResource"),
        OutputType(typeof(PSPacketCapture))]
    public class NewAzureNetworkWatcherPacketCaptureCommand : PacketCaptureBaseCmdlet
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The packet capture name.")]
        [ValidateNotNullOrEmpty]
        public string PacketCaptureName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target virtual machine ID.")]
        [ValidateNotNullOrEmpty]
        public string TargetVirtualMachineId { get; set; }

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
             HelpMessage = "Filters for packet capture session.")]
        [ValidateNotNull]
        public List<PSPacketCaptureFilter> Filter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            string resourceGroupName;
            string name;

            if(ParameterSetName.Contains("SetByResource"))
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
                        var packetCapture = CreatePacketCapture();
                        WriteObject(packetCapture);
                    });
            }
        }

        private PSPacketCaptureResult CreatePacketCapture()
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

            packetCaptureProperties.Target = this.TargetVirtualMachineId;

            packetCaptureProperties.StorageLocation = new MNM.PacketCaptureStorageLocation();
            packetCaptureProperties.StorageLocation.FilePath = this.LocalFilePath;
            packetCaptureProperties.StorageLocation.StorageId = this.StorageAccountId;
            packetCaptureProperties.StorageLocation.StoragePath = this.StoragePath;

            if (this.Filter != null)
            {
                packetCaptureProperties.Filters = new List<MNM.PacketCaptureFilter>();
                foreach (PSPacketCaptureFilter filter in this.Filter)
                {
                    MNM.PacketCaptureFilter filterMNM = NetworkResourceManagerProfile.Mapper.Map<MNM.PacketCaptureFilter>(filter);
                    packetCaptureProperties.Filters.Add(filterMNM);
                }
            }

            PSPacketCaptureResult getPacketCapture = new PSPacketCaptureResult();

            // Execute the Create NetworkWatcher call
            if (ParameterSetName.Contains("SetByResource"))
            {
                this.PacketCaptures.Create(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, this.PacketCaptureName, packetCaptureProperties);
                getPacketCapture = this.GetPacketCapture(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, this.PacketCaptureName);
            }
            else
            {
                this.PacketCaptures.Create(this.ResourceGroupName, this.NetworkWatcherName, this.PacketCaptureName, packetCaptureProperties);
                getPacketCapture = this.GetPacketCapture(this.ResourceGroupName, this.NetworkWatcherName, this.PacketCaptureName);
            }

            return getPacketCapture;
        }
    }
}
