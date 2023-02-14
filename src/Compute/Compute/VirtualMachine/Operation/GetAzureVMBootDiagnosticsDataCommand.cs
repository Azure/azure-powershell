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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Text;


namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMBootDiagnosticsData", DefaultParameterSetName = WindowsParamSet)]
    [OutputType(typeof(PSVirtualMachine), typeof(PSVirtualMachineInstanceView))]
    public class GetAzureVMBootDiagnosticsDataCommand : VirtualMachineBaseCmdlet
    {
        private const string WindowsParamSet = "WindowsParamSet";
        private const string LinuxParamSet = "LinuxParamSet";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VMName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ParameterSetName = WindowsParamSet)]
        public SwitchParameter Windows { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ParameterSetName = LinuxParamSet)]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ParameterSetName = WindowsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path and name of the output RDP file.")]
        [Parameter(
            Mandatory = false,
            Position = 3,
            ParameterSetName = LinuxParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path and name of the output RDP file.")]
        [ValidateNotNullOrEmpty]
        public string LocalPath { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                LocalPath = ResolveUserPath(LocalPath);
                if (!LocalPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    LocalPath = LocalPath + Path.DirectorySeparatorChar;
                }
                var result = this.VirtualMachineClient.GetWithInstanceView(this.ResourceGroupName, this.Name);
                if (result == null || result.Body == null)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "no virtual machine")),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
                }

                if (result.Body.DiagnosticsProfile == null
                    || result.Body.DiagnosticsProfile.BootDiagnostics == null
                    || result.Body.DiagnosticsProfile.BootDiagnostics.Enabled == null
                    || !result.Body.DiagnosticsProfile.BootDiagnostics.Enabled.Value
                    )
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "no diagnostic profile enabled")),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
                }

                if (result.Body.InstanceView == null
                    || result.Body.InstanceView.BootDiagnostics == null)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "no boot diagnostic")),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
                }

                //console log
                if (this.Windows.IsPresent
                    || (this.Linux.IsPresent && !string.IsNullOrEmpty(this.LocalPath)))
                {
                    var bootDiagnostics = this.VirtualMachineClient.RetrieveBootDiagnosticsData(this.ResourceGroupName, this.Name);
                    var localPathTest = this.LocalPath;
                    var localFile = this.LocalPath + new Uri(bootDiagnostics.ConsoleScreenshotBlobUri).Segments[2];

                    DownloadFromBlobUri(new Uri(bootDiagnostics.ConsoleScreenshotBlobUri), localFile);
                }

                //serial log
                var bootDiagnosticsSerial = this.VirtualMachineClient.RetrieveBootDiagnosticsData(this.ResourceGroupName, this.Name);
                var logUri = new Uri(bootDiagnosticsSerial.SerialConsoleLogBlobUri);
                var localFileSerial = (this.LocalPath ?? Path.GetTempPath()) + logUri.Segments[2];
                DownloadFromBlobUri(logUri, localFileSerial);
                if (this.Linux.IsPresent)
                {
                    var sb = new StringBuilder();
                    using (var reader = new StreamReader(localFileSerial))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            sb.AppendLine(line);
                        }
                    };

                    WriteObject(sb.ToString());
                }
            });
        }

        private void DownloadFromBlobUri(Uri sourceUri, string localFileInfo)
        {
            BlobUri blobUri;
            if (!BlobUri.TryParseUri(sourceUri, out blobUri))
            {
                throw new ArgumentOutOfRangeException("Source", sourceUri.ToString());
            }

            var blob = new CloudBlob(sourceUri);

            blob.DownloadToFileAsync(localFileInfo, FileMode.Create).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
