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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    public abstract class RecoveryServicesBackupVaultCmdletBase : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Common.Vault, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Vault != null)
            {
                if (string.IsNullOrEmpty(Vault.ResouceGroupName))
                {
                    throw new ArgumentException(Resources.RsVaultRGNameNullOrEmpty);
                }

                if (string.IsNullOrEmpty(Vault.Name))
                {
                    throw new ArgumentException(Resources.RsVaultResNameNullOrEmpty);
                }
            }

            InitializeAzureBackupCmdlet(Vault.ResouceGroupName, Vault.Name);
        }
    }
}