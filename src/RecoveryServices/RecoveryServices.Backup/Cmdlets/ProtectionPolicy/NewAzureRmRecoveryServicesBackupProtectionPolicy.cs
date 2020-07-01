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

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<Enum, object>()
                    {
                        { VaultParams.VaultName, vaultName },
                        { VaultParams.ResourceGroupName, resourceGroupName },
                        { PolicyParams.PolicyName, Name },
                        { PolicyParams.WorkloadType, WorkloadType },
                        { PolicyParams.RetentionPolicy, RetentionPolicy },
                        { PolicyParams.SchedulePolicy, SchedulePolicy },
                    }, ServiceClientAdapter);

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
