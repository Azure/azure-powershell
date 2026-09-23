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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherPacketCaptureV2", SupportsShouldProcess = true, DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSPacketCaptureResult))]
    public class NewAzureNetworkWatcherPacketCaptureCommandV2 : PacketCaptureBaseCmdlet
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

        [Alias("PacketCaptureName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The packet capture name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

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
        [ValidateRange(1, uint.MaxValue)]
        public uint? TotalBytesPerSession { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time limit in seconds.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? TimeLimitInSecond { get; set; }

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

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "This continuous capture is a nullable boolean, which can hold 'null', 'true' or 'false' value. If we do not pass this parameter, it would be considered as 'null', default value is 'null'.")]
        public bool? ContinuousCapture { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "This path is valid if 'ContinuousCapture' is provided and required if no storage ID is provided, otherwise optional. Must include the name of the capture file (*.cap).")]
        [ValidateNotNullOrEmpty]
        public string LocalPath { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The capture setting holds the 'FileCount', 'FileSizeInBytes', 'SessionTimeLimitInSeconds' values. These settings are only applicable, if 'ContinuousCapture' is provided.")]
        [ValidateNotNull]
        public PSPacketCaptureSettings CaptureSetting { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        private readonly bool ForcePrompt = false;

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

            #region Capture Settings Validations
            if (this.ContinuousCapture == null)
            {
                if (string.IsNullOrEmpty(this.LocalFilePath) && string.IsNullOrEmpty(this.StorageAccountId))
                {
                    throw new ArgumentException("PacketCaptureIsMissingStorageIdAndLocalFilePath: Command must have either storage id or local file path specified.");
                }
            }
            else
            {
                if (this.ContinuousCapture == true && this.CaptureSetting != null &&
                    this.CaptureSetting.FileCount == 1 && this.CaptureSetting.FileSizeInBytes == 1073741824
                    && this.CaptureSetting.SessionTimeLimitInSeconds == 18000)
                {
                    ConfirmAction(ForcePrompt,
                   $"Do you want to change the capture settings? As you have opted 'ContinuousCapture' as 'True' and Capture settings are : {JsonConvert.SerializeObject(this.CaptureSetting, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore })} ", string.Empty,
                   this.Name,
                   () =>
                    {
                        throw new Exception("Please modified the CaptureSetting values by using 'New-AzPacketCaptureSettingsConfig' command with specific values.");
                    }
                   );
                }

                if (this.TotalBytesPerSession != null)
                {
                    throw new ArgumentException("InvalidRequestPropertiesInPacketCaptureRequest: TotalBytesPerSession is not supported in packet capture request.");
                }

                if (this.TimeLimitInSecond != null)
                {
                    throw new ArgumentException("InvalidRequestPropertiesInPacketCaptureRequest: TimeLimitInSecond is not supported in packet capture request.");
                }

                if (this.LocalFilePath != null)
                {
                    throw new ArgumentException("PacketCaptureIsMissingStorageIdAndLocalPath: Command must have either storage id or local path specified.");
                }

                if (string.IsNullOrEmpty(this.LocalPath) && string.IsNullOrEmpty(this.StorageAccountId))
                {
                    throw new ArgumentException("PacketCaptureIsMissingStorageIdAndLocalFilePath: Command must have either storage id or local file path specified.");
                }
            }

            #endregion

            var present = this.IsPacketCapturePresent(resourceGroupName, name, this.Name);

            if (!present)
            {
                ConfirmAction(
                    Properties.Resources.CreatingResourceMessage,
                    this.Name,
                    () =>
                    {
                        var packetCapture = CreatePacketCapture(resourceGroupName, name);
                        WriteObject(packetCapture);
                    });
            }
            else
            {
                throw new ArgumentException($"PacketCaptureExistingAlready: Existing Packet capture can not be updated.");
            }
        }

        private PSPacketCaptureResult CreatePacketCapture(string resourceGroupName, string networkWatcherName)
        {
            MNM.PacketCapture packetCaptureProperties = new MNM.PacketCapture();

            if (this.BytesToCapturePerPacket != null)
            {
                packetCaptureProperties.BytesToCapturePerPacket = this.BytesToCapturePerPacket;
            }

            if (this.TotalBytesPerSession != null)
            {
                packetCaptureProperties.TotalBytesPerSession = this.TotalBytesPerSession;
            }

            if (this.TimeLimitInSecond != null)
            {
                packetCaptureProperties.TimeLimitInSeconds = this.TimeLimitInSecond;
            }

            packetCaptureProperties.Target = this.TargetId;
            packetCaptureProperties.StorageLocation = new MNM.PacketCaptureStorageLocation();

            if (this.ContinuousCapture != null)
            {
                packetCaptureProperties.ContinuousCapture = this.ContinuousCapture;
                packetCaptureProperties.StorageLocation.LocalPath = this.LocalPath;
                if (this.CaptureSetting != null)
                {
                    packetCaptureProperties.CaptureSettings = new MNM.PacketCaptureSettings()
                    {
                        FileCount = this.CaptureSetting.FileCount,
                        FileSizeInBytes = this.CaptureSetting.FileSizeInBytes,
                        SessionTimeLimitInSeconds = this.CaptureSetting.SessionTimeLimitInSeconds
                    };
                }
            }
            else
            {
                packetCaptureProperties.StorageLocation.FilePath = this.LocalFilePath;
            }

            packetCaptureProperties.StorageLocation.StorageId = this.StorageAccountId;
            packetCaptureProperties.StorageLocation.StoragePath = this.StoragePath;
            packetCaptureProperties.TargetType = MNM.PacketCaptureTargetType.AzureVM;

            if (!string.IsNullOrEmpty(this.TargetType))
            {
                if (this.TargetType.ToLower() == "vmss" || this.TargetType.ToLower() == "azurevmss")
                {
                    packetCaptureProperties.TargetType = MNM.PacketCaptureTargetType.AzureVmss;
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
            this.PacketCaptures.Create(resourceGroupName, networkWatcherName, this.Name, packetCaptureProperties);
            getPacketCapture = this.GetPacketCapture(resourceGroupName, networkWatcherName, this.Name);

            return getPacketCapture;
        }
    }
}
