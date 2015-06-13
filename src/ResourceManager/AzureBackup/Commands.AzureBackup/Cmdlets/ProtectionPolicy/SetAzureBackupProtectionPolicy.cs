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
    public class SetAzureBackupProtectionPolicy : AzureBackupPolicyCmdletBase
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 4, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyInstanceId, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string InstanceId { get; set; }

        [Parameter(Position = 5, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.BackupType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Full")]
        public string BackupType { get; set; }

        [Parameter(Position = 6, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Daily", "Weekly")]
        public string ScheduleType { get; set; }        

        [Parameter(Position = 7, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunTimes, ValueFromPipelineByPropertyName = true)]
        public DateTime ScheduleRunTimes { get; set; }

        [Parameter(Position = 8, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.RetentionType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Days", IgnoreCase = true)]
        public string RetentionType { get; set; }

        [Parameter(Position = 9, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.RententionDuration, ValueFromPipelineByPropertyName = true)]
        [ValidateRange(1, 30)]
        public int RetentionDuration { get; set; }

        [Parameter(Position = 10, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunDays, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", IgnoreCase = true)]
        public string[] ScheduleRunDays { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug("Making client call");

                var backupSchedule = GetBackupSchedule(BackupType, ScheduleType, ScheduleRunTimes,
                    RetentionType, RetentionDuration, ScheduleRunDays);                
               
                var updateProtectionPolicyRequest = new UpdateProtectionPolicyRequest();
                updateProtectionPolicyRequest.PolicyName = this.Name;
                updateProtectionPolicyRequest.Schedule = backupSchedule;
             
                var policyListResponse = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                
                WriteDebug("Got the protectionPolicy List");

                IEnumerable<ProtectionPolicyInfo> policyObjects = null;

                policyObjects = policyListResponse.ProtectionPolicies.Objects.Where(x => x.InstanceId.Equals(this.InstanceId, System.StringComparison.InvariantCultureIgnoreCase));

                WriteDebug("Got the protectionPolicy with InstanceId" + InstanceId);

                if (policyObjects.Count<ProtectionPolicyInfo>() != 0)
                {
                    var operationId = AzureBackupClient.ProtectionPolicy.UpdateAsync(this.InstanceId, updateProtectionPolicyRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                }
                else
                {
                    var exception = new Exception("Protection Policy Not Found with InstanceId" + this.InstanceId);
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    WriteError(errorRecord);                   
                }

                WriteVerbose("Protection Policy successfully updated");

                var policyListResponse_afterUpdate = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteDebug("Received policy response");

                policyObjects = policyListResponse_afterUpdate.ProtectionPolicies.Where(x => x.Name.Equals(Name, System.StringComparison.InvariantCultureIgnoreCase));

                WriteDebug("Converting response");
                WriteAzureBackupProtectionPolicy(policyObjects);
            });
        }
    }
}

