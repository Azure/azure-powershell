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
    [Cmdlet(VerbsCommon.Remove, "AzureRmRecoveryServicesProtectionPolicy")]
    public class RemoveAzureRmRecoveryServicesProtectionPolicy : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsg.Policy.ProtectionPolicy, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesPolicyBase Policy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Common.ConfirmationMessage)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
               Force.IsPresent,
               string.Format(Resources.RemoveProtectionPolicyWarning, Policy.Name),
               Resources.RemoveProtectionPolicyMessage,
               Policy.Name, () =>
               {
                   ExecutionBlock(() =>
                   {
                       base.ExecuteCmdlet();

                       WriteDebug(Resources.MakingClientCall);

                       HydraAdapter.RemoveProtectionPolicy(Policy.Name);
                       WriteDebug(Resources.ProtectionPolicyDeleted);
                   });

               });
        }
    }
}
