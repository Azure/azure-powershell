﻿// ----------------------------------------------------------------------------------
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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMConfig", DefaultParameterSetName = "DefaultParameterSet"), OutputType(typeof(PSVirtualMachine))]
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
            Mandatory = true,
            ParameterSetName = "ExplicitIdentityParameterSet",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public ResourceIdentityType? IdentityType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "ExplicitIdentityParameterSet",
            ValueFromPipelineByPropertyName = true)]
        public string[] IdentityId { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public string [] Zone { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id of ProximityPlacementGroup")]
        public string ProximityPlacementGroupId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id of Host")]
        public string HostId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id of virtual machine scale set")]
        public string VmssId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The max price of the billing of a low priority virtual machine.")]
        public double MaxPrice { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The eviction policy for the low priority virtual machine.  Only supported value is 'Deallocate'.")]
        [PSArgumentCompleter("Deallocate")]
        public string EvictionPolicy { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The priority for the virtual machine. Only supported values are 'Regular', 'Spot' and 'Low'. 'Regular' is for regular virtual machine. 'Spot' is for spot virtual machine. 'Low' is also for spot virtual machine but is replaced by 'Spot'. Please use 'Spot' instead of 'Low'.")]
        [PSArgumentCompleter("Regular", "Spot")]
        public string Priority { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
		[Alias("Tag")]
		public Hashtable Tags { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public SwitchParameter EnableUltraSSD { get; set; }

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
                Identity = null,
                Tags = this.Tags != null ? this.Tags.ToDictionary() : null,
                Zones = this.Zone,
                EvictionPolicy = this.EvictionPolicy,
                Priority = this.Priority
            };

            if (this.IsParameterBound(c => c.IdentityType))
            {
                vm.Identity = new VirtualMachineIdentity(null, null, this.IdentityType);
            }

            if (this.IsParameterBound(c => c.IdentityId))
            {
                if (vm.Identity == null)
                {
                    vm.Identity = new VirtualMachineIdentity();
                }

                vm.Identity.UserAssignedIdentities = new Dictionary<string, VirtualMachineIdentityUserAssignedIdentitiesValue>();

                foreach (var id in this.IdentityId)
                {
                    vm.Identity.UserAssignedIdentities.Add(id, new VirtualMachineIdentityUserAssignedIdentitiesValue());
                }
            }

            if (!string.IsNullOrEmpty(this.VMSize))
            {
                vm.HardwareProfile = new HardwareProfile();
                vm.HardwareProfile.VmSize = this.VMSize;
            }

            if (this.EnableUltraSSD.IsPresent)
            {
                vm.AdditionalCapabilities = new AdditionalCapabilities(true);
            }

            if (this.IsParameterBound(c => c.ProximityPlacementGroupId))
            {
                vm.ProximityPlacementGroup = new SubResource(this.ProximityPlacementGroupId);
            }

            if (this.IsParameterBound(c => c.HostId))
            {
                vm.Host = new SubResource(this.HostId);
            }

            if (this.IsParameterBound(c => c.VmssId))
            {
                vm.VirtualMachineScaleSet = new SubResource(this.VmssId);
            }

            if (this.IsParameterBound(c => c.MaxPrice))
            {
                vm.BillingProfile = new BillingProfile(this.MaxPrice);
            }

            WriteObject(vm);
        }
    }
}
