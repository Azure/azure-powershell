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
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsData.Update,
        ProfileNouns.VirtualMachine,
        SupportsShouldProcess = true,
        DefaultParameterSetName = ResourceGroupNameParameterSet)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class UpdateAzureVMCommand : VirtualMachineActionBaseCmdlet
    {
        [Alias("VMProfile")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false)]
        public Hashtable Tags { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = false)]
        [Obsolete("This parameter is obsolete.  Use AssignIdentity parameter instead.", false)]
        [ValidateNotNullOrEmpty]
        public ResourceIdentityType? IdentityType { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AssignIdentity { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.VM.Name, VerbsData.Update))
            {
                ExecuteClientAction(() =>
                {
                    var parameters = new VirtualMachine
                    {
                        DiagnosticsProfile = this.VM.DiagnosticsProfile,
                        HardwareProfile = this.VM.HardwareProfile,
                        StorageProfile = this.VM.StorageProfile,
                        NetworkProfile = this.VM.NetworkProfile,
                        OsProfile = this.VM.OSProfile,
                        Plan = this.VM.Plan,
                        AvailabilitySet = this.VM.AvailabilitySetReference,
                        Location = this.VM.Location,
                        LicenseType = this.VM.LicenseType,
                        Tags = this.Tags != null ? this.Tags.ToDictionary() : this.VM.Tags,
                        Identity = this.AssignIdentity.IsPresent ? new VirtualMachineIdentity(null, null, ResourceIdentityType.SystemAssigned) : this.VM.Identity,
                        Zones = (this.VM.Zones != null && this.VM.Zones.Count > 0) ? this.VM.Zones : null
                    };

                    if (this.IdentityType != null)
                    {
                        parameters.Identity = new VirtualMachineIdentity(null, null, this.IdentityType);
                    }

                    var op = this.VirtualMachineClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VM.Name,
                        parameters).GetAwaiter().GetResult();
                    var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
            }
        }
    }
}
