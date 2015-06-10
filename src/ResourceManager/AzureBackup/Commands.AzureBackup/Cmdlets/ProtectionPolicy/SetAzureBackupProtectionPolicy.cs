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
    [Cmdlet(VerbsCommon.Set, "AzureBackupProtectionPolicy"), OutputType(typeof(AzureBackupProtectionPolicy))]
    public class SetAzureBackupProtectionPolicy : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyInstanceId, ValueFromPipelineByPropertyName = true)]
        public string InstanceId { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.BackupType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Full")]
        public string BackupType { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Daily", "Weekly")]
        public string ScheduleType { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunDays, ValueFromPipelineByPropertyName = true)]
        [AllowEmptyCollection]
        public IList<string> ScheduleRunDays { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunTimes, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public DateTime ScheduleRunTimes { get; set; }

        [Parameter(Position = 6, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.RetentionType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Days")]
        public string RetentionType { get; set; }

        [Parameter(Position = 7, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.RententionDuration, ValueFromPipelineByPropertyName = true)]
        [ValidateRange(1, 30)]
        public int RetentionDuration { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");

                var backupSchedule = GetBackupSchedule();
               
                var updateProtectionPolicyRequest = new UpdateProtectionPolicyRequest();
                updateProtectionPolicyRequest.PolicyName = this.Name;
                updateProtectionPolicyRequest.Schedule = backupSchedule;
             
                var policyListResponse = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                IEnumerable<ProtectionPolicyInfo> policyObjects = null;

                policyObjects = policyListResponse.ProtectionPolicies.Objects.Where(x => x.InstanceId.Equals(this.InstanceId, System.StringComparison.InvariantCultureIgnoreCase));

                if (policyObjects.Count<ProtectionPolicyInfo>() != 0)
                {
                    var OperationId = AzureBackupClient.ProtectionPolicy.UpdateAsync(this.InstanceId, updateProtectionPolicyRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                }
                else
                {
                    WriteVerbose("Policy Not Found");
                }

                WriteVerbose("Protection Policy successfully updated");

                var policyListResponse_afterUpdate = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteVerbose("Received policy response");

                policyObjects = policyListResponse_afterUpdate.ProtectionPolicies.Where(x => x.Name.Equals(Name, System.StringComparison.InvariantCultureIgnoreCase));

                WriteVerbose("Converting response");
                WriteAzureBackupProtectionPolicy(policyObjects);
            });
        }

        public void WriteAzureBackupProtectionPolicy(IEnumerable<ProtectionPolicyInfo> sourcePolicyList)
        {
            List<AzureBackupProtectionPolicy> targetList = new List<AzureBackupProtectionPolicy>();

            foreach (var sourcePolicy in sourcePolicyList)
            {
                targetList.Add(new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, sourcePolicy));
            }

            this.WriteObject(targetList, true);
        }

        private BackupSchedule GetBackupSchedule()
        {
            WriteVerbose("Entering GetBackupSchedule");

            var backupSchedule = new BackupSchedule();

            backupSchedule.BackupType = this.BackupType;
            backupSchedule.RetentionPolicy = GetRetentionPolicy();
            //Enum.Parse(ScheduleRunType, this.ScheduleType),
            backupSchedule.ScheduleRun = this.ScheduleType;
            if (this.ScheduleType == "Weekly")
            {
                backupSchedule.ScheduleRunDays = GetScheduleRunDays();
            }
            backupSchedule.ScheduleRunTimes = new List<DateTime> { this.ScheduleRunTimes };
            backupSchedule.ScheduleStartTime = this.ScheduleRunTimes;

            WriteVerbose("Exiting GetBackupSchedule");
            return backupSchedule;
        }

        private RetentionPolicy GetRetentionPolicy()
        {
            WriteVerbose("Entering RetentionPolicy");
            var retentionPolicy = new RetentionPolicy
            {
                RetentionType = (RetentionDurationType)Enum.Parse(typeof(RetentionDurationType), this.RetentionType),
                RetentionDuration = this.RetentionDuration
            };

            WriteVerbose("Exiting RetentionPolicy");
            return retentionPolicy;
        }

        private IList<DayOfWeek> GetScheduleRunDays()
        {
            WriteVerbose("Entering GetScheduleRunDays");
            IList<DayOfWeek> ListofWeekDays = new List<DayOfWeek>();

            foreach (var dayOfWeek in this.ScheduleRunDays)
            {
                DayOfWeek item = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek, true);

                if (!ListofWeekDays.Contains(item))
                {
                    ListofWeekDays.Add(item);
                }

                else
                {
                    throw new ArgumentException(string.Format("Repeated Days in ScheduleRunDays"));
                }
            }

            WriteVerbose("Exiting GetScheduleRunDays");
            return ListofWeekDays;
        }

    }
}

