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
             HelpMessage = "Number of file count, Default value of count is 10 and maximum number is 10000.")]
        [ValidateNotNullOrEmpty]
        public int? FileCount { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of bytes captured per packet, Default value in bytes 104857600 (100MB) and maximum in bytes 4294967295 (4GB).")]
        [ValidateNotNullOrEmpty]
        public long? FileSizeInBytes { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maximum duration of the capture session in seconds is 604800s (7 days) for a file. Default value in second 86400s (1 day).")]
        [ValidateNotNullOrEmpty]
        public int? SessionTimeLimitInSeconds { get; set; }

        public override void Execute()
        {
            base.Execute();

            if ((this.FileCount == null || this.FileCount == 0) && (this.FileSizeInBytes == null || this.FileSizeInBytes == 0)
                && (this.SessionTimeLimitInSeconds == null || this.SessionTimeLimitInSeconds == 0))
            {
                throw new ArgumentException("Parameters cannot be all empty or zero to create new packet capture settings.");
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
