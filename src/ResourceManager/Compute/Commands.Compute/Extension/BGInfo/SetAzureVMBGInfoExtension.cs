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
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineBgInfoExtension,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMBGInfoExtensionCommand : SetAzureVMExtensionBaseCmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (ShouldProcess(VirtualMachineBGInfoExtensionContext.ExtensionDefaultName, VerbsCommon.Set))
            {
                ExecuteClientAction(() =>
                {
                    if (string.IsNullOrEmpty(this.Location))
                    {
                        this.Location = GetLocationFromVm(this.ResourceGroupName, this.VMName);
                    }

                    var parameters = new VirtualMachineExtension
                    {
                        Location = this.Location,
                        Publisher = VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher,
                        VirtualMachineExtensionType = VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                        TypeHandlerVersion = this.TypeHandlerVersion ?? VirtualMachineBGInfoExtensionContext.ExtensionDefaultVersion,
                        AutoUpgradeMinorVersion = !this.DisableAutoUpgradeMinorVersion.IsPresent,
                        ForceUpdateTag = this.ForceRerun
                    };

                    var op = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VMName,
                        this.Name ?? VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                        parameters).GetAwaiter().GetResult();

                    var result = Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
            }
        }
    }
}
