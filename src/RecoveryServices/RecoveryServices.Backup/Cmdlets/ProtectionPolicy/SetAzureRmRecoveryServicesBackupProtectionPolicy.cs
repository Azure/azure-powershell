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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{          
    /// <summary>
    /// Update existing protection policy in the recovery services vault
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtectionPolicy",SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class SetAzureRmRecoveryServicesBackupProtectionPolicy : RSBackupVaultCmdletBase
    {
        public const string ModifyPolicyParamSet = "ModifyPolicyParamSet";
        public const string FixInconsistentPolicyParamSet = "FixPolicyParamSet";

        /// <summary>
        /// Policy object to be modified
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PolicyBase Policy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = false, HelpMessage = ParamHelpMsgs.ResourceGuard.AuxiliaryAccessToken, ParameterSetName = ModifyPolicyParamSet)]
        [ValidateNotNullOrEmpty]
        public string Token;

        /// <summary>
        /// Retention policy object to be modified
        /// </summary>
        [Parameter(Position = 2, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.RetentionPolicy,
            ParameterSetName = ModifyPolicyParamSet)]
        [ValidateNotNullOrEmpty]
        public RetentionPolicyBase RetentionPolicy { get; set; }

        /// <summary>
        /// Schedule policy object to be modified
        /// </summary>
        [Parameter(Position = 3, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.SchedulePolicy,
            ParameterSetName = ModifyPolicyParamSet)]
        [ValidateNotNullOrEmpty]
        public SchedulePolicyBase SchedulePolicy { get; set; }

        /// <summary>
        /// Retry Policy Update for Failed Items
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.FixForInConsistentItems,
            ParameterSetName = FixInconsistentPolicyParamSet)]
        public SwitchParameter FixForInconsistentItems { get; set; }

        /// <summary>
        /// Boolean value that specifies whether recovery points should be moved to archive storage by the policy or not. Allowed values are $true, $false. 
        /// If no value is specified, then there is no change in behaviour for the existing protection policy.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.MoveToArchiveTier, ParameterSetName = ModifyPolicyParamSet)]        
        public bool? MoveToArchiveTier { get; set; }

        /// <summary>
        /// Tiering mode to specify whether to move recommended or all eligible recovery points.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.TieringMode, ParameterSetName = ModifyPolicyParamSet)]
        [ValidateSet("TierRecommended", "TierAllEligible")]
        public TieringMode TieringMode { get; set; }

        /// <summary>
        /// Specifies after how many days/months recovery points should start moving to the archive tier. Applicable only for TieringMode: TierAllEligible
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.TierAfterDuration, ParameterSetName = ModifyPolicyParamSet)]
        public int? TierAfterDuration { get; set; }

        /// <summary>
        /// Specifies whether the TierAfterDuration is in Days or Months.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.TierAfterDurationType, ParameterSetName = ModifyPolicyParamSet)]
        [ValidateSet("Days", "Months")]
        public string TierAfterDurationType { get; set; }

        /// <summary>
        /// Custom resource group name to store the instant recovery points of managed virtual machines.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.AzureBackupResourceGroup)]        
        public string BackupSnapshotResourceGroup { get; set; }

        /// <summary>
        /// Custom resource group name suffix to store the instant recovery points of managed virtual machines.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.AzureBackupResourceGroupSuffix)]        
        public string BackupSnapshotResourceGroupSuffix { get; set; }

        /// <summary>
        /// Snapshot consistency type to be used for backup. If set to OnlyCrashConsistent, all associated items will have crash consistent snapshot. Possible values are OnlyCrashConsistent, Default.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.SnapshotConsistencyType)]
        public SnapshotConsistencyType SnapshotConsistencyType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                bool isMUAOperation = false;
                if (ParameterSetName == ModifyPolicyParamSet)
                {
                    isMUAOperation = true;
                }

                WriteDebug(string.Format("Input params - Policy: {0}" +
                          "RetentionPolicy:{1}, SchedulePolicy:{2}",
                          Policy == null ? "NULL" : Policy.ToString(),
                          RetentionPolicy == null ? "NULL" : RetentionPolicy.ToString(),
                          SchedulePolicy == null ? "NULL" : SchedulePolicy.ToString()));

                // Validate policy name
                PolicyCmdletHelpers.ValidateProtectionPolicyName(Policy.Name);

                // Validate if policy already exists               
                ServiceClientModel.ProtectionPolicyResource servicePolicy = PolicyCmdletHelpers.GetProtectionPolicyByName(
                    Policy.Name,
                    ServiceClientAdapter,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);

                if (servicePolicy == null)
                {
                    throw new ArgumentException(string.Format(Resources.PolicyNotFoundException,
                        Policy.Name));
                }

                if (SnapshotConsistencyType != 0 &&  Policy.BackupManagementType != BackupManagementType.AzureVM)
                {
                    throw new ArgumentException(string.Format(Resources.InvalidParameterSnapshotConsistencyType));
                }

                // check if smart tiering feature is enabled on this subscription                
                bool isSmartTieringEnabled = true;                

                TieringPolicy tieringDetails = null;                
                if (MoveToArchiveTier != null)
                {
                    if (Policy != null && Policy.BackupManagementType != BackupManagementType.AzureVM && Policy.BackupManagementType != BackupManagementType.AzureWorkload)
                    {
                        throw new ArgumentException(Resources.SmartTieringNotSupported);
                    }
                    tieringDetails = new TieringPolicy();
                    if(MoveToArchiveTier == false)
                    {
                        if (TieringMode != 0 || TierAfterDuration != null || TierAfterDurationType != null)
                        {
                            throw new ArgumentException(Resources.InvalidParametersForTiering);
                        }

                        tieringDetails.TieringMode = TieringMode.DoNotTier;
                    }
                    else
                    {
                        if (Policy != null && Policy.BackupManagementType == BackupManagementType.AzureWorkload && TieringMode == TieringMode.TierRecommended)
                        {
                            throw new ArgumentException(Resources.TierRecommendedNotSupportedForAzureWorkload) ;
                        }

                        tieringDetails.TargetTier = RecoveryPointTier.VaultArchive;
                        tieringDetails.TieringMode = TieringMode;
                        tieringDetails.TierAfterDuration = TierAfterDuration;
                        tieringDetails.TierAfterDurationType = TierAfterDurationType;

                        tieringDetails.Validate();
                    }
                }

                PsBackupProviderManager providerManager = new PsBackupProviderManager(
                    new Dictionary<System.Enum, object>()
                    {
                        { VaultParams.VaultName, vaultName },
                        { VaultParams.ResourceGroupName, resourceGroupName },
                        { PolicyParams.ProtectionPolicy, Policy },
                        { PolicyParams.RetentionPolicy, RetentionPolicy },
                        { PolicyParams.SchedulePolicy, SchedulePolicy },
                        { PolicyParams.FixForInconsistentItems, FixForInconsistentItems.IsPresent },
                        { ResourceGuardParams.Token, Token },
                        { ResourceGuardParams.IsMUAOperation, isMUAOperation },
                        { PolicyParams.ExistingPolicy, servicePolicy},
                        { PolicyParams.TieringPolicy, tieringDetails},
                        { PolicyParams.IsSmartTieringEnabled, isSmartTieringEnabled},
                        { PolicyParams.BackupSnapshotResourceGroup, BackupSnapshotResourceGroup},
                        { PolicyParams.BackupSnapshotResourceGroupSuffix, BackupSnapshotResourceGroupSuffix},
                        { PolicyParams.SnapshotConsistencyType, SnapshotConsistencyType}
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(
                    Policy.WorkloadType, Policy.BackupManagementType);

                AzureOperationResponse<ServiceClientModel.ProtectionPolicyResource> policyResponse = psBackupProvider.ModifyPolicy();

                WriteDebug("ModifyPolicy http response from service: " + policyResponse.Response.StatusCode.ToString());

                if (policyResponse.Response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    // Track OperationStatus URL for operation completion
                    string policyName = Policy.Name;

                    ServiceClientModel.OperationStatus operationStatus =
                        TrackingHelpers.GetOperationStatus(
                            policyResponse,
                            operationId =>
                                ServiceClientAdapter.GetProtectionPolicyOperationStatus(
                                    policyName,
                                    operationId,
                                    vaultName: vaultName,
                                    resourceGroupName: resourceGroupName));

                    WriteDebug("Final operation status: " + operationStatus.Status);

                    if (operationStatus.Properties != null &&
                       ((ServiceClientModel.OperationStatusJobsExtendedInfo)operationStatus.Properties)
                            .JobIds != null)
                    {
                        // get list of jobIds and return jobResponses                    
                        WriteObject(GetJobObject(
                            ((ServiceClientModel.OperationStatusJobsExtendedInfo)operationStatus.Properties).JobIds,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName));
                    }

                    if (operationStatus.Status == ServiceClientModel.OperationStatusValues.Failed)
                    {
                        // if operation failed, then trace error and throw exception
                        if (operationStatus.Error != null)
                        {
                            WriteDebug(string.Format(
                                         "OperationStatus Error: {0} " +
                                         "OperationStatus Code: {1}",
                                         operationStatus.Error.Message,
                                         operationStatus.Error.Code));
                        }
                    }
                }
                else
                {
                    // ServiceClient will return OK if NO datasources are associated with this policy
                    WriteDebug("No datasources are associated with Policy, http response code: " +
                                policyResponse.Response.StatusCode.ToString());
                }
            }, ShouldProcess(Policy.Name, VerbsCommon.Set));
        }
    }
}
