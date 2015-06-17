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

        [Parameter(Position = 3, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyNewName, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.BackupType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Full")]
        public string BackupType { get; set; }

        [Parameter(ParameterSetName = DailyScheduleParamSet, Position = 7, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleType)]
        public SwitchParameter Daily { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 6, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleType)]
        public SwitchParameter Weekly { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunTimes, ValueFromPipelineByPropertyName = true)]
        public DateTime ScheduleRunTimes { get; set; }

        [Parameter(Position = 8, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.RetentionType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Days", IgnoreCase = true)]
        public string RetentionType { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.RententionDuration, ValueFromPipelineByPropertyName = true)]
        public int RetentionDuration { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 10, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunDays, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", IgnoreCase = true)]
        public string[] ScheduleRunDays { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug("Making client call");
                
                AzureBackupProtectionPolicy policy = ProtectionPolicy;

                FillRemainingValuesForSetPolicyRequest(policy);

                AzureBackupCmdletHelper.ValidateAzureBackupPolicyRequest(policy);

                var backupSchedule = AzureBackupCmdletHelper.FillBackupSchedule(BackupType, policy.ScheduleType, ScheduleRunTimes,
                   RetentionType, RetentionDuration, policy.ScheduleRunDays.ToArray<string>());
                   
             
                var policyListResponse = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                NewName = (string.IsNullOrEmpty(NewName) ? policy.Name: NewName);
                var updateProtectionPolicyRequest = new UpdateProtectionPolicyRequest();
                updateProtectionPolicyRequest.PolicyName = this.NewName;
                updateProtectionPolicyRequest.Schedule = backupSchedule;

                WriteDebug("Got the protectionPolicy List");

                IEnumerable<ProtectionPolicyInfo> policyObjects = null;

                policyObjects = policyListResponse.ProtectionPolicies.Objects.Where(x => x.Name.Equals(policy.Name, System.StringComparison.InvariantCultureIgnoreCase));

                WriteDebug("Got the protectionPolicy with Name" + this.ProtectionPolicy.Name);

                if (policyObjects.Count<ProtectionPolicyInfo>() != 0)
                {
                    var operationId = AzureBackupClient.ProtectionPolicy.UpdateAsync(ProtectionPolicy.InstanceId, updateProtectionPolicyRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                }
                else
                {
                    var exception = new Exception("Protection Policy Not Found with Name" + ProtectionPolicy.Name);
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    WriteError(errorRecord);                   
                }

                WriteDebug("Protection Policy successfully updated");

                var policyListResponse_afterUpdate = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteDebug("Received policy response");

                policyObjects = policyListResponse_afterUpdate.ProtectionPolicies.Where(x => x.Name.Equals(NewName, System.StringComparison.InvariantCultureIgnoreCase));

                WriteDebug("Converting response");
                AzureBackupCmdletHelper.WriteAzureBackupProtectionPolicy(policy.ResourceGroupName, policy.ResourceName, policy.Location, policyObjects);

            });
        }

        private void FillRemainingValuesForSetPolicyRequest(AzureBackupProtectionPolicy policy)
        {
            if(string.IsNullOrEmpty(BackupType))
            {
                BackupType = policy.BackupType;
            }

            if (ScheduleRunTimes == null)
            {
                ScheduleRunTimes = policy.ScheduleRunTimes;
            }

            if (string.IsNullOrEmpty(RetentionType))
            {
                RetentionType = policy.RetentionType;
            }

            if (RetentionDuration == 0)
            {
                RetentionDuration = policy.RetentionDuration;
            }

            if (string.IsNullOrEmpty(BackupType))
            {
                BackupType = policy.BackupType;
            }

            if (this.ParameterSetName != NoScheduleParamSet )
            {
                if (ScheduleRunDays != null && ScheduleRunDays.Length > 0)
                {
                    policy.ScheduleType = ScheduleType.Weekly.ToString();
                    policy.ScheduleRunDays = ScheduleRunDays.ToList<string>();
                }
                else
                {
                    policy.ScheduleType = ScheduleType.Daily.ToString();
                }          
                
            }
        }
    }
}

