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
        private const string DefaultParameterSetName = "DefaultParameterSet", ExplicitIdentityParameterSet = "ExplicitIdentityParameterSet";
	
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
            ParameterSetName = ExplicitIdentityParameterSet,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public ResourceIdentityType? IdentityType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ExplicitIdentityParameterSet,
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
            HelpMessage = "The eviction policy for the Azure Spot virtual machine.  Supported values are 'Deallocate' and 'Delete'")]
        [PSArgumentCompleter("Deallocate", "Delete")]
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

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = "EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine. This will enable the encryption for all the disks including Resource/Temp disk at host itself.")]
        public SwitchParameter EncryptionAtHost { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Id of the capacity reservation Group that is used to allocate.")]
        [ResourceIdCompleter("Microsoft.Compute/capacityReservationGroups")]
        public string CapacityReservationGroupId { get; set; }

        protected override bool IsUsageMetricEnabled
        {
            get { return true; }
        }
	
	[Parameter(
            Mandatory = false,
            ParameterSetName = ExplicitIdentityParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = DefaultParameterSetName,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        public string UserData { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the fault domain of the virtual machine.")]
        public int PlatformFaultDomain { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The flag that enables or disables hibernation capability on the VM.")]
        public SwitchParameter HibernationEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the number of vCPUs available for the VM. When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://docs.microsoft.com/en-us/rest/api/compute/resource-skus/list).")]
        public int vCPUCountAvailable { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the vCPU to physical core ratio. When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://docs.microsoft.com/en-us/rest/api/compute/resource-skus/list). Setting this property to 1 also means that hyper-threading is disabled.")]
        public int vCPUCountPerCore { get; set; }

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

            if (this.IsParameterBound(c => c.vCPUCountAvailable))
            {
                if (vm.HardwareProfile == null)
                {
                    vm.HardwareProfile = new HardwareProfile();
                }
                if (vm.HardwareProfile.VmSizeProperties == null)
                {
                    vm.HardwareProfile.VmSizeProperties = new VMSizeProperties();
                }
                vm.HardwareProfile.VmSizeProperties.VCPUsAvailable = this.vCPUCountAvailable;
            }

            if (this.IsParameterBound(c => c.vCPUCountPerCore))
            {
                if (vm.HardwareProfile == null)
                {
                    vm.HardwareProfile = new HardwareProfile();
                }
                if (vm.HardwareProfile.VmSizeProperties == null)
                {
                    vm.HardwareProfile.VmSizeProperties = new VMSizeProperties();
                }
                vm.HardwareProfile.VmSizeProperties.VCPUsPerCore = this.vCPUCountPerCore;
            }

            if (this.EnableUltraSSD.IsPresent)
            {
                if (vm.AdditionalCapabilities == null)
                {
                    vm.AdditionalCapabilities = new AdditionalCapabilities();
                }
                vm.AdditionalCapabilities.UltraSSDEnabled = this.EnableUltraSSD;
            }

            if (this.HibernationEnabled.IsPresent)
            {
                if (vm.AdditionalCapabilities == null)
                {
                    vm.AdditionalCapabilities = new AdditionalCapabilities();
                }
                vm.AdditionalCapabilities.HibernationEnabled = this.HibernationEnabled;
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
            
            if (this.EncryptionAtHost.IsPresent)
            {
                if (vm.SecurityProfile == null)
                    vm.SecurityProfile = new SecurityProfile();

                vm.SecurityProfile.EncryptionAtHost = this.EncryptionAtHost.IsPresent;
            }

            if (this.IsParameterBound(c => c.CapacityReservationGroupId))
            {
                vm.CapacityReservation = new CapacityReservationProfile();
                vm.CapacityReservation.CapacityReservationGroup = new SubResource(this.CapacityReservationGroupId);
            }
	    
	        if (this.IsParameterBound(c => c.UserData))
            {
                if (!ValidateBase64EncodedString.ValidateStringIsBase64Encoded(this.UserData))
                {
                    this.UserData = ValidateBase64EncodedString.EncodeStringToBase64(this.UserData);
                    this.WriteInformation(ValidateBase64EncodedString.UserDataEncodeNotification, new string[] { "PSHOST" });
                }
                vm.UserData = this.UserData;
            }

            if (this.IsParameterBound(c => c.PlatformFaultDomain))
            {
                vm.PlatformFaultDomain = this.PlatformFaultDomain;
            }

            WriteObject(vm);
        }
    }
}
