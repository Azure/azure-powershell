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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System.Collections.Generic;
using System.Management.Automation;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enable protection of an item with the recovery services vault. 
    /// Returns the corresponding job created in the service to track this operation.
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupAutoProtection", SupportsShouldProcess = true)]
    public class EnableAzureRmRecoveryServicesBackupAutoProtection : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Name of the Azure VM whose representative item needs to be protected.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = ParamHelpMsgs.ProtectableItem.ItemId)]
        public string InputItem { get; set; }

        /// <summary>
        /// Backup management type of the items to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = ParamHelpMsgs.Common.BackupManagementType)]
        [ValidateNotNullOrEmpty]
        public Models.BackupManagementType BackupManagementType { get; set; }

        /// <summary>
        /// Backup management type of the items to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public Models.WorkloadType WorkloadType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                string shouldProcessName = InputItem;

                string protectedItemUri = "";
                if (ShouldProcess(shouldProcessName, VerbsLifecycle.Enable))
                {
                    Dictionary<UriEnums, string> keyValueDict =
                    HelperUtils.ParseUri(InputItem);
                    protectedItemUri = HelperUtils.GetProtectableItemUri(
                        keyValueDict, InputItem);
                    ProtectionIntent properties = new ProtectionIntent();
                    properties.BackupManagementType = ServiceClientModel.BackupManagementType.AzureWorkload;
                    properties.ItemId = InputItem;
                    properties.PolicyId = "/subscriptions/da364f0f-307b-41c9-9d47-b7413ec45535/resourceGroups/pstestwlRG1bca8/providers/Microsoft.RecoveryServices/vaults/pstestwlRSV1bca8/backupPolicies/HourlyLogBackup";
                    ProtectionIntentResource serviceClientRequest = new ProtectionIntentResource()
                    {
                        Properties = properties
                    };
                    var getResponse = ServiceClientAdapter.CreateOrUpdateProtectionIntent(
                        protectedItemUri,
                        serviceClientRequest,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                }
            });
        }
    }
}
