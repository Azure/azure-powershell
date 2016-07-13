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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Returns a retention policy PS object which can be modified in the PS shell 
    /// and fed to other cmdlets which accept it.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupRetentionPolicyObject"),
    OutputType(typeof(RetentionPolicyBase))]
    public class GetAzureRmRecoveryServicesBackupRetentionPolicyObject : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// Workload type of the policy to be created.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, 
            HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// Backup management type of the policy to be created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, 
            HelpMessage = ParamHelpMsgs.Common.BackupManagementType)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType? BackupManagementType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                PsBackupProviderManager providerManager = 
                    new PsBackupProviderManager(new Dictionary<System.Enum, object>(), ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = 
                    providerManager.GetProviderInstance(WorkloadType, BackupManagementType);
                WriteObject(psBackupProvider.GetDefaultRetentionPolicyObject());
            });
        }
    }
}
