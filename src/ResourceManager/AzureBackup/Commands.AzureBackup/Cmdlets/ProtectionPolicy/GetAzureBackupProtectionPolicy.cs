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
using Microsoft.WindowsAzure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupProtectionPolicy"), OutputType(typeof(ProtectionPolicyInfo), typeof(List<ProtectionPolicyInfo>))]
    public class GetAzureBackupProtectionPolicy : AzureBackupCmdletBase
    {
        [Parameter(Position = 2, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                var policyListResponse = AzureBackupClient.ProtectionPolicy.ListAsync("1234", CmdletCancellationToken).Result;

                WriteAzureBackupProtectionPolicy(policyListResponse.ProtectionPolicies.Objects);
            });
        }

        public void WriteAzureBackupProtectionPolicy(ProtectionPolicyInfo sourcePolicy)
        {
            this.WriteObject(new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, sourcePolicy));
        }

        public void WriteAzureBackupProtectionPolicy(IList<ProtectionPolicyInfo> sourcePolicyList)
        {
            List<AzureBackupProtectionPolicy> targetList = new List<AzureBackupProtectionPolicy>();

            foreach (var sourcePolicy in sourcePolicyList)
            {
                targetList.Add(new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, sourcePolicy));
            }

            this.WriteObject(targetList, true);
        }
    }
}

