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
using System.Xml;
using System.Linq;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Commands.AzureBackup.Models;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Update existing protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureBackupProtectionPolicy", DefaultParameterSetName = NoScheduleParamSet), OutputType(typeof(AzureBackupProtectionPolicy))]
    public class SetAzureBackupProtectionPolicy : AzureBackupPolicyCmdletBase
    {
        protected const string WeeklyScheduleParamSet = "WeeklyScheduleParamSet";
        protected const string DailyScheduleParamSet = "DailyScheduleParamSet";
        protected const string NoScheduleParamSet = "NoScheduleParamSet";

        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyNewName)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        [Parameter(ParameterSetName = DailyScheduleParamSet, Position = 2, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.DailyScheduleType)]
        public SwitchParameter Daily { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 3, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WeeklyScheduleType)]
        public SwitchParameter Weekly { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunTimes)]
        public DateTime BackupTime { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.RetentionPolicyList)]
        public AzureBackupRetentionPolicy[] RetentionPolicies { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 6, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunDays)]
        [ValidateSet("Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", IgnoreCase = true)]
        public string[] DaysOfWeek { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                WriteDebug("Making client call");

                var response = AzureBackupClient.GetProtectionPolicyByName(ProtectionPolicy.Name);
                var vault = new CmdletModel.AzurePSBackupVault(ProtectionPolicy.ResourceGroupName, ProtectionPolicy.Name, ProtectionPolicy.Location);

                var policyInfo = ProtectionPolicyHelpers.GetCmdletPolicy(vault, response);

                if (policyInfo == null)
                {
                    throw new ArgumentException(String.Format("Protection policy {0} not found", ProtectionPolicy.Name));
                }

                // TODO: Make the below function work with AzureBackupProtectionPolicy
                FillRemainingValuesForSetPolicyRequest(policyInfo, this.NewName);

                var backupSchedule = ProtectionPolicyHelpers.FillCSMBackupSchedule(policyInfo.ScheduleType, BackupTime,
                    policyInfo.DaysOfWeek.ToArray<string>());

                NewName = (string.IsNullOrEmpty(NewName) ? policyInfo.Name : NewName);
                var updateProtectionPolicyRequest = new CSMUpdateProtectionPolicyRequest();
                updateProtectionPolicyRequest.Properties = new CSMUpdateProtectionPolicyRequestProperties();
                updateProtectionPolicyRequest.Properties.PolicyName = this.NewName;
                updateProtectionPolicyRequest.Properties.BackupSchedule = backupSchedule;

                AzureBackupProtectionPolicy protectionPolicy = new AzureBackupProtectionPolicy();
                if (RetentionPolicies != null && RetentionPolicies.Length > 0)
                {
                    updateProtectionPolicyRequest.Properties.LtrRetentionPolicy =
                        ProtectionPolicyHelpers.ConvertToCSMRetentionPolicyObject(RetentionPolicies, backupSchedule);
                    ProtectionPolicyHelpers.ValidateRetentionPolicy(RetentionPolicies, backupSchedule);
                }
                else
                {
                    updateProtectionPolicyRequest.Properties.LtrRetentionPolicy =
                        ProtectionPolicyHelpers.ConvertToCSMRetentionPolicyObject(policyInfo.RetentionPolicyList, backupSchedule);
                    ProtectionPolicyHelpers.ValidateRetentionPolicy(policyInfo.RetentionPolicyList, backupSchedule);
                }

                var operationId = AzureBackupClient.UpdateProtectionPolicy(policyInfo.Name, updateProtectionPolicyRequest);

                if (operationId != Guid.Empty)
                {
                    var operationStatus = GetOperationStatus(operationId);
                    WriteDebug("Protection Policy successfully updated and created job(s) to re-configure protection on associated items");
                    WriteObject(operationStatus.JobList);
                }

                else
                {
                    WriteDebug("Protection Policy successfully updated");
                }
                
            });
        }

        private void FillRemainingValuesForSetPolicyRequest(AzureBackupProtectionPolicy policy, string newName)
        {
            if (newName != null && NewName != policy.Name)
            {
                ProtectionPolicyHelpers.ValidateProtectionPolicyName(this.NewName);
                AzureBackupClient.CheckProtectionPolicyNameAvailability(this.NewName);
            }

            BackupTime = (BackupTime == DateTime.MinValue) ? policy.BackupTime :
                                BackupTime;

            WriteDebug("ParameterSetName = " + this.ParameterSetName.ToString());

            if (this.ParameterSetName != NoScheduleParamSet )
            {
                if (DaysOfWeek != null && DaysOfWeek.Length > 0 && 
                    this.ParameterSetName == WeeklyScheduleParamSet)
                {
                    policy.ScheduleType = ScheduleType.Weekly.ToString();
                    policy.DaysOfWeek = DaysOfWeek.ToList<string>();
                }
                else if (this.ParameterSetName == DailyScheduleParamSet &&
                    (DaysOfWeek == null || DaysOfWeek.Length <= 0))
                {
                    policy.ScheduleType = ScheduleType.Daily.ToString();
                    policy.DaysOfWeek = new List<string>();
                }
                else
                {
                    policy.ScheduleType = ProtectionPolicyHelpers.GetScheduleType(DaysOfWeek, this.ParameterSetName,
                    DailyScheduleParamSet, WeeklyScheduleParamSet);

                }                
            }
            else if (DaysOfWeek != null && DaysOfWeek.Length > 0)
            {
                throw new ArgumentException("For Schedule Run Days, weekly switch param is required");
            }
        }
    }
}

