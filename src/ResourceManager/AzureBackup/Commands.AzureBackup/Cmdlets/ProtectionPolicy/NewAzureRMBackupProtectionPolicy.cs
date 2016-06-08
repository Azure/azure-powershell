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

using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Create new protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmBackupProtectionPolicy", DefaultParameterSetName = NoScheduleParamSet), OutputType(typeof(AzureRMBackupProtectionPolicy))]
    public class NewAzureRMBackupProtectionPolicy : AzureBackupVaultCmdletBase
    {
        protected const string WeeklyScheduleParamSet = "WeeklyScheduleParamSet";
        protected const string DailyScheduleParamSet = "DailyScheduleParamSet";
        protected const string NoScheduleParamSet = "NoScheduleParamSet";

        [Parameter(Position = 1, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WorkloadType, ValueFromPipelineByPropertyName = true)]
        [ValidateSet("AzureVM", IgnoreCase = true)]
        public string Type { get; set; }

        [Parameter(ParameterSetName = DailyScheduleParamSet, Position = 3, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.DailyScheduleType)]
        public SwitchParameter Daily { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 4, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WeeklyScheduleType)]
        public SwitchParameter Weekly { get; set; }

        [Parameter(Position = 5, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunTimes, ValueFromPipelineByPropertyName = true)]
        public DateTime BackupTime { get; set; }

        [Parameter(ParameterSetName = WeeklyScheduleParamSet, Position = 6, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunDays, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = NoScheduleParamSet, Position = 6, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ScheduleRunDays, ValueFromPipelineByPropertyName = true)]
        [AllowEmptyCollection]
        [ValidateSet("Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", IgnoreCase = true)]
        public string[] DaysOfWeek { get; set; }

        [Parameter(Position = 7, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.RetentionPolicyList, ValueFromPipelineByPropertyName = true)]
        public AzureRMBackupRetentionPolicy[] RetentionPolicy { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                WriteDebug("Making client call");

                ProtectionPolicyHelpers.ValidateProtectionPolicyName(Name);
                AzureBackupClient.CheckProtectionPolicyNameAvailability(Vault.ResourceGroupName, Vault.Name, this.Name);

                var ScheduleType = ProtectionPolicyHelpers.GetScheduleType(DaysOfWeek, this.ParameterSetName,
                                    DailyScheduleParamSet, WeeklyScheduleParamSet);

                var backupSchedule = ProtectionPolicyHelpers.FillCSMBackupSchedule(ScheduleType, BackupTime,
                    DaysOfWeek);

                ProtectionPolicyHelpers.ValidateRetentionPolicy(RetentionPolicy, backupSchedule);

                var addCSMProtectionPolicyRequest = new CSMAddProtectionPolicyRequest();
                addCSMProtectionPolicyRequest.PolicyName = this.Name;
                addCSMProtectionPolicyRequest.Properties = new CSMAddProtectionPolicyRequestProperties();
                addCSMProtectionPolicyRequest.Properties.PolicyName = this.Name;
                addCSMProtectionPolicyRequest.Properties.BackupSchedule = backupSchedule;
                addCSMProtectionPolicyRequest.Properties.WorkloadType = ProtectionPolicyHelpers.ConvertToCSMWorkLoadType(this.Type);

                addCSMProtectionPolicyRequest.Properties.LtrRetentionPolicy = ProtectionPolicyHelpers.ConvertToCSMRetentionPolicyObject(RetentionPolicy, backupSchedule);

                AzureBackupClient.AddProtectionPolicy(Vault.ResourceGroupName, Vault.Name, this.Name, addCSMProtectionPolicyRequest);
                WriteDebug(Resources.ProtectionPolicyCreated);

                var policyInfo = AzureBackupClient.GetProtectionPolicyByName(Vault.ResourceGroupName, Vault.Name, Name);
                WriteObject(ProtectionPolicyHelpers.GetCmdletPolicy(Vault, policyInfo));
            });
        }
    }

}

