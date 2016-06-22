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

using Microsoft.Azure.Commands.AzureBackup.Properties;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Remove a protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmBackupProtectionPolicy", SupportsShouldProcess = true)]
    public class RemoveAzureRMBackupProtectionPolicy : AzureBackupPolicyCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
               Force.IsPresent,
               string.Format(Resources.RemoveProtectionPolicyWarning, ProtectionPolicy.Name),
               Resources.RemoveProtectionPolicyMessage,
               ProtectionPolicy.Name, () =>
               {
                   ExecutionBlock(() =>
                   {
                       base.ExecuteCmdlet();

                       WriteDebug(Resources.MakingClientCall);

                       var policyInfo = AzureBackupClient.GetProtectionPolicyByName(ProtectionPolicy.ResourceGroupName, ProtectionPolicy.ResourceName, ProtectionPolicy.Name);
                       if (policyInfo != null)
                       {
                           AzureBackupClient.DeleteProtectionPolicy(ProtectionPolicy.ResourceGroupName, ProtectionPolicy.ResourceName, policyInfo.Name);
                           WriteDebug(Resources.ProtectionPolicyDeleted);
                       }
                       else
                       {
                           var exception = new ArgumentException(string.Format(Resources.PolicyNotFound, ProtectionPolicy.Name));
                           throw exception;
                       }
                   });

               });
        }
    }
}

