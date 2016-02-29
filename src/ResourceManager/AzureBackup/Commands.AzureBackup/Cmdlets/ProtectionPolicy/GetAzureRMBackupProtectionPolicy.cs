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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of protection policies
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupProtectionPolicy"), OutputType(typeof(AzureRMBackupProtectionPolicy), typeof(List<AzureRMBackupProtectionPolicy>))]
    public class GetAzureRMBackupProtectionPolicy : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                if (Name != null)
                {
                    var policyInfo = AzureBackupClient.GetProtectionPolicyByName(Vault.ResourceGroupName, Vault.Name, Name);
                    WriteObject(ProtectionPolicyHelpers.GetCmdletPolicy(Vault, policyInfo));
                }
                else
                {
                    var policyObjects = AzureBackupClient.ListProtectionPolicies(Vault.ResourceGroupName, Vault.Name);
                    WriteObject(ProtectionPolicyHelpers.GetCmdletPolicies(Vault, policyObjects));
                }
            });
        }
    }
}

