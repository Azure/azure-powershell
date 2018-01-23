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
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.New,
        ProfileNouns.VirtualMachineConfig),
    OutputType(
        typeof(PSVirtualMachine))]
    public class NewAzureVMConfigCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Alias("ResourceName", "Name")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The VM name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMSize)]
        [ValidateNotNullOrEmpty]
        public string VMSize { get; set; }

        [Parameter(
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Availability Set Id.")]
        [ValidateNotNullOrEmpty]
        public string AvailabilitySetId { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string LicenseType { get; set; }

        [Parameter(
            Position = 4,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        [Obsolete("This parameter is obsolete.  Use AssignIdentity parameter instead.", false)]
        public ResourceIdentityType? IdentityType { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public string [] Zone { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
		[Alias("Tag")]
		public Hashtable Tags { get; set; }

        protected override bool IsUsageMetricEnabled
        {
            get { return true; }
        }

        public override void ExecuteCmdlet()
        {
            var vm = new PSVirtualMachine
            {
                Name = this.VMName,
                AvailabilitySetReference = string.IsNullOrEmpty(this.AvailabilitySetId) ? null : new SubResource
                {
                    Id = this.AvailabilitySetId
                },
                LicenseType = this.LicenseType,
                Identity = this.AssignIdentity.IsPresent ? new VirtualMachineIdentity(null, null, ResourceIdentityType.SystemAssigned) : null,
                Tags = this.Tags != null ? this.Tags.ToDictionary() : null,
                Zones = this.Zone,
            };

            if (this.IdentityType != null)
            {
                vm.Identity = new VirtualMachineIdentity(null, null, ResourceIdentityType.SystemAssigned);
            }
            if (!string.IsNullOrEmpty(this.VMSize))
            {
                vm.HardwareProfile = new HardwareProfile();
                vm.HardwareProfile.VmSize = this.VMSize;
            }

            WriteObject(vm);
        }
    }
}
