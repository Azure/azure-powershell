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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineScaleSetDiagnosticsStreaming,
        SupportsShouldProcess = true)]
    [OutputType(typeof(VirtualMachineScaleSet))]
    public class RemoveAzureRmVmssDiagnosticsStreaming : EtwStreamingVmssCmdletBase
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
                FlushMessageWhileWait(this.DisableEtwListenerAsync());
            });
        }

        private async Task DisableEtwListenerAsync()
        {
            DispatchVerboseMessage(Properties.Resources.UpdatingVirtualMachineScaleSetExtension);

            if (this.virtualMachineScaleSet.VirtualMachineProfile != null &&
                this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile != null &&
                this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions != null)
            {
                IList<VirtualMachineScaleSetExtension> installedExtensions = this.virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions;
                List<VirtualMachineScaleSetExtension> etwExtension = installedExtensions.Where(EtwStreamingHelper.IsEtwListenerExtension).ToList();
                if (etwExtension.Any())
                {
                    virtualMachineScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions = installedExtensions.Except(etwExtension).ToList();
                }

                await this.ComputeClient.ComputeManagementClient.VirtualMachineScaleSets.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.VMScaleSetName, virtualMachineScaleSet);

                if (this.virtualMachineScaleSet.UpgradePolicy.Mode != UpgradeMode.Automatic)
                {
                    DispatchWarningMessage(Properties.Resources.NeedManualUpgradeScaleSetVMs);
                }
            }

            // Remove network security group rules and load balancer inbound NAT rules
            await CleanupNetworkPortsAsync(EtwListenerConstants.EtwListenerPortMap);

            this.virtualMachineScaleSet = this.VirtualMachineScaleSetClient.Get(this.ResourceGroupName, this.VMScaleSetName);
            DispatchOutputMessage(this.virtualMachineScaleSet);
        }
    }
}
