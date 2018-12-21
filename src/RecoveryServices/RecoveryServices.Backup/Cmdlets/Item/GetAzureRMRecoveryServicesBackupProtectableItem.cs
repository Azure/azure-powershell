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
using Microsoft.Rest.Azure.OData;
using System.Collections.Generic;
using System.Management.Automation;
using BackupManagementType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.BackupManagementType;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of items associated with the recovery services vault 
    /// according to the filters passed via the cmdlet parameters.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtectableItem"), OutputType(typeof(ProtectableItemBase))]
    public class GetAzureRmRecoveryServicesBackupProtectableItem : RSBackupVaultCmdletBase
    {

        /// <summary>
        /// When this option is specified, only those items which belong to this container will be returned.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = ParamHelpMsgs.ProtectableItem.ItemType,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public ProtectableItemType ProtectableItemType { get; set; }

        ///// <summary>
        ///// Backup management type of the items to be returned.
        ///// </summary>
        //[Parameter(Mandatory = true, Position = 2, HelpMessage = ParamHelpMsgs.Common.BackupManagementType)]
        //[ValidateNotNullOrEmpty]
        //public BackupManagementType BackupManagementType { get; set; }

        //[Parameter(
        //    Mandatory = true,
        //    Position = 2,
        //    HelpMessage = ParamHelpMsgs.Item.Container,
        //    ValueFromPipelineByPropertyName = true)]
        //[ValidateNotNullOrEmpty]
        //public ContainerBase Container { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                string backupManagementType = BackupManagementType.AzureWorkload.ToString();
                string workloadType = ProtectableItemType.ToString();
                ODataQuery<BMSPOQueryObject> queryParam = new ODataQuery<BMSPOQueryObject>(
                q => q.BackupManagementType
                     == backupManagementType &&
                     q.WorkloadType == workloadType);

                WriteDebug("going to query service to get list of protectable items");
                List<WorkloadProtectableItemResource> protectableItems =
                    ServiceClientAdapter.ListProtectableItem(
                        queryParam,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                WriteDebug("Successfully got response from service");
                List<ProtectableItemBase> itemModels = ConversionHelpers.GetProtectableItemModelList(protectableItems);

                WriteObject(itemModels, enumerateCollection: true);
            });
        }
    }
}