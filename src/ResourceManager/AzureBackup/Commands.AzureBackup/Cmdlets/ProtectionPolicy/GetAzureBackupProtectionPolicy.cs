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
    /// Get list of protection policies
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupProtectionPolicy"), OutputType(typeof(AzureBackupProtectionPolicy), typeof(List<AzureBackupProtectionPolicy>))]
    public class GetAzureBackupProtectionPolicy : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 3, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug("Making client call");

                var policyListResponse = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteDebug("Received policy response");
                IEnumerable<ProtectionPolicyInfo> policyObjects = null;
                if (Name != null)
                {
                    policyObjects = policyListResponse.ProtectionPolicies.Objects.Where(x => x.Name.Equals(Name, System.StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    policyObjects = policyListResponse.ProtectionPolicies.Objects;
                }

                WriteDebug("Converting response");
                ProtectionPolicyHelper.WriteAzureBackupProtectionPolicy(this, ResourceGroupName, ResourceName, Location, policyObjects);
                
            });
        }
    }
}

