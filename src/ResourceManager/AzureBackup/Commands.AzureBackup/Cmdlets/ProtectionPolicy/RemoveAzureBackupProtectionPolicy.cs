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
    /// Remove a protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureBackupProtectionPolicy")]
    public class RemoveAzureBackupProtectionPolicy : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");

                var policyListResponse = AzureBackupClient.ProtectionPolicy.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteVerbose("Received policy response");
                IEnumerable<ProtectionPolicyInfo> policyObjects = null;

                policyObjects = policyListResponse.ProtectionPolicies.Objects.Where(x => x.Name.Equals(Name, System.StringComparison.InvariantCultureIgnoreCase));

                if (policyObjects.Count<ProtectionPolicyInfo>() != 0)
                {
                    ProtectionPolicyInfo protectionPolicyInfo = policyObjects.ElementAt<ProtectionPolicyInfo>(0);
                    var policyRemoveResponse = AzureBackupClient.ProtectionPolicy.DeleteAsync(protectionPolicyInfo.InstanceId, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                }
                else
                {
                    WriteVerbose("Policy Not Found");
                }

                WriteVerbose("Converting response");
                WriteVerbose("Successfully deleted policy");
            });
        }        
    }
}

