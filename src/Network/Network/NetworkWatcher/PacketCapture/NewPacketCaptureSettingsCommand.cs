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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network.NetworkWatcher.PacketCapture
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PacketCaptureSettingsConfig"), OutputType(typeof(PSPacketCaptureSettings))]
    public class NewPacketCaptureSettingsCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = false,
             ValueFromPipeline = true,
             HelpMessage = "Number of file count.")]
        [ValidateNotNullOrEmpty]
        public int? FileCount { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of bytes captured per packet.")]
        [ValidateNotNullOrEmpty]
        public long? FileSizeInBytes { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Capture session in seconds.")]
        [ValidateNotNullOrEmpty]
        public int? SessionTimeLimitInSeconds { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Set default values if null
            if (this.FileCount == null)
                this.FileCount = 10;

            if (this.FileSizeInBytes == null)
                this.FileSizeInBytes = 104857600;

            if (this.SessionTimeLimitInSeconds == null)
                this.SessionTimeLimitInSeconds = 86400;

            // Validate FileCount
            if (this.FileCount < 1 || this.FileCount > 10000)
            {
                throw new ArgumentException("FileCount must be between 1 and 10,000. Default is 10.");
            }

            // Validate FileSizeInBytes
            if (this.FileSizeInBytes < 102400 || this.FileSizeInBytes > 4294967295)
            {
                throw new ArgumentException("FileSizeInBytes must be between 102400 byte and 4,294,967,295 bytes (4 GB). Default is 104,857,600 bytes (100 MB).");
            }

            // Validate SessionTimeLimitInSeconds
            if (this.SessionTimeLimitInSeconds < 1 || this.SessionTimeLimitInSeconds > 604800)
            {
                throw new ArgumentException("SessionTimeLimitInSeconds must be between 1 second and 604,800 seconds (7 days). Default is 86,400 seconds.");
            }

            var packetCaptureSettings = new PSPacketCaptureSettings
            {
                FileCount = this.FileCount,
                FileSizeInBytes = this.FileSizeInBytes,
                SessionTimeLimitInSeconds = this.SessionTimeLimitInSeconds
            };

            WriteObject(packetCaptureSettings);
        }
    }
}
