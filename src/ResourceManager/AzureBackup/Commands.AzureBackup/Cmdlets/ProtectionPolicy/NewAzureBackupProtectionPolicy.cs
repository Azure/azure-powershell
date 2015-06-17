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
    /// Create new protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureBackupProtectionPolicy", DefaultParameterSetName = DailyScheduleParamSet), OutputType(typeof(AzureBackupProtectionPolicy))]
    public class NewAzureBackupProtectionPolicy : AzureBackupVaultCmdletBase
    {
        protected const string WeeklyScheduleParamSet = "WeeklyScheduleParamSet";
        protected const string DailyScheduleParamSet = "DailyScheduleParamSet";

        [Parameter(Position = 3, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 4, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WorkloadType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("VM")]
        public string WorkloadType { get; set; }

        [Parameter(Position = 5, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.BackupType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Full")]
        public string BackupType { get; set; }

        [Parameter(ParameterSetName = DailyScheduleParamSet, Position = 7, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleType)]
        public SwitchParameter Daily { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 6, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleType)]
        public SwitchParameter Weekly { get; set; }

        [Parameter(Position = 7, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunTimes, ValueFromPipelineByPropertyName = true)]
        public DateTime ScheduleRunTimes { get; set; }

        [Parameter(Position = 8, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.RetentionType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Days", IgnoreCase = true)]
        public string RetentionType { get; set; }

        [Parameter(Position = 9, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.RententionDuration, ValueFromPipelineByPropertyName = true)]
        public int RetentionDuration { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 10, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunDays, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", IgnoreCase = true)]
        public string[] ScheduleRunDays { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug("Making client call");

                var ScheduleType = GetScheduelType(ScheduleRunDays);

                var backupSchedule = ProtectionPolicyHelper.GetBackupSchedule(this,BackupType, ScheduleType, ScheduleRunTimes,
                   RetentionType, RetentionDuration, ScheduleRunDays);
                

                //var backupSchedule = GetBackupSchedule(BackupType, ScheduleType, ScheduleRunTimes, 
                //    RetentionType, RetentionDuration, ScheduleRunDays);
                
                var addProtectionPolicyRequest = new AddProtectionPolicyRequest();
                addProtectionPolicyRequest.PolicyName = this.Name;
                addProtectionPolicyRequest.Schedule = backupSchedule;
                addProtectionPolicyRequest.WorkloadType = this.WorkloadType;

                var operationId = AzureBackupClient.ProtectionPolicy.AddAsync(addProtectionPolicyRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteDebug("Protection policy created successfully");
               
                var policyListResponse = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteDebug("Received policy response");

                IEnumerable<ProtectionPolicyInfo> policyObjects = null;
                policyObjects = policyListResponse.ProtectionPolicies.Where(x => x.Name.Equals(Name, System.StringComparison.InvariantCultureIgnoreCase));

                WriteDebug("Converting response");
                ProtectionPolicyHelper.WriteAzureBackupProtectionPolicy(this, ResourceGroupName, ResourceName, Location, policyObjects);
            });
        }

        private string GetScheduelType(string[] ScheduleRunDays)
        {
            WriteDebug("ParameterSetName = " + this.ParameterSetName.ToString());
            if (this.ParameterSetName == WeeklyScheduleParamSet || (ScheduleRunDays != null && ScheduleRunDays.Length > 0))
            {
                return ScheduleType.Weekly.ToString();
            }
            else 
            {
                return ScheduleType.Daily.ToString();
            }            
        }
    }
}

