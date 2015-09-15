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
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Remove a protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRMBackupProtectionPolicy")]
    public class RemoveAzureRMBackupProtectionPolicy : AzureBackupPolicyCmdletBase
    {
        public override void ExecuteCmdlet()
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
        }        
    }
}

