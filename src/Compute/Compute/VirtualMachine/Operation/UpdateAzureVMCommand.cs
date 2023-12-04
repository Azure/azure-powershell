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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupNameParameterSet)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class UpdateAzureVMCommand : VirtualMachineBaseCmdlet
    {
        private const string ResourceGroupNameParameterSet = "ResourceGroupNameParameterSetName";
        private const string IdParameterSet = "IdParameterSetName";
        private const string ExplicitIdentityParameterSet = "ExplicitIdentityParameterSet";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ExplicitIdentityParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = IdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceIdCompleter("Microsoft.Compute/virtualMachines")]
        public string Id { get; set; }

        [Alias("VMProfile")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ExplicitIdentityParameterSet,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public ResourceIdentityType? IdentityType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ExplicitIdentityParameterSet,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string[] IdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        public bool OsDiskWriteAccelerator { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public bool UltraSSDEnabled { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The max price of the billing of a low priority virtual machine")]
        public double MaxPrice { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine. This will enable the encryption for all the disks including Resource/Temp disk at host itself.")]
        public bool EncryptionAtHost { get; set; }
        [Parameter(
            Mandatory = false)]
        [AllowEmptyString]
        public string ProximityPlacementGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Attached Virtual Machine Scale Set Id.")]
        [AllowEmptyString]
        public string VirtualMachineScaleSetId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id of Host")]
        public string HostId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Id of the capacity reservation Group that is used to allocate.")]
        [ResourceIdCompleter("Microsoft.Compute/capacityReservationGroups")]
        public string CapacityReservationGroupId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }
        
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceGroupNameParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = IdParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = ExplicitIdentityParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        public string UserData { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The flag that enables or disables hibernation capability on the VM.")]
        public SwitchParameter HibernationEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the number of vCPUs available for the VM. When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).")]
        public int vCPUCountAvailable { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the vCPU to physical core ratio. When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list). Setting this property to 1 also means that hyper-threading is disabled.")]
        public int vCPUCountPerCore { get; set; }
        
        [Parameter(
           HelpMessage = "Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. By default, UefiSettings will not be enabled unless this property is set.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("TrustedLaunch", "ConfidentialVM")]
        public string SecurityType { get; set; }

        [Parameter(
         HelpMessage = "Specifies whether vTPM should be enabled on the virtual machine.",
         ValueFromPipelineByPropertyName = true,
         Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? EnableVtpm { get; set; } = null;

        [Parameter(
           HelpMessage = "Specifies whether secure boot should be enabled on the virtual machine.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? EnableSecureBoot { get; set; } = null;

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.UserData))
            {
                if (!ValidateBase64EncodedString.ValidateStringIsBase64Encoded(this.UserData))
                {
                    this.UserData = ValidateBase64EncodedString.EncodeStringToBase64(this.UserData);
                    this.WriteInformation(ValidateBase64EncodedString.UserDataEncodeNotification, new string[] { "PSHOST" });
                }
            }

            base.ExecuteCmdlet();

            if (this.ParameterSetName.Equals(IdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroupNameFromId(this.Id);
            }

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
                        BillingProfile = this.VM.BillingProfile,
                        SecurityProfile = this.VM.SecurityProfile,
                        Plan = this.VM.Plan,
                        AvailabilitySet = this.VM.AvailabilitySetReference,
                        Location = this.VM.Location,
                        ExtendedLocation = this.VM.ExtendedLocation,
                        LicenseType = this.VM.LicenseType,
                        Tags = this.Tag != null ? this.Tag.ToDictionary() : this.VM.Tags,
                        Identity = ComputeAutoMapperProfile.Mapper.Map<VirtualMachineIdentity>(this.VM.Identity),
                        Zones = (this.VM.Zones != null && this.VM.Zones.Count > 0) ? this.VM.Zones : null,
                        ProximityPlacementGroup = this.IsParameterBound(c => c.ProximityPlacementGroupId)
                                                ? new SubResource(this.ProximityPlacementGroupId)
                                                : this.VM.ProximityPlacementGroup,
                        Host = this.IsParameterBound(c => c.HostId)
                             ? new SubResource(this.HostId)
                             : this.VM.Host,
                        VirtualMachineScaleSet = this.IsParameterBound(c => c.VirtualMachineScaleSetId)
                                                ? new SubResource(this.VirtualMachineScaleSetId)
                                                : this.VM.VirtualMachineScaleSet,
                        AdditionalCapabilities = this.VM.AdditionalCapabilities,
                        EvictionPolicy = this.VM.EvictionPolicy,
                        Priority = this.VM.Priority,
                        CapacityReservation = this.VM.CapacityReservation,
                        ApplicationProfile = ComputeAutoMapperProfile.Mapper.Map<ApplicationProfile>(this.VM.ApplicationProfile),
                        UserData = this.IsParameterBound(c => c.UserData)
                            ? this.UserData
                            : this.VM.UserData
                    };

                    if (parameters.Host != null && string.IsNullOrWhiteSpace(parameters.Host.Id))
                    {
                        parameters.Host.Id = null;
                    }

                    if (parameters.ProximityPlacementGroup != null && string.IsNullOrWhiteSpace(parameters.ProximityPlacementGroup.Id))
                    {
                        parameters.ProximityPlacementGroup.Id = null;
                    }

                    // when vm.virtualMachineScaleSet.Id is set to null, powershell interprets it as empty so converting it back to null
                    if (parameters.VirtualMachineScaleSet != null && string.IsNullOrWhiteSpace(parameters.VirtualMachineScaleSet.Id))
                    {
                        parameters.VirtualMachineScaleSet.Id = null;
                    }

                    if (this.IsParameterBound(c => c.IdentityType))
                    {
                        parameters.Identity = new VirtualMachineIdentity(null, null, this.IdentityType, null);
                    }

                    if (this.IsParameterBound(c => c.IdentityId))
                    {
                        if (parameters.Identity == null)
                        {
                            parameters.Identity = new VirtualMachineIdentity();

                        }

                        parameters.Identity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentitiesValue>();

                        foreach (var id in this.IdentityId)
                        {
                            parameters.Identity.UserAssignedIdentities.Add(id, new UserAssignedIdentitiesValue());
                        }
                    }

                    if (this.IsParameterBound(c => c.OsDiskWriteAccelerator))
                    {
                        if (parameters.StorageProfile == null)
                        {
                            parameters.StorageProfile = new StorageProfile();
                        }
                        if (parameters.StorageProfile.OsDisk == null)
                        {
                            parameters.StorageProfile.OsDisk = new OSDisk();
                        }
                        parameters.StorageProfile.OsDisk.WriteAcceleratorEnabled = this.OsDiskWriteAccelerator;
                    }

                    if (this.IsParameterBound(c => c.UltraSSDEnabled))
                    {
                        if (parameters.AdditionalCapabilities == null)
                        {
                            parameters.AdditionalCapabilities = new AdditionalCapabilities();
                        }
                        parameters.AdditionalCapabilities.UltraSSDEnabled = this.UltraSSDEnabled;
                    }

                    if (this.IsParameterBound(c => c.HibernationEnabled))
                    {
                        if (parameters.AdditionalCapabilities == null)
                        {
                            parameters.AdditionalCapabilities = new AdditionalCapabilities();
                        }
                        parameters.AdditionalCapabilities.HibernationEnabled = this.HibernationEnabled;
                    }

                    if (this.IsParameterBound(c => c.MaxPrice))
                    {
                        if (parameters.BillingProfile == null)
                        {
                            parameters.BillingProfile = new BillingProfile();
                        }
                        parameters.BillingProfile.MaxPrice = this.MaxPrice;
                    }

                    if (this.IsParameterBound(c => c.EncryptionAtHost))
                    {
                        if (parameters.SecurityProfile == null)
                        {
                            parameters.SecurityProfile = new SecurityProfile();
                        }
                        parameters.SecurityProfile.EncryptionAtHost = this.EncryptionAtHost;
                    }
                    
                    if (this.IsParameterBound( c => c.SecurityType))
                    {
                        if (parameters.SecurityProfile == null)
                        {
                            parameters.SecurityProfile = new SecurityProfile();
                        }
                        if (parameters.SecurityProfile.UefiSettings == null)
                        {
                            parameters.SecurityProfile.UefiSettings = new UefiSettings();
                        }
                        parameters.SecurityProfile.SecurityType = this.SecurityType;
                        if (parameters.SecurityProfile.SecurityType == "TrustedLaunch" || parameters.SecurityProfile.SecurityType == "ConfidentialVM")
                        {
                            parameters.SecurityProfile.UefiSettings.VTpmEnabled = parameters.SecurityProfile.UefiSettings.VTpmEnabled == null ? true : this.EnableVtpm;
                            parameters.SecurityProfile.UefiSettings.SecureBootEnabled = parameters.SecurityProfile.UefiSettings.SecureBootEnabled == null ? true : this.EnableSecureBoot;
                        }
                    }

                    if (this.IsParameterBound(c => c.EnableVtpm))
                    {
                        if (parameters.SecurityProfile == null)
                        {
                            parameters.SecurityProfile = new SecurityProfile();
                        }
                        if (parameters.SecurityProfile.UefiSettings == null)
                        {
                            parameters.SecurityProfile.UefiSettings = new UefiSettings();
                        }
                        parameters.SecurityProfile.UefiSettings.VTpmEnabled = this.EnableVtpm;    
                    }

                    if (this.IsParameterBound(c => c.EnableSecureBoot))
                    {
                        if (parameters.SecurityProfile == null)
                        {
                            parameters.SecurityProfile = new SecurityProfile();
                        }
                        if (parameters.SecurityProfile.UefiSettings == null)
                        {
                            parameters.SecurityProfile.UefiSettings = new UefiSettings();
                        }
                        parameters.SecurityProfile.UefiSettings.SecureBootEnabled = this.EnableSecureBoot;
                    }

                    if (this.IsParameterBound(c => c.CapacityReservationGroupId))
                    {
                        if (parameters.CapacityReservation == null)
                        {
                            parameters.CapacityReservation = new CapacityReservationProfile();
                        }
                        parameters.CapacityReservation.CapacityReservationGroup = new SubResource(CapacityReservationGroupId);
                    }

                    if (parameters.StorageProfile != null && parameters.StorageProfile.ImageReference != null && parameters.StorageProfile.ImageReference.Id != null)
                    {
                        parameters.StorageProfile.ImageReference.Id = null;
                    }

                    if (this.IsParameterBound(c => c.vCPUCountPerCore))
                    {
                        if (parameters.HardwareProfile == null)
                        {
                            parameters.HardwareProfile = new HardwareProfile();
                        }
                        if (parameters.HardwareProfile.VmSizeProperties == null)
                        {
                            parameters.HardwareProfile.VmSizeProperties = new VMSizeProperties();
                        }
                        parameters.HardwareProfile.VmSizeProperties.VCPUsPerCore = this.vCPUCountPerCore;
                    }

                    if (this.IsParameterBound(c => c.vCPUCountAvailable))
                    {
                        if (parameters.HardwareProfile == null)
                        {
                            parameters.HardwareProfile = new HardwareProfile();
                        }
                        if (parameters.HardwareProfile.VmSizeProperties == null)
                        {
                            parameters.HardwareProfile.VmSizeProperties = new VMSizeProperties();
                        }
                        parameters.HardwareProfile.VmSizeProperties.VCPUsAvailable = this.vCPUCountAvailable;
                    }

                    if (NoWait.IsPresent)
                    {
                        var op = this.VirtualMachineClient.BeginCreateOrUpdateWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.VM.Name,
                            parameters).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else
                    {
                        var op = this.VirtualMachineClient.CreateOrUpdateWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.VM.Name,
                            parameters).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                });
            }
        }
    }
}
