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

using System;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Job = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models.Job;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Enables replication for an ASR protectable item by creating a replication protected item.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectedItem", DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise, SupportsShouldProcess = true)]
    [Alias("New-ASRReplicationProtectedItem")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrReplicationProtectedItem : SiteRecoveryCmdletBase
    {
        const string VMwareToAzureParameterSet = "VMwareToAzure";
        const string VMwareToAzureWithDiskType = "VMwareToAzureWithDiskType";
        /// <summary>
        ///    Switch parameter to specify the replicated item is a VMware virtual machine 
        ///    or physical server that will be replicate to Azure.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = VMwareToAzureWithDiskType,
            Mandatory = true)]
        [Parameter(
            Position = 0,
            ParameterSetName = VMwareToAzureParameterSet,
            Mandatory = true)]
        public SwitchParameter VMwareToAzure { get; set; }

        /// <summary>
        ///    Switch parameter to specify the replicated item is a Hyper-V virtual machine that 
        ///    is being replicated to Azure.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = false)]
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.HyperVSiteToAzure,
            Mandatory = false)]
        public SwitchParameter HyperVToAzure { get; set; }

        /// <summary>
        ///    Switch parameter to specify the replicated item is a Hyper-V virtual machine that is
        ///    being replicated between VMM managed Hyper-V sites.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = false)]
        public SwitchParameter VmmToVmm { get; set; }

        /// <summary>
        ///    Switch parameter to specify that the replicated item is an Azure virtual machine 
        ///    replicating to a recovery Azure region.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = false,
            HelpMessage = "Switch parameter specifies creating the replicated item in azure to azure scenario.")]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails,
            Mandatory = false,
            HelpMessage = "Switch parameter specifies creating the replicated item in azure to azure scenario.")]
        public SwitchParameter AzureToAzure { get; set; }

        /// <summary>
        ///     Gets or sets protectable item object for which replication is being enabled.
        ///     Not needed in A2A.
        /// </summary>
        [Parameter(
           ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
           Mandatory = true,
           ValueFromPipeline = true)]
        [Parameter(
           ParameterSetName = ASRParameterSets.EnterpriseToAzure,
           Mandatory = true,
           ValueFromPipeline = true)]
        [Parameter(
           ParameterSetName = ASRParameterSets.HyperVSiteToAzure,
           Mandatory = true,
           ValueFromPipeline = true)]
        [Parameter(
           ParameterSetName = VMwareToAzureWithDiskType,
           Mandatory = true,
           ValueFromPipeline = true)]
        [Parameter(
           ParameterSetName = VMwareToAzureParameterSet,
           Mandatory = true,
           ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectableItem ProtectableItem { get; set; }

        /// <summary>
        ///    Gets or sets  the list of virtual machine disks to replicated 
        ///    and the cache storage account and recovery storage account to be used to replicate the disk.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specifies the disk configuration to used Vm for Azure to Azure disaster recovery scenario.")]
        [ValidateNotNullOrEmpty]
        public ASRAzuretoAzureDiskReplicationConfig[] AzureToAzureDiskReplicationConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the azure vm id to be replicated.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AzureVmId { get; set; }

        /// <summary>
        ///     Gets or sets a name for the ASR replication protected item. The name must be unique within the vault.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets name of the recovery Vm created after failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryVmName { get; set; }

        /// <summary>
        ///     Gets or sets the ASR protection container mapping object corresponding to
        ///     the replication policy to be used for replication..
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the Azure storage account to replicate to.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the operating system disk.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OSDiskName { get; set; }

        /// <summary>
        ///     Gets or sets the operating system family.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.OSWindows,Constants.OSLinux)]
        public string OS { get; set; }

        /// <summary>
        /// Gets or sets run as account to be used to push install the Mobility service if needed.
        /// Must be one from the list of run as accounts in the ASR fabric.
        /// </summary>
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType, Mandatory = true)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRunAsAccount Account { get; set; }

        /// <summary>
        ///     Gets or sets Vm log azure storage account Id.
        /// </summary>
        [Parameter(ParameterSetName = VMwareToAzureParameterSet)]
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets list of disks to include for replication. By default all disks are included.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [ValidateNotNullOrEmpty]
        public string[] IncludeDiskId { get; set; }

        /// <summary>
        ///     Gets or sets list of disks configuration to include for replication. By default all disks are included.
        /// </summary>

        [Parameter(ParameterSetName = VMwareToAzureParameterSet, Mandatory = false)]
        public AsrInMageAzureV2DiskInput[] InMageAzureV2DiskInput { get; set; }

        /// <summary>
        ///     Gets or sets the Process Server to use to replicate this machine. Use the list of process servers
        ///     in the ASR fabric corresponding to the Configuration server to specify one.
        /// </summary>
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType, Mandatory = true)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProcessServer ProcessServer { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the Azure virtual network to recover the machine to in the event of a failover.
        /// </summary>
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the he subnet within the recovery Azure virtual network to which the failed over 
        ///     virtual machine should be attached in the event of a failover.
        /// </summary>
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the resource group in which the virtual machine will be created in the event of a failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType, Mandatory = true)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the replication group name to use to create multi-VM consistent recovery points.
        /// </summary>
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string ReplicationGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the recovery cloud service to failover this virtual machine to.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [ValidateNotNullOrEmpty]
        public string RecoveryCloudServiceId { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the recovery cloud service to failover this virtual machine to.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, HelpMessage = "Specify the availability zone to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails, HelpMessage = "Specify the availability zone to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType, HelpMessage = "Specify the availability zone to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet, HelpMessage = "Specify the availability zone to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, HelpMessage = "Specify the availability zone to used by the failover Vm in target recovery region.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of proximity placement group to failover this virtual machine to.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, HelpMessage = "Specify the proximity placement group Id to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails, HelpMessage = "Specify the proximity placement group Id to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType, HelpMessage = "Specify the proximity placement group Id to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet, HelpMessage = "Specify the proximity placement group Id to used by the failover Vm in target recovery region.")]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, HelpMessage = "Specify the proximity placement group Id to used by the failover Vm in target recovery region.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Gets or sets ID of the AvailabilitySet to recover the machine to in the event of a failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        ///     Gets or sets if the Azure virtual machine that is created on failover should use managed disks.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.True,
            Constants.False)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        public string UseManagedDisk { get; set; }

        /// <summary>
        /// Gets or sets BootDiagnosticStorageAccountId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        public string RecoveryBootDiagStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionVaultId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        public string DiskEncryptionVaultId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionSecretUrl.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        public string DiskEncryptionSecretUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionKeyUrl.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        public string KeyEncryptionKeyUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionVaultId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        public string KeyEncryptionVaultId { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary> 
        ///     Gets or sets the recovery disk storage account ARM Id.  
        /// </summary> 
        /// [Parameter(ParameterSetName = VMwareToAzureWithDiskDetils)] 
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType, HelpMessage = "Specifies the Recovery VM managed disk type.", Mandatory =true)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS", "StandardSSD_LRS")]
        public string DiskType { get; set; }

        /// <summary>
        /// Gets or sets the DiskEncryptionSet ARM ID.
        /// </summary>
        [Parameter(ParameterSetName = VMwareToAzureWithDiskType)]
        [Parameter(ParameterSetName = VMwareToAzureParameterSet)]
        public string DiskEncryptionSetId { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(this.Name, VerbsCommon.New))
            {
                var policy = this.RecoveryServicesClient.GetAzureSiteRecoveryPolicy(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.PolicyId,
                        ARMResourceTypeConstants.ReplicationPolicies));
                var policyInstanceType = policy.Properties.ProviderSpecificDetails;

                var enableProtectionProviderSpecificInput =
                    new EnableProtectionProviderSpecificInput();
                var inputProperties = new EnableProtectionInputProperties
                {
                    PolicyId = this.ProtectionContainerMapping.PolicyId,
                    // A2A there is no ProtectableItem
                    ProtectableItemId = this.ProtectableItem == null ? null : this.ProtectableItem.ID,
                    ProviderSpecificDetails = enableProtectionProviderSpecificInput
                };

                var input = new EnableProtectionInput { Properties = inputProperties };

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToEnterprise:
                        if (!(policyInstanceType is HyperVReplicaPolicyDetails) &&
                            !(policyInstanceType is HyperVReplicaBluePolicyDetails))
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    Resources.ContainerMappingParameterSetMismatch,
                                    this.ProtectionContainerMapping.Name,
                                    policyInstanceType));
                        }
                        break;

                    case ASRParameterSets.EnterpriseToAzure:
                    case ASRParameterSets.HyperVSiteToAzure:
                        if (!(policyInstanceType is HyperVReplicaAzurePolicyDetails))
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    Resources.ContainerMappingParameterSetMismatch,
                                    this.ProtectionContainerMapping.Name,
                                    policyInstanceType));
                        }
                        EnterpriseAndHyperVToAzure(input);
                        break;

                    case VMwareToAzureWithDiskType:
                    case VMwareToAzureParameterSet:
                        if (!(policyInstanceType is InMageAzureV2PolicyDetails))
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    Resources.ContainerMappingParameterSetMismatch,
                                    this.ProtectionContainerMapping.Name,
                                    policyInstanceType));
                        }

                        VMwareToAzureReplication(input);
                        break;

                    case ASRParameterSets.AzureToAzureWithoutDiskDetails:
                    case ASRParameterSets.AzureToAzure:
                        if (!(policyInstanceType is A2APolicyDetails))
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    Properties.Resources.ContainerMappingParameterSetMismatch,
                                    this.ProtectionContainerMapping.Name,
                                    policyInstanceType));
                        }
                        AzureToAzureReplication(input);
                        break;

                    default:
                        break;
                }

                this.response = this.RecoveryServicesClient.EnableProtection(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.Name,
                    input);

                this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(this.response.Location));

                this.WriteObject(new ASRJob(this.jobResponse));

                if (this.WaitForCompletion.IsPresent)
                {
                    this.WaitForJobCompletion(this.jobResponse.Name);

                    this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                        PSRecoveryServicesClient
                            .GetJobIdFromReponseLocation(this.response.Location));

                    this.WriteObject(new ASRJob(this.jobResponse));
                }
            }
        }

        private void VMwareToAzureReplication(EnableProtectionInput input)
        {
            var providerSettings = new InMageAzureV2EnableProtectionInput
            {
                ProcessServerId = this.ProcessServer.Id,
                MasterTargetId =
                        this.ProcessServer.Id, // Assumption: PS and MT are same.
                RunAsAccountId = this.Account.AccountId,
                StorageAccountId = this.RecoveryAzureStorageAccountId,
                TargetAzureNetworkId = this.RecoveryAzureNetworkId,
                TargetAzureSubnetId = this.RecoveryAzureSubnetName,
                LogStorageAccountId = this.LogStorageAccountId,
                MultiVmGroupName = this.ReplicationGroupName,
                DiskType = this.DiskType,
                MultiVmGroupId = this.ReplicationGroupName,
                TargetAzureVmName = string.IsNullOrEmpty(this.RecoveryVmName)
                                            ? this.ProtectableItem.FriendlyName
                                            : this.RecoveryVmName,
                EnableRdpOnTargetOption = Constants.NeverEnableRDPOnTargetOption,
                DiskEncryptionSetId = this.DiskEncryptionSetId,
                TargetAvailabilityZone = this.RecoveryAvailabilityZone,
                TargetProximityPlacementGroupId = this.RecoveryProximityPlacementGroupId
            };

            if (this.IsParameterBound(c => c.InMageAzureV2DiskInput))
            {
                List<InMageAzureV2DiskInputDetails> inmageAzureV2DiskInput = InMageAzureV2DiskInput.Select(
                    p => new InMageAzureV2DiskInputDetails()
                    {
                        DiskId = p.DiskId,
                        DiskType = p.DiskType,
                        LogStorageAccountId = p.LogStorageAccountId,
                        DiskEncryptionSetId = p.DiskEncryptionSetId
                    }).ToList();
                providerSettings.DisksToInclude = inmageAzureV2DiskInput;
            }

            providerSettings.TargetAzureV2ResourceGroupId =
                this.RecoveryResourceGroupId;

            // Check if the Replication Group Name is valid.
            if (this.ReplicationGroupName != null)
            {
                // Get all the Protected Items in the Protection Container.
                var fabricName = Utilities.GetValueFromArmId(
                    this.ProtectableItem.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);
                var protectionContainerName = Utilities.GetValueFromArmId(
                    this.ProtectableItem.ID,
                    ARMResourceTypeConstants.ReplicationProtectionContainers);
                var listReplicationProtectedItems =
                    this.RecoveryServicesClient
                        .GetAzureSiteRecoveryReplicationProtectedItem(
                            fabricName,
                            protectionContainerName);

                // Loop over all the Protected Items and find if the Multi VM Group already exists.
                var flag = false;
                foreach (var rpi in listReplicationProtectedItems)
                // Check if the Replication Protected Item is an InMageAzureV2 Instance.
                {
                    if (rpi.Properties.ProviderSpecificDetails is InMageAzureV2ReplicationDetails)
                    {
                        // Get the InMageAzureV2 specific details.
                        var providerSpecificDetails =
                            (InMageAzureV2ReplicationDetails)rpi.Properties
                                .ProviderSpecificDetails;

                        // Compare the Multi VM Group Name.
                        if (string.Compare(
                                this.ReplicationGroupName,
                                providerSpecificDetails.MultiVmGroupName,
                                StringComparison.OrdinalIgnoreCase) ==
                            0)
                        {
                            // Multi VM Group found.
                            // Set the values in the InMageAzureV2 Provider specific input.
                            providerSettings.MultiVmGroupName =
                                providerSpecificDetails.MultiVmGroupName;
                            providerSettings.MultiVmGroupId =
                                providerSpecificDetails.MultiVmGroupId;
                            flag = true;
                            break;
                        }
                    }
                }

                // Check if the Multi VM Group was found or is to be created now.
                if (flag == false)
                {
                    // Multi VM Group was not found.
                    // Create a new Multi VM Group and Set the values in the 
                    // InMageAzureV2 Provider specific input.
                    providerSettings.MultiVmGroupName = this.ReplicationGroupName;
                    providerSettings.MultiVmGroupId = Guid.NewGuid().ToString();
                }
            }

            // Set the InMageAzureV2 Provider specific input in the Enable Protection Input.
            input.Properties.ProviderSpecificDetails = providerSettings;
        }

        /// <summary>
        ///     Helper method for E2A and H2A scenario.
        /// </summary>
        private void EnterpriseAndHyperVToAzure(EnableProtectionInput input)
        {
            var providerSettings = new HyperVReplicaAzureEnableProtectionInput();

            providerSettings.HvHostVmId = this.ProtectableItem.FabricObjectId;
            providerSettings.VmName = this.ProtectableItem.FriendlyName;
            providerSettings.TargetAzureVmName = string.IsNullOrEmpty(this.RecoveryVmName)
                                                    ? this.ProtectableItem.FriendlyName
                                                    : this.RecoveryVmName;
            providerSettings.TargetProximityPlacementGroupId = this.RecoveryProximityPlacementGroupId;
            providerSettings.TargetAvailabilityZone = this.RecoveryAvailabilityZone;
            providerSettings.UseManagedDisks = this.UseManagedDisk;

            if (!string.IsNullOrEmpty(this.RecoveryAzureNetworkId))
            {
                providerSettings.TargetAzureNetworkId = this.RecoveryAzureNetworkId;
            }

            if (!string.IsNullOrEmpty(this.RecoveryAzureSubnetName))
            {
                providerSettings.TargetAzureSubnetId = this.RecoveryAzureSubnetName;
            }

            if (!string.IsNullOrEmpty(this.LogStorageAccountId))
            {
                providerSettings.LogStorageAccountId = this.LogStorageAccountId;
            }

            // Id disk details are missing in input PE object, get the latest PE.
            if (string.IsNullOrEmpty(this.ProtectableItem.OS))
            {
                // Just checked for OS to see whether the disk details got filled up or not
                var protectableItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryProtectableItem(
                        Utilities.GetValueFromArmId(
                            this.ProtectableItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectableItem.ProtectionContainerId,
                        this.ProtectableItem.Name);

                this.ProtectableItem = new ASRProtectableItem(protectableItemResponse);
            }

            if (string.IsNullOrWhiteSpace(this.OS))
            {
                providerSettings.OsType = (string.Compare(
                                               this.ProtectableItem.OS,
                                               Constants.OSWindows,
                                               StringComparison.OrdinalIgnoreCase) ==
                                           0) ||
                                          (string.Compare(
                                               this.ProtectableItem.OS,
                                               Constants.OSLinux) ==
                                           0)
                                ? this.ProtectableItem.OS
                                : Constants.OSWindows;
            }
            else
            {
                providerSettings.OsType = this.OS;
            }

            if (string.IsNullOrWhiteSpace(this.OSDiskName))
            {
                providerSettings.VhdId = this.ProtectableItem.OSDiskId;
            }
            else
            {
                foreach (var disk in this.ProtectableItem.Disks)
                {
                    if (0 == string.Compare(disk.Name, this.OSDiskName, true))
                    {
                        providerSettings.VhdId = disk.Id;
                        break;
                    }
                }
            }

            if (this.RecoveryAzureStorageAccountId != null)
            {
                providerSettings.TargetStorageAccountId =
                    this.RecoveryAzureStorageAccountId;
            }

            var deploymentType = Utilities.GetValueFromArmId(
                this.RecoveryAzureStorageAccountId,
                ARMResourceTypeConstants.Providers);
            if (deploymentType.ToLower()
                .Contains(Constants.Classic.ToLower()))
            {
                providerSettings.TargetAzureV1ResourceGroupId =
                    this.RecoveryResourceGroupId;
                providerSettings.TargetAzureV2ResourceGroupId = null;
            }
            else
            {
                providerSettings.TargetAzureV1ResourceGroupId = null;
                providerSettings.TargetAzureV2ResourceGroupId =
                    this.RecoveryResourceGroupId;
            }

            input.Properties.ProviderSpecificDetails = providerSettings;
        }

        /// <summary>
        ///     Helper method for Azure to Azure replication scenario.
        /// </summary>
        private void AzureToAzureReplication(EnableProtectionInput input)
        {
            var providerSettings = new A2AEnableProtectionInput()
            {
                FabricObjectId = this.AzureVmId,
                RecoveryContainerId =
                        this.ProtectionContainerMapping.TargetProtectionContainerId,
                VmDisks = new List<A2AVmDiskInputDetails>(),
                VmManagedDisks = new List<A2AVmManagedDiskInputDetails>(),
                RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                RecoveryCloudServiceId = this.RecoveryCloudServiceId,
                RecoveryAvailabilitySetId = this.RecoveryAvailabilitySetId,
                RecoveryBootDiagStorageAccountId = this.RecoveryBootDiagStorageAccountId,
                RecoveryAzureNetworkId = this.RecoveryAzureNetworkId,
                RecoverySubnetName = this.RecoveryAzureSubnetName,
                RecoveryAvailabilityZone = this.RecoveryAvailabilityZone,
                RecoveryProximityPlacementGroupId = this.RecoveryProximityPlacementGroupId
            };

            if (!string.IsNullOrEmpty(this.ReplicationGroupName))
            {
                providerSettings.MultiVmGroupName = this.ReplicationGroupName;
            }

            if (!string.IsNullOrEmpty(this.RecoveryCloudServiceId))
            {
                providerSettings.RecoveryResourceGroupId = null;
            }

            if (this.AzureToAzureDiskReplicationConfiguration == null)
            {
                if (this.AzureVmId.ToLower().Contains(ARMResourceTypeConstants.Compute.ToLower()))
                {
                    var vmName = Utilities.GetValueFromArmId(this.AzureVmId, ARMResourceTypeConstants.VirtualMachine);
                    var vmRg = Utilities.GetValueFromArmId(this.AzureVmId, ARMResourceTypeConstants.ResourceGroups);
                    var subscriptionId = Utilities.GetValueFromArmId(this.AzureVmId, ARMResourceTypeConstants.Subscriptions);
                    var tempSubscriptionId = this.ComputeManagementClient.GetComputeManagementClient.SubscriptionId;
                    this.ComputeManagementClient.GetComputeManagementClient.SubscriptionId = subscriptionId;
                    var virtualMachine = this.ComputeManagementClient.GetComputeManagementClient.
                        VirtualMachines.GetWithHttpMessagesAsync(vmRg, vmName).GetAwaiter().GetResult().Body;
                    this.ComputeManagementClient.GetComputeManagementClient.SubscriptionId = tempSubscriptionId;

                    if (virtualMachine == null)
                    {
                        throw new Exception("Azure Vm not found");
                    }

                    // if managed disk
                    if (virtualMachine.StorageProfile.OsDisk.ManagedDisk != null)
                    {
                        if (this.RecoveryAzureStorageAccountId != null)
                        {
                            throw new Exception("Recovery Storage account is not required for managed disk vm to protect");
                        }
                        var osDisk = virtualMachine.StorageProfile.OsDisk;
                        providerSettings.VmManagedDisks.Add(new A2AVmManagedDiskInputDetails
                        {
                            DiskId = osDisk.ManagedDisk.Id,
                            RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                            PrimaryStagingAzureStorageAccountId = this.LogStorageAccountId,
                            RecoveryReplicaDiskAccountType = osDisk.ManagedDisk.StorageAccountType,
                            RecoveryTargetDiskAccountType = osDisk.ManagedDisk.StorageAccountType
                        });
                        if (virtualMachine.StorageProfile.DataDisks != null)
                        {
                            foreach (var dataDisk in virtualMachine.StorageProfile.DataDisks)
                            {
                                providerSettings.VmManagedDisks.Add(new A2AVmManagedDiskInputDetails
                                {
                                    DiskId = dataDisk.ManagedDisk.Id,
                                    RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                                    PrimaryStagingAzureStorageAccountId = LogStorageAccountId,
                                    RecoveryReplicaDiskAccountType = dataDisk.ManagedDisk.StorageAccountType,
                                    RecoveryTargetDiskAccountType = dataDisk.ManagedDisk.StorageAccountType
                                });
                            }
                        }
                    }
                    else
                    {
                        if (this.RecoveryAzureStorageAccountId == null)
                        {
                            throw new Exception("Recovery Storage account is required for non-managed disk vm to protect");
                        }

                        var osDisk = virtualMachine.StorageProfile.OsDisk;
                        providerSettings.VmDisks.Add(new A2AVmDiskInputDetails
                        {
                            DiskUri = osDisk.Vhd.Uri,
                            RecoveryAzureStorageAccountId = this.RecoveryAzureStorageAccountId,
                            PrimaryStagingAzureStorageAccountId = LogStorageAccountId
                        });
                        if (virtualMachine.StorageProfile.DataDisks != null)
                        {
                            foreach (var dataDisk in virtualMachine.StorageProfile.DataDisks)
                            {
                                providerSettings.VmDisks.Add(new A2AVmDiskInputDetails
                                {
                                    DiskUri = dataDisk.Vhd.Uri,
                                    RecoveryAzureStorageAccountId = this.RecoveryAzureStorageAccountId,
                                    PrimaryStagingAzureStorageAccountId = LogStorageAccountId
                                });
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Pass Disk details for Classic VMs");
                }
            }
            else
            {
                foreach (ASRAzuretoAzureDiskReplicationConfig disk in this.AzureToAzureDiskReplicationConfiguration)
                {
                    if (disk.IsManagedDisk)
                    {
                        providerSettings.VmManagedDisks.Add(new A2AVmManagedDiskInputDetails
                        {
                            DiskId = disk.DiskId,
                            RecoveryResourceGroupId = disk.RecoveryResourceGroupId,
                            PrimaryStagingAzureStorageAccountId = disk.LogStorageAccountId,
                            RecoveryReplicaDiskAccountType = disk.RecoveryReplicaDiskAccountType,
                            RecoveryTargetDiskAccountType = disk.RecoveryTargetDiskAccountType,
                            RecoveryDiskEncryptionSetId = disk.RecoveryDiskEncryptionSetId,
                            DiskEncryptionInfo =
                                Utilities.A2AEncryptionDetails(
                                    disk.DiskEncryptionSecretUrl,
                                    disk.DiskEncryptionVaultId,
                                    disk.KeyEncryptionKeyUrl,
                                    disk.KeyEncryptionVaultId)
                        });

                    }
                    else
                    {
                        providerSettings.VmDisks.Add(new A2AVmDiskInputDetails
                        {
                            DiskUri = disk.VhdUri,
                            RecoveryAzureStorageAccountId =
                                    disk.RecoveryAzureStorageAccountId,
                            PrimaryStagingAzureStorageAccountId =
                                    disk.LogStorageAccountId,
                        });
                    }
                }
            }

            providerSettings.DiskEncryptionInfo =
               Utilities.A2AEncryptionDetails(
                   this.DiskEncryptionSecretUrl,
                   this.DiskEncryptionVaultId,
                   this.KeyEncryptionKeyUrl,
                   this.KeyEncryptionVaultId);

            input.Properties.ProviderSpecificDetails = providerSettings;
        }

        /// <summary>
        ///     Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(
            Job job)
        {
            this.WriteObject(new ASRJob(job));
        }

        private Job jobResponse;

        /// <summary>
        ///     Job response.
        /// </summary>
        private PSSiteRecoveryLongRunningOperation response;
    }
}
