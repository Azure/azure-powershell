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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    [Cmdlet(
        VerbsCommon.Add,
        ProfileNouns.VirtualMachineScaleSetDiagnosticsExtension,
        SupportsShouldProcess = true)]
    [OutputType(typeof(VirtualMachineScaleSet))]
    public class AddAzureRmVmssDiagnosticsExtension : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        private string extensionName = DiagnosticsExtensionConstants.ExtensionDefaultName;
        private string version = "1.7";
        private bool autoUpgradeMinorVersion = true;

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Public diagnostics configuration in JSON.")]
        [ValidateNotNullOrEmpty]
        public string SettingFilePath { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Private diagnostics configuration in JSON.")]
        public string ProtectedSettingFilePath { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        public string Name
        {
            get
            {
                return this.extensionName;
            }
            set
            {
                this.extensionName = value;
            }
        }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension version.")]
        public string TypeHandlerVersion
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Pass a boolean value indicating whether auto upgrade diagnostics extension minor version.")]
        public bool AutoUpgradeMinorVersion
        {
            get
            {
                return this.autoUpgradeMinorVersion;
            }
            set
            {
                this.autoUpgradeMinorVersion = value;
            }
        }

        [Parameter(Mandatory = false,
            HelpMessage = "To force the overwritting of the diagnostics extension to the VM scale set.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(this.VirtualMachineScaleSet.Name, Properties.Resources.AddVmssDiagnosticsExtensionAction))
            {
                // VirtualMachineProfile
                if (this.VirtualMachineScaleSet.VirtualMachineProfile == null)
                {
                    this.VirtualMachineScaleSet.VirtualMachineProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetVMProfile();
                }

                // ExtensionProfile
                if (this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile == null)
                {
                    this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetExtensionProfile();
                }

                // Extensions
                if (this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions == null)
                {
                    this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = new List<Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetExtension>();
                }

                bool shouldContinue = true;

                // Warning if there's already a diagnostics extension.
                var extensions = this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions;
                if (extensions.Any(DiagnosticsHelper.IsDiagnosticsExtension))
                {
                    if (Force.IsPresent
                        || ShouldContinue(Properties.Resources.DiagnosticsExtensionOverwrittingConfirmation, Properties.Resources.DiagnosticsExtensionOverwrittingCaption))
                    {
                        WriteWarning(Properties.Resources.DiagnosticsExtensionOverwriting);

                        // Remove all existing diagnostics extensions
                        this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = extensions.Where(extension => !DiagnosticsHelper.IsDiagnosticsExtension(extension)).ToList();
                    }
                    else
                    {
                        shouldContinue = false;
                    }
                }

                if (shouldContinue)
                {
                    var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);

                    // Parse configs, and auto fill incomplete parts
                    Tuple<Hashtable, Hashtable> settings = DiagnosticsHelper.GetConfigurationsFromFiles(this.SettingFilePath, this.ProtectedSettingFilePath, this.VirtualMachineScaleSet.Id, this, storageClient);

                    var newDiagnosticsExtension = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetExtension();

                    newDiagnosticsExtension.Name = this.Name;
                    newDiagnosticsExtension.Publisher = DiagnosticsExtensionConstants.ExtensionPublisher;
                    newDiagnosticsExtension.Type = DiagnosticsExtensionConstants.ExtensionType;
                    newDiagnosticsExtension.TypeHandlerVersion = this.TypeHandlerVersion;
                    newDiagnosticsExtension.AutoUpgradeMinorVersion = this.AutoUpgradeMinorVersion;
                    newDiagnosticsExtension.Settings = settings.Item1;
                    newDiagnosticsExtension.ProtectedSettings = settings.Item2;
                    this.VirtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions.Add(newDiagnosticsExtension);
                }
            }

            WriteObject(this.VirtualMachineScaleSet);
        }
    }
}
