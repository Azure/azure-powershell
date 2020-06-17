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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Rehydrates a backup item from softdeleted state
    /// </summary>
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupItemDeletion", SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class UndoAzureRmRecoveryServicesBackupItemDeletion : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// The protected item which needs to be rehydrated
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Item.ReprotectItem,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// Prevents the confirmation dialog when specified.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.ForceOption)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {

            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                    {
                        { VaultParams.VaultName, vaultName },
                        { VaultParams.ResourceGroupName, resourceGroupName },
                        { ItemParams.Item, Item },
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider =
                    providerManager.GetProviderInstance(Item.WorkloadType,
                    Item.BackupManagementType);

                var itemResponse = psBackupProvider.UndeleteProtection();

                HandleCreatedJob(
                        itemResponse,
                        Resources.DisableProtectionOperation,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

            }, ShouldProcess(Item.Name, VerbsLifecycle.Disable));
        }
    }
}