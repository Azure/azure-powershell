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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.KeyVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    [Cmdlet(
        VerbsCommon.Add,
        ProfileNouns.VirtualMachineScaleSetDiagnosticsStreaming,
        SupportsShouldProcess = true)]
    [OutputType(typeof(VirtualMachineScaleSet))]
    public class AddAzureRmVmssDiagnosticsStreaming : EtwStreamingVmssCmdletBase
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "Name")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine scale set name.")]
        [ValidateNotNullOrEmpty]
        public string VMScaleSetName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                this.virtualMachineScaleSet = this.ComputeClient.ComputeManagementClient.VirtualMachineScaleSets.Get(this.ResourceGroupName, this.VMScaleSetName);
                FlushMessageWhileWait(EnableEtwListenerAsync());
            });
        }

        private async Task EnableEtwListenerAsync()
        {
            // Enable network security group, add load balancer inbound nat rules
            await SetupNetworkPortsAsync(EtwListenerConstants.EtwListenerPortMap);

            DispatchVerboseMessage(Properties.Resources.UpdatingVirtualMachineScaleSetExtension);

            // VirtualMachineProfile
            if (this.virtualMachineScaleSet.VirtualMachineProfile == null)
            {
                this.virtualMachineScaleSet.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
            }

            // ExtensionProfile
            if (this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile == null)
            {
                this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile = new VirtualMachineScaleSetExtensionProfile();
            }

            // Extensions
            if (this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions == null)
            {
                this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = new List<VirtualMachineScaleSetExtension>();
            }

            IList<VirtualMachineScaleSetExtension> installedExtensions = this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions;

            List<VirtualMachineScaleSetExtension> installedEtwListenerExtensions = installedExtensions.Where(EtwStreamingHelper.IsEtwListenerExtension).ToList();
            if (installedEtwListenerExtensions.Any())
            {
                installedExtensions = installedExtensions.Except(installedEtwListenerExtensions).ToList();
            }

            // If there have multiple extensions exist (by mistake), keep first one and remove others
            VirtualMachineScaleSetExtension etwExtension = installedEtwListenerExtensions.FirstOrDefault();
            if (etwExtension == null || !etwExtension.TypeHandlerVersion.Equals(EtwListenerConstants.CurrentVersion, StringComparison.InvariantCultureIgnoreCase))
            {
                var keyVault = await this.KeyVaultManagementClient.CreateAzureToolsKeyVaultIfNotExists(this.ResourceGroupName, this.virtualMachineScaleSet.Location, this.AccountUniqueId, DefaultContext.Tenant.Id);

                var settings = await EtwStreamingHelper.GenerateEtwListenerSettings(this.VMScaleSetName, this.KeyVaultClient, keyVault.Properties.VaultUri);

                if (this.virtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets == null)
                {
                    this.virtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets = new List<VaultSecretGroup>();
                }

                var secretGroup = this.virtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets.FirstOrDefault(v => string.Equals(v.SourceVault.Id, keyVault.Id, StringComparison.OrdinalIgnoreCase));
                if (secretGroup == null)
                {
                    secretGroup = new VaultSecretGroup
                    {
                        SourceVault = new SubResource(keyVault.Id),
                        VaultCertificates = new List<VaultCertificate>()
                    };

                    this.virtualMachineScaleSet.VirtualMachineProfile.OsProfile.Secrets.Add(secretGroup);
                }
                else if (secretGroup.VaultCertificates == null)
                {
                    secretGroup.VaultCertificates = new List<VaultCertificate>();
                }

                secretGroup.VaultCertificates.Add(new VaultCertificate(settings.ServerCertificateUrl, StoreName.My.ToString()));

                await this.VirtualMachineScaleSetClient.CreateOrUpdateAsync(this.ResourceGroupName, this.VMScaleSetName, this.virtualMachineScaleSet);

                etwExtension = new VirtualMachineScaleSetExtension
                    (name: EtwListenerConstants.EtwListenerExtension.Name,
                    publisher: EtwListenerConstants.EtwListenerExtension.Publisher,
                    type: EtwListenerConstants.EtwListenerExtension.Type,
                    settings: settings,
                    typeHandlerVersion: EtwListenerConstants.CurrentVersion,
                    autoUpgradeMinorVersion: false
                    );

                installedExtensions.Add(etwExtension);
                this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = installedExtensions;
                await this.VirtualMachineScaleSetClient.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.VMScaleSetName, virtualMachineScaleSet);

                if (this.virtualMachineScaleSet.UpgradePolicy.Mode != UpgradeMode.Automatic)
                {
                    DispatchWarningMessage(Properties.Resources.NeedManualUpgradeScaleSetVMs);
                }
            }

            this.virtualMachineScaleSet = this.VirtualMachineScaleSetClient.Get(this.ResourceGroupName, this.VMScaleSetName);
            DispatchOutputMessage(this.virtualMachineScaleSet);
        }
    }
}
