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

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineDiagnosticsStreaming,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachine))]
    public class RemoveAzureRmVMDiagnosticsStreaming : EtwStreamingVMCmdletBase
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VMName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                this.virtualMachine = this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.Name);
                FlushMessageWhileWait(DisableEtwListenerAsync());
            });
        }

        private async Task DisableEtwListenerAsync()
        {
            DispatchVerboseMessage(Properties.Resources.UpdatingVirtualMachineExtension);


            var etwExtension = this.virtualMachine.Resources == null? null: 
                this.virtualMachine.Resources.FirstOrDefault(EtwStreamingHelper.IsEtwListenerExtension);

            if (etwExtension != null)
            {
                await this.ComputeClient.ComputeManagementClient.VirtualMachineExtensions.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.Name, etwExtension.Name);
            }

            // Remove network security group rules and load balancer inbound NAT rules
            await CleanupNetworkPortsAsync(EtwListenerConstants.EtwListenerPortMap, new[] { EtwListenerConstants.EtwListenerExtension });

            this.virtualMachine = this.VirtualMachineClient.Get(this.ResourceGroupName, this.Name);
            DispatchOutputMessage(Mapper.Map<PSVirtualMachine>(this.virtualMachine));
        }
    }
}
