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
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineScaleSetDiagnosticsExtension,
        SupportsShouldProcess = true
        )]
    [OutputType(typeof(VirtualMachineScaleSet))]
    public class RemoveAzureRmVmssDiagnosticsExtension : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(this.VirtualMachineScaleSet.Name, Properties.Resources.RemoveVmssDiagnosticsExtensionAction))
            {
                // VirtualMachineProfile
                if (this.VirtualMachineScaleSet.VirtualMachineProfile != null &&
                    this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile != null &&
                    this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions != null)
                {
                    var extensions = this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions;

                    // Filter by publisher and type
                    // If extension name is provided, should match the name as well
                    var diagnosticsExtensions = extensions
                        .Where(extension =>
                            DiagnosticsHelper.IsDiagnosticsExtension(extension) &&
                            (string.IsNullOrEmpty(this.Name) || extension.Name.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase)))
                        .ToList();

                    if (diagnosticsExtensions.Any())
                    {
                        this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = extensions.Except(diagnosticsExtensions).ToList();

                        if (this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions.Count == 0)
                        {
                            this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = null;
                        }

                        WriteObject(this.VirtualMachineScaleSet);
                        return;
                    }
                }

                WriteWarning(Properties.Resources.DiagnosticsExtensionNotFoundForVMSS);
            }

            WriteObject(this.VirtualMachineScaleSet);
        }
    }
}
