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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Update existing protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmRecoveryServicesProtectionPolicy"), OutputType(typeof(List<AzureRmRecoveryServicesJobBase>))]
    public class SetAzureRmRecoveryServicesProtectionPolicy : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsg.Policy.ProtectionPolicy, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesPolicyBase Policy { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = ParamHelpMsg.Policy.RetentionPolicy)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesRetentionPolicyBase RetentionPolicy { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = ParamHelpMsg.Policy.SchedulePolicy)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesSchedulePolicyBase SchedulePolicy { get; set; }
       
        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                // Validate policy name
                PolicyCmdletHelpers.ValidateProtectionPolicyName(Policy.Name);

                // Validate if policy already exists               
                ProtectionPolicyResponse servicePolicy = PolicyCmdletHelpers.GetProtectionPolicyByName(
                                                                              Policy.Name, HydraAdapter);
                if (servicePolicy == null)
                {
                    throw new ArgumentException(string.Format(Resources.PolicyNotFoundException, Policy.Name));
                }

                PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                { 
                    {PolicyParams.ProtectionPolicy, Policy},
                    {PolicyParams.RetentionPolicy, RetentionPolicy},
                    {PolicyParams.SchedulePolicy, SchedulePolicy},                
                }, HydraAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(Policy.WorkloadType,
                                                                                         Policy.BackupManagementType);
                // now convert hydraPolicy to PSObject
                WriteObject(psBackupProvider.ModifyPolicy());
            });
        }
    }
}
