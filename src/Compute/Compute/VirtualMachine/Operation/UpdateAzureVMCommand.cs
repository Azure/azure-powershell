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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id of Host")]
        public string HostId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }

        public override void ExecuteCmdlet()
        {
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
                        VirtualMachineScaleSet = this.VM.VirtualMachineScaleSet,
                        AdditionalCapabilities = this.VM.AdditionalCapabilities,
                        EvictionPolicy = this.VM.EvictionPolicy,
                        Priority = this.VM.Priority
                    };

                    if (parameters.Host != null && string.IsNullOrWhiteSpace(parameters.Host.Id))
                    {
                        parameters.Host.Id = null;
                    }

                    if (parameters.ProximityPlacementGroup != null && string.IsNullOrWhiteSpace(parameters.ProximityPlacementGroup.Id))
                    {
                        parameters.ProximityPlacementGroup.Id = null;
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

                        parameters.Identity.UserAssignedIdentities = new Dictionary<string, VirtualMachineIdentityUserAssignedIdentitiesValue>();

                        foreach (var id in this.IdentityId)
                        {
                            parameters.Identity.UserAssignedIdentities.Add(id, new VirtualMachineIdentityUserAssignedIdentitiesValue());
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
