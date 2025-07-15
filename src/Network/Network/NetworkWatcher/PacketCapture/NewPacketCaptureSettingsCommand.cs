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
             HelpMessage = "Number of file count. Default value is 1.")]
        [ValidateRange(1, 10000)]
        public int? FileCount { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of bytes captured per packet. Default value is 1073741824.")]
        [ValidateRange(102400, uint.MaxValue)]
        public long? FileSizeInBytes { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Capture session in seconds. Default value is 18000.")]
        [ValidateRange(1, 604800)]
        public int? SessionTimeLimitInSeconds { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Set default values if null
            if (this.FileCount == null)
                this.FileCount = 1;

            if (this.FileSizeInBytes == null)
                this.FileSizeInBytes = 1073741824;

            if (this.SessionTimeLimitInSeconds == null)
                this.SessionTimeLimitInSeconds = 18000;

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
