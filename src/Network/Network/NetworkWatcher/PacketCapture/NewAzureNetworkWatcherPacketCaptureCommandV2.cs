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
             HelpMessage = "File path.")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

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
             HelpMessage = "This continuous capture is a nullable boolean, which can hold 'null', 'true' or 'false' value. If we do not pass this parameter, it would be consider as 'null', default value is 'null'.")]
        public bool? ContinuousCapture { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "This path is valid if 'ContinuousCapture' is provided and required if no storage ID is provided, otherwise optional. Must include the name of the capture file (*.cap).")]
        [ValidateNotNullOrEmpty]
        public string LocalPath { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Filters for packet capture session.")]
        [ValidateNotNull]
        public PSPacketCaptureSettings CaptureSettings { get; set; }

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

            #region Capture Settings Validations
            if (this.ContinuousCapture == null)
            {
                if (string.IsNullOrEmpty(this.FilePath) && string.IsNullOrEmpty(this.StorageAccountId))
                {
                    throw new ArgumentException("PacketCaptureIsMissingStorageIdAndFilePath: StorageLocation must have either storage id or file path specified.");
                }
            }
            else
            {
                if (this.TotalBytesPerSession != null)
                {
                    throw new ArgumentException("InvalidRequestPropertiesInPacketCaptureRequest: TotalBytesPerSession is not supported in packet capture request.");
                }

                if (this.TimeLimitInSecond != null)
                {
                    throw new ArgumentException("InvalidRequestPropertiesInPacketCaptureRequest: TimeLimitInSecond is not supported in packet capture request.");
                }

                if (this.FilePath != null)
                {
                    throw new ArgumentException("PacketCaptureIsMissingStorageIdAndLocalPath: StorageLocation must have either storage id or local path specified.");
                }

                if (string.IsNullOrEmpty(this.LocalPath) && string.IsNullOrEmpty(this.StorageAccountId))
                {
                    throw new ArgumentException("PacketCaptureIsMissingStorageIdAndLocalFilePath: StorageLocation must have either storage id or local file path specified.");
                }

                if (this.CaptureSettings == null)
                {
                    this.CaptureSettings = new PSPacketCaptureSettings
                    {
                        FileCount = 10,
                        FileSizeInBytes = 104857600,
                        SessionTimeLimitInSeconds = 86400
                    };
                }
                else
                {
                    this.CaptureSettings.FileCount = this.CaptureSettings.FileCount ?? 10;
                    this.CaptureSettings.FileSizeInBytes = this.CaptureSettings.FileSizeInBytes ?? 104857600;
                    this.CaptureSettings.SessionTimeLimitInSeconds = this.CaptureSettings.SessionTimeLimitInSeconds ?? 86400;

                    if (this.CaptureSettings.FileCount < 1 || this.CaptureSettings.FileCount > 10000)
                    {
                        throw new ArgumentException("FileCount must be between 1 and 10,000. Default is 10.");
                    }
                    if (this.CaptureSettings.FileSizeInBytes < 102400 || this.CaptureSettings.FileSizeInBytes > 4294967295)
                    {
                        throw new ArgumentException("FileSizeInBytes must be between 102400 byte and 4,294,967,295 bytes (4 GB). Default is 104,857,600 bytes (100 MB).");
                    }
                    if (this.CaptureSettings.SessionTimeLimitInSeconds < 1 || this.CaptureSettings.SessionTimeLimitInSeconds > 604800)
                    {
                        throw new ArgumentException("SessionTimeLimitInSeconds must be between 1 second and 604,800 seconds (7 days). Default is 86,400 seconds.");
                    }
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
            packetCaptureProperties.ContinuousCapture = this.ContinuousCapture;

            if (this.ContinuousCapture != null)
            {
                packetCaptureProperties.StorageLocation.LocalPath = this.LocalPath;
                packetCaptureProperties.CaptureSettings = new MNM.PacketCaptureSettings()
                {
                    FileCount = this.CaptureSettings.FileCount,
                    FileSizeInBytes = this.CaptureSettings.FileSizeInBytes,
                    SessionTimeLimitInSeconds = this.CaptureSettings.SessionTimeLimitInSeconds
                };
            }
            else
            {
                packetCaptureProperties.StorageLocation.FilePath = this.FilePath;
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
