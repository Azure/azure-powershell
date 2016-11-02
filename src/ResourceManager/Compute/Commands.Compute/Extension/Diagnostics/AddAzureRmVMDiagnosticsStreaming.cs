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
        ProfileNouns.VirtualMachineDiagnosticsStreaming,
        SupportsShouldProcess = true)]
    public class AddAzureRmVMDiagnosticsStreaming : EtwStreamingVMCmdletBase
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                this.virtualMachine = this.VirtualMachineClient.Get(this.ResourceGroupName, this.VMName);
                FlushMessageWhileWait(EnableEtwListenerAsync());
            });
        }

        private async Task EnableEtwListenerAsync()
        {
            // Enable network security group, add load balancer inbound nat rules
            await SetupNetworkPortsAsync(EtwListenerConstants.EtwListenerPortMap);

            DispatchVerboseMessage(Properties.Resources.UpdatingVirtualMachineExtension);

            var etwExtension = this.virtualMachine.Resources == null ? null : this.virtualMachine.Resources.FirstOrDefault(EtwStreamingHelper.IsEtwListenerExtension);

            if (etwExtension != null && etwExtension.TypeHandlerVersion.Equals(EtwListenerConstants.CurrentVersion, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            // get account unique id
            var keyVault = await this.KeyVaultManagementClient.CreateAzureToolsKeyVaultIfNotExists(this.ResourceGroupName, this.virtualMachine.Location, this.AccountUniqueId, DefaultContext.Tenant.Id);
            var settings = await EtwStreamingHelper.GenerateEtwListenerSettings(this.VMName, this.KeyVaultClient, keyVault.Properties.VaultUri);

            if (this.virtualMachine.OsProfile == null)
            {
                this.virtualMachine.OsProfile = new OSProfile();
            }

            if (this.virtualMachine.OsProfile.Secrets == null)
            {
                this.virtualMachine.OsProfile.Secrets = new List<VaultSecretGroup>();
            }

            var secretGroup = this.virtualMachine.OsProfile.Secrets.FirstOrDefault(v => string.Equals(v.SourceVault.Id, keyVault.Id, StringComparison.OrdinalIgnoreCase));
            if (secretGroup == null)
            {
                secretGroup = new VaultSecretGroup
                {
                    SourceVault = new SubResource(keyVault.Id),
                    VaultCertificates = new List<VaultCertificate>()
                };

                this.virtualMachine.OsProfile.Secrets.Add(secretGroup);
            }
            else if (secretGroup.VaultCertificates == null)
            {
                secretGroup.VaultCertificates = new List<VaultCertificate>();
            }

            secretGroup.VaultCertificates.Add(new VaultCertificate(settings.ServerCertificateUrl, StoreName.My.ToString()));

            this.virtualMachine = await this.VirtualMachineClient.CreateOrUpdateAsync(this.ResourceGroupName, this.VMName, this.virtualMachine);

            etwExtension = new VirtualMachineExtension
            {
                Location = this.virtualMachine.Location,
                Settings = settings,
                Publisher = EtwListenerConstants.EtwListenerExtension.Publisher,
                VirtualMachineExtensionType = EtwListenerConstants.EtwListenerExtension.Type,
                TypeHandlerVersion = EtwListenerConstants.CurrentVersion,
                AutoUpgradeMinorVersion = false
            };

            await this.ComputeClient.ComputeManagementClient.VirtualMachineExtensions
                .CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.VMName, EtwListenerConstants.EtwListenerExtension.Name, etwExtension);
        }
    }
}
