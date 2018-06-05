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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Update existing protection policy in the recovery services vault
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmRecoveryServicesBackupProtectionPolicy",
        SupportsShouldProcess = true), OutputType(typeof(List<JobBase>))]
    public class SetAzureRmRecoveryServicesBackupProtectionPolicy : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// Policy object to be modified
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PolicyBase Policy { get; set; }

        /// <summary>
        /// Retention policy object to be modified
        /// </summary>
        [Parameter(Position = 2, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.RetentionPolicy)]
        [ValidateNotNullOrEmpty]
        public RetentionPolicyBase RetentionPolicy { get; set; }

        /// <summary>
        /// Schedule policy object to be modified
        /// </summary>
        [Parameter(Position = 3, Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.SchedulePolicy)]
        [ValidateNotNullOrEmpty]
        public SchedulePolicyBase SchedulePolicy { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                WriteDebug(string.Format("Input params - Policy: {0}" +
                          "RetentionPolicy:{1}, SchedulePolicy:{2}",
                          Policy == null ? "NULL" : Policy.ToString(),
                          RetentionPolicy == null ? "NULL" : RetentionPolicy.ToString(),
                          SchedulePolicy == null ? "NULL" : SchedulePolicy.ToString()));

                // Validate policy name
                PolicyCmdletHelpers.ValidateProtectionPolicyName(Policy.Name);

                // Validate if policy already exists               
                ProtectionPolicyResource servicePolicy = PolicyCmdletHelpers.GetProtectionPolicyByName(
                                                                              Policy.Name, ServiceClientAdapter);
                if (servicePolicy == null)
                {
                    throw new ArgumentException(string.Format(Resources.PolicyNotFoundException,
                        Policy.Name));
                }

                PsBackupProviderManager providerManager = new PsBackupProviderManager(
                    new Dictionary<System.Enum, object>()
                {
                    {PolicyParams.ProtectionPolicy, Policy},
                    {PolicyParams.RetentionPolicy, RetentionPolicy},
                    {PolicyParams.SchedulePolicy, SchedulePolicy},
                }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(
                    Policy.WorkloadType, Policy.BackupManagementType);
                AzureOperationResponse<ProtectionPolicyResource> policyResponse =
                    psBackupProvider.ModifyPolicy();
                WriteDebug("ModifyPolicy http response from service: " +
                    policyResponse.Response.StatusCode.ToString());

                if (policyResponse.Response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    // Track OperationStatus URL for operation completion

                    string policyName = Policy.Name;

                    ServiceClientModel.OperationStatus operationStatus =
                        TrackingHelpers.GetOperationStatus(
                            policyResponse,
                            operationId =>
                                ServiceClientAdapter.GetProtectionPolicyOperationStatus(
                                    policyName, operationId));

                    WriteDebug("Final operation status: " + operationStatus.Status);

                    if (operationStatus.Properties != null &&
                       ((OperationStatusJobsExtendedInfo)operationStatus.Properties)
                            .JobIds != null)
                    {
                        // get list of jobIds and return jobResponses                    
                        WriteObject(GetJobObject(
                            ((OperationStatusJobsExtendedInfo)operationStatus.Properties).JobIds));
                    }

                    if (operationStatus.Status == OperationStatusValues.Failed)
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
