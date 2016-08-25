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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Set Protection Entity protection state.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSiteRecoveryProtectionEntity", DefaultParameterSetName = ASRParameterSets.DisableDR, SupportsShouldProcess = true)]
    [OutputType(typeof(ASRJob))]
    public class SetAzureSiteRecoveryProtectionEntity : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private LongRunningOperationResponse response = null;

        /// <summary>
        /// Holds either Name (if object is passed) or ID (if IDs are passed) of the PE.
        /// </summary>
        private string targetNameOrId = string.Empty;

        /// <summary>
        /// Gets or sets Protection Entity Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.DisableDR, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets Protection to set, either enable or disable.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.DisableDR, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.EnableProtection,
            Constants.DisableProtection)]
        public string Protection { get; set; }

        /// <summary>
        /// Gets or sets Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRPolicy Policy { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account Name of the Policy for E2A and B2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets OS disk name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OSDiskName { get; set; }

        /// <summary>
        /// Gets or sets OS Type
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OSWindows,
            Constants.OSLinux)]
        public string OS { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        JobResponse jobResponse = null;

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            this.targetNameOrId = this.ProtectionEntity.FriendlyName;
            this.ConfirmAction(
                this.Force.IsPresent || 0 != string.CompareOrdinal(this.Protection, Constants.DisableProtection),
                string.Format(Properties.Resources.DisableProtectionWarning, this.targetNameOrId),
                string.Format(Properties.Resources.DisableProtectionWhatIfMessage, this.Protection),
                this.targetNameOrId,
                () =>
                {
                    if (this.Protection == Constants.EnableProtection)
                    {
                        if (string.Compare(this.ParameterSetName, ASRParameterSets.DisableDR, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            throw new PSArgumentException(Properties.Resources.PassingPolicyMandatoryForEnablingDR);
                        }

                        EnableProtectionProviderSpecificInput enableProtectionProviderSpecificInput = new EnableProtectionProviderSpecificInput();

                        EnableProtectionInputProperties inputProperties = new EnableProtectionInputProperties()
                        {
                            PolicyId = this.Policy.ID,
                            ProtectableItemId = this.ProtectionEntity.ID,
                            ProviderSpecificDetails = enableProtectionProviderSpecificInput
                        };

                        EnableProtectionInput input = new EnableProtectionInput()
                        {
                            Properties = inputProperties
                        };

                        // Process if block only if policy is not null, policy is created for E2A or B2A and parameter set is for enable DR of E2A or B2A 
                        if (this.Policy != null &&
                            0 == string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplicaAzure, StringComparison.OrdinalIgnoreCase) &&
                            (0 == string.Compare(this.ParameterSetName, ASRParameterSets.EnterpriseToAzure, StringComparison.OrdinalIgnoreCase) ||
                            0 == string.Compare(this.ParameterSetName, ASRParameterSets.HyperVSiteToAzure, StringComparison.OrdinalIgnoreCase)))
                        {
                            HyperVReplicaAzureEnableProtectionInput providerSettings = new HyperVReplicaAzureEnableProtectionInput();
                            providerSettings.HvHostVmId = this.ProtectionEntity.FabricObjectId;
                            providerSettings.VmName = this.ProtectionEntity.FriendlyName;

                            // Id disk details are missing in input PE object, get the latest PE.
                            if (string.IsNullOrEmpty(this.ProtectionEntity.OS))
                            {
                                // Just checked for OS to see whether the disk details got filled up or not
                                ProtectableItemResponse protectableItemResponse =
                                    RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                                    Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics),
                                    this.ProtectionEntity.ProtectionContainerId,
                                    this.ProtectionEntity.Name);

                                this.ProtectionEntity = new ASRProtectionEntity(protectableItemResponse.ProtectableItem);
                            }

                            if (string.IsNullOrWhiteSpace(this.OS))
                            {
                                providerSettings.OSType = ((string.Compare(this.ProtectionEntity.OS, Constants.OSWindows) == 0) || (string.Compare(this.ProtectionEntity.OS, Constants.OSLinux) == 0)) ? this.ProtectionEntity.OS : Constants.OSWindows;
                            }
                            else
                            {
                                providerSettings.OSType = this.OS;
                            }

                            if (string.IsNullOrWhiteSpace(this.OSDiskName))
                            {
                                providerSettings.VhdId = this.ProtectionEntity.OSDiskId;
                            }
                            else
                            {
                                foreach (var disk in this.ProtectionEntity.Disks)
                                {
                                    if (0 == string.Compare(disk.Name, this.OSDiskName, true))
                                    {
                                        providerSettings.VhdId = disk.Id;
                                        break;
                                    }
                                }
                            }

                            if (RecoveryAzureStorageAccountId != null)
                            {
                                providerSettings.TargetStorageAccountId = RecoveryAzureStorageAccountId;
                            }

                            input.Properties.ProviderSpecificDetails = providerSettings;
                        }
                        else if (this.Policy != null &&
                            0 == string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplicaAzure, StringComparison.OrdinalIgnoreCase) &&
                            0 == string.Compare(this.ParameterSetName, ASRParameterSets.EnterpriseToEnterprise, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new PSArgumentException(Properties.Resources.PassingStorageMandatoryForEnablingDRInAzureScenarios);
                        }

                        this.response =
                            RecoveryServicesClient.EnableProtection(
                            Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics),
                            Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                            this.ProtectionEntity.Name,
                            input);
                    }
                    else
                    {
                        // fetch the latest PE object
                        ProtectableItemResponse protectableItemResponse =
                                                    RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics),
                                                    this.ProtectionEntity.ProtectionContainerId, this.ProtectionEntity.Name);
                        ProtectableItem protectableItem = protectableItemResponse.ProtectableItem;

                        if (!this.Force.IsPresent)
                        {
                            DisableProtectionInput input = new DisableProtectionInput();
                            input.Properties = new DisableProtectionInputProperties()
                            {
                                ProviderSettings = new DisableProtectionProviderSpecificInput()
                            };

                            this.response =
                                RecoveryServicesClient.DisableProtection(
                                Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics),
                                Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                                Utilities.GetValueFromArmId(protectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems),
                                input);
                        }
                        else
                        {
                            this.response =
                                RecoveryServicesClient.PurgeProtection(
                                Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics),
                                Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                                Utilities.GetValueFromArmId(protectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems)
                                );
                        }
                    }

                    jobResponse =
                        RecoveryServicesClient
                        .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                    WriteObject(new ASRJob(jobResponse.Job));

                    if (this.WaitForCompletion.IsPresent)
                    {
                        this.WaitForJobCompletion(this.jobResponse.Job.Name);

                        jobResponse =
                        RecoveryServicesClient
                        .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                        WriteObject(new ASRJob(jobResponse.Job));
                    }
                });
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.Azure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}