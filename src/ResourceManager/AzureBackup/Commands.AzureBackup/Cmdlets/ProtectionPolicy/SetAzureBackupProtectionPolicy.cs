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
        
        [Parameter(Position = 3, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyNewName, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug("Making client call");
                AzureBackupProtectionPolicy policy = ProtectionPolicy;
                ProtectionPolicyHelper.ValidateAzureBackupPolicyRequest(this, policy);

                var backupSchedule = ProtectionPolicyHelper.GetBackupSchedule(this, policy.BackupType, policy.ScheduleType, policy.ScheduleRunTimes,
                   policy.RetentionType, policy.RetentionDuration, policy.ScheduleRunDays.ToArray<string>());
                   
             
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
                ProtectionPolicyHelper.WriteAzureBackupProtectionPolicy(this, policy.ResourceGroupName, policy.ResourceName, policy.Location, policyObjects);

            });
        }
    }
}

