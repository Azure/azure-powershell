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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Job = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models.Job;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Set Protection Entity protection state.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrReplicationProtectedItem",
        DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
        SupportsShouldProcess = true)]
    [Alias("New-ASRReplicationProtectedItem")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrReplicationProtectedItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///    Switch Paramter to create VMwareToAzure / InMageAzureV2 policy.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true)]
        public SwitchParameter VMwareToAzure { get; set; }
        
        /// <summary>
        ///    Switch Paramter to create HyperVSiteToAzure policy.
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
        ///    Switch Paramter to create HyperVSiteToHyperVSite policy.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = false)]
        public SwitchParameter VmmToVmm { get; set; }

        /// <summary>
        ///     Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectableItem ProtectableItem { get; set; }

        /// <summary>
        ///     Gets or sets Replication Protected Item Name.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Replication Protected Item Name.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVSiteToAzure,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string RecoveryVmName { get; set; }

        /// <summary>
        ///     Gets or sets Policy.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure Storage Account Name of the Policy for E2A and B2A scenarios.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVSiteToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets OS disk name.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVSiteToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OSDiskName { get; set; }

        /// <summary>
        ///     Gets or sets OS Type
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVSiteToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OSWindows,
            Constants.OSLinux)]
        public string OS { get; set; }

        /// <summary>
        /// Gets or sets RunAsAccount.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRunAsAccount Account { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Log Storage Account Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets Disks to Include.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [ValidateNotNullOrEmpty]
        public string[] IncludeDiskId { get; set; }

        /// <summary>
        /// Gets or sets Process Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProcessServer ProcessServer { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Subnet Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureSubnetName { get; set; }

        /// <summary>
        /// Gets or sets Recovery Resource Group Id.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVSiteToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets Replication Group Name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [ValidateNotNullOrEmpty]
        public string ReplicationGroupName { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

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
                    ProtectableItemId = this.ProtectableItem.ID,
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

                    case ASRParameterSets.VMwareToAzure:
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

                    default:
                        break;
                }

                this.response = this.RecoveryServicesClient.EnableProtection(
                    Utilities.GetValueFromArmId(
                        this.ProtectableItem.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ProtectableItem.ID,
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
                    MultiVmGroupId = this.ReplicationGroupName,
                    TargetAzureVmName = string.IsNullOrEmpty(this.RecoveryVmName)
                                            ? this.ProtectableItem.FriendlyName
                                            : this.RecoveryVmName,
                    EnableRDPOnTargetOption = Constants.NeverEnableRDPOnTargetOption,
                    DisksToInclude = this.IncludeDiskId != null
                                            ? this.IncludeDiskId
                                            : null
                };

            var deploymentType = Utilities.GetValueFromArmId(
                this.RecoveryAzureStorageAccountId,
                ARMResourceTypeConstants.Providers);
            if (deploymentType.ToLower().Contains(Constants.Classic.ToLower()))
            {
                providerSettings.TargetAzureV1ResourceGroupId =
                    this.RecoveryResourceGroupId;
            }
            else
            {
                providerSettings.TargetAzureV2ResourceGroupId =
                    this.RecoveryResourceGroupId;
            }

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

        private void EnterpriseAndHyperVToAzure(EnableProtectionInput input)
        {
            var providerSettings = new HyperVReplicaAzureEnableProtectionInput();

            providerSettings.HvHostVmId = this.ProtectableItem.FabricObjectId;
            providerSettings.VmName = this.ProtectableItem.FriendlyName;
            providerSettings.TargetAzureVmName = string.IsNullOrEmpty(this.RecoveryVmName)
                                                    ? this.ProtectableItem.FriendlyName
                                                    : this.RecoveryVmName;

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
