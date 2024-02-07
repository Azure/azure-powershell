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
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Creates a new protection policy based on the parameters provided in to the recovery services vault.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtectionPolicy", SupportsShouldProcess = true), OutputType(typeof(PolicyBase))]
    public class NewAzureRmRecoveryServicesBackupProtectionPolicy : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// List of supported BackupManagementTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validBackupManagementTypes = "AzureVM, AzureWorkload, AzureStorage";

        /// <summary>
        /// List of supported WorkloadTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validWorkloadTypes = "AzureVM, AzureFiles, MSSQL";

        /// <summary>
        /// Name of the policy to be created
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Workload type that is managed by this policy
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// Backup management type of the policy to be created
        /// </summary>
        [Parameter(Position = 3, Mandatory = false, HelpMessage = ParamHelpMsgs.Common.BackupManagementType + validBackupManagementTypes,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType? BackupManagementType { get; set; }

        /// <summary>
        /// Retention policy object associated with the policy to be created
        /// </summary>
        [Parameter(Position = 4, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.RetentionPolicy,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public RetentionPolicyBase RetentionPolicy { get; set; }

        /// <summary>
        /// Schedule policy object assoicated with the policy to be created
        /// </summary>
        [Parameter(Position = 5, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.SchedulePolicy,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchedulePolicyBase SchedulePolicy { get; set; }

        /// <summary>
        /// Boolean value that specifies whether recovery points should be moved to archive storage by the policy or not. Allowed values are $true, $false. 
        /// If no value is specified, then there is no change in behaviour for the existing protection policy.
        /// </summary>
        [Parameter(Position = 6, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.MoveToArchiveTier)]
        public bool? MoveToArchiveTier { get; set; }

        /// <summary>
        /// Tiering mode to specify whether to move recommended or all eligible recovery points.
        /// </summary>
        [Parameter(Position = 7, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.TieringMode)]
        [ValidateSet("TierRecommended", "TierAllEligible")]
        public TieringMode TieringMode { get; set; }

        /// <summary>
        /// Specifies after how many days/months recovery points should start moving to the archive tier. Applicable only for TieringMode: TierAllEligible
        /// </summary>
        [Parameter(Position = 8, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.TierAfterDuration)]
        public int? TierAfterDuration { get; set; }

        /// <summary>
        /// Specifies whether the TierAfterDuration is in Days or Months.
        /// </summary>
        [Parameter(Position = 9, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.TierAfterDurationType)]
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

                WriteDebug(string.Format("Input params - Name:{0}, WorkloadType:{1}, " +
                           "BackupManagementType: {2}, " +
                           "RetentionPolicy:{3}, SchedulePolicy:{4}",
                           Name, WorkloadType.ToString(),
                           BackupManagementType.HasValue ? BackupManagementType.ToString() : "NULL",
                           RetentionPolicy == null ? "NULL" : RetentionPolicy.ToString(),
                           SchedulePolicy == null ? "NULL" : SchedulePolicy.ToString()));

                // validate policy name
                PolicyCmdletHelpers.ValidateProtectionPolicyName(Name);
                
                // Validate if policy already exists               
                if (PolicyCmdletHelpers.GetProtectionPolicyByName(
                    Name,
                    ServiceClientAdapter,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName) != null)
                {
                    throw new ArgumentException(string.Format(Resources.PolicyAlreadyExistException, Name));
                }

                if (SnapshotConsistencyType != 0 && WorkloadType != Models.WorkloadType.AzureVM)
                {                    
                    throw new ArgumentException(string.Format(Resources.InvalidParameterSnapshotConsistencyType));
                }

                // check if smart tiering feature is enabled on this subscription                
                bool isSmartTieringEnabled = true;                

                TieringPolicy tieringDetails = null;
                if (MoveToArchiveTier != null)
                {
                    if (WorkloadType != Models.WorkloadType.AzureVM && WorkloadType != Models.WorkloadType.MSSQL && WorkloadType != Models.WorkloadType.SAPHanaDatabase)
                    {
                        throw new ArgumentException(Resources.SmartTieringNotSupported);
                    }

                    tieringDetails = new TieringPolicy();
                    if (MoveToArchiveTier == false)
                    {
                        if(TieringMode != 0 || TierAfterDuration != null || TierAfterDurationType != null)
                        {
                            throw new ArgumentException(Resources.InvalidParametersForTiering);
                        }

                        tieringDetails.TieringMode = TieringMode.DoNotTier;
                    }
                    else
                    {
                        if ((WorkloadType == Models.WorkloadType.MSSQL || WorkloadType == Models.WorkloadType.SAPHanaDatabase) && TieringMode == TieringMode.TierRecommended)
                        {
                            throw new ArgumentException(Resources.TierRecommendedNotSupportedForAzureWorkload);
                        }

                        tieringDetails.TargetTier = RecoveryPointTier.VaultArchive;
                        tieringDetails.TieringMode = TieringMode;
                        tieringDetails.TierAfterDuration = TierAfterDuration;
                        tieringDetails.TierAfterDurationType = TierAfterDurationType;

                        tieringDetails.Validate();
                    }
                }

                Dictionary<Enum, object> providerParameters = new Dictionary<Enum, object>();
                providerParameters.Add(VaultParams.VaultName, vaultName);
                providerParameters.Add(VaultParams.ResourceGroupName, resourceGroupName);
                providerParameters.Add(PolicyParams.PolicyName, Name);
                providerParameters.Add(PolicyParams.WorkloadType, WorkloadType);
                providerParameters.Add(PolicyParams.RetentionPolicy, RetentionPolicy);
                providerParameters.Add(PolicyParams.SchedulePolicy, SchedulePolicy);
                providerParameters.Add(PolicyParams.TieringPolicy, tieringDetails);
                providerParameters.Add(PolicyParams.IsSmartTieringEnabled, isSmartTieringEnabled);
                providerParameters.Add(PolicyParams.BackupSnapshotResourceGroup, BackupSnapshotResourceGroup);
                providerParameters.Add(PolicyParams.BackupSnapshotResourceGroupSuffix, BackupSnapshotResourceGroupSuffix);
                providerParameters.Add(PolicyParams.SnapshotConsistencyType, SnapshotConsistencyType);

                PsBackupProviderManager providerManager = new PsBackupProviderManager(providerParameters, ServiceClientAdapter);                

                IPsBackupProvider psBackupProvider =
                    providerManager.GetProviderInstance(WorkloadType, BackupManagementType);
                
                psBackupProvider.CreatePolicy();
                
                WriteDebug("Successfully created policy, now fetching it from service: " + Name);
                
                // now get the created policy and return
                ServiceClientModel.ProtectionPolicyResource policy = PolicyCmdletHelpers.GetProtectionPolicyByName(
                    Name,
                    ServiceClientAdapter,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);

                // now convert service Policy to PSObject
                WriteObject(ConversionHelpers.GetPolicyModel(policy));

            }, ShouldProcess(Name, VerbsCommon.New));
        }
    }
}
