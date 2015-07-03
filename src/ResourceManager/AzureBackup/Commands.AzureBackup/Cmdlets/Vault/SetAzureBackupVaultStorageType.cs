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

using Microsoft.Azure.Commands.AzureBackup.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "AzureBackupVaultStorageType")]
    public class SetAzureBackupVaultStorageType : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.StorageType)]
        [ValidateNotNullOrEmpty]
        public AzureBackupVaultStorageType Type { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                if (Type == 0)
                {
                    throw new ArgumentException("Invalid storage type.");
                }

                WriteDebug(String.Format("Updating the storage type. Type:{0}", Type));
                AzureBackupClient.UpdateStorageType(Type.ToString());
            });
        }
    }
}
