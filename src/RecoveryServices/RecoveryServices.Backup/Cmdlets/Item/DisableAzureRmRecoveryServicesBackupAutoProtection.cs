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
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Disable auto protection of an item with the recovery services vault. 
    /// </summary>
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupAutoProtection", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class DisableAzureRmRecoveryServicesBackupAutoProtection : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Name of the Azure VM whose representative item needs to be protected.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = ParamHelpMsgs.ProtectableItem.ItemId)]
        public ProtectableItemBase InputItem { get; set; }

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

        /// <summary>
        /// Return the result for auto protection
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the result for auto protection.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                string shouldProcessName = InputItem.Id;

                string itemType = "";
                string itemName = "";
                string containerUri = "";
                if (ShouldProcess(shouldProcessName, VerbsLifecycle.Disable))
                {
                    Dictionary<UriEnums, string> keyValueDict =
                    HelperUtils.ParseUri(InputItem.Id);

                    itemType = HelperUtils.GetProtectableItemUri(
                        keyValueDict, InputItem.Id).Split(';')[0];
                    itemName = HelperUtils.GetProtectableItemUri(
                        keyValueDict, InputItem.Id).Split(';')[1];
                    containerUri = HelperUtils.GetContainerUri(
                        keyValueDict, InputItem.Id);

                    bool isDisableAutoProtectionSuccessful = false;

                    try
                    {
                        ODataQuery<ServiceClientModel.ProtectionIntentQueryObject> queryParams = null;
                        string backupManagementType = ServiceClientModel.BackupManagementType.AzureWorkload;
                        queryParams = new ODataQuery<ServiceClientModel.ProtectionIntentQueryObject>(
                        q => q.ItemType == itemType &&
                        q.ItemName == itemName &&
                        q.ParentName == containerUri &&
                        q.BackupManagementType == backupManagementType);

                        var itemResponses = ServiceClientAdapter.ListProtectionIntent(
                        queryParams,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                        string intentName = null;
                        foreach (var itemResponse in itemResponses)
                        {
                            string itemNameResponse = "";
                            string containerNameResponse = "";

                            Dictionary<UriEnums, string> keyValueDictResponse =
                            HelperUtils.ParseUri(itemResponse.Properties.ItemId);
                            itemNameResponse = HelperUtils.GetProtectableItemUri(
                            keyValueDictResponse, itemResponse.Properties.ItemId).ToLower();
                            containerNameResponse = HelperUtils.GetContainerUri(
                            keyValueDictResponse, itemResponse.Properties.ItemId);

                            if (String.Compare(itemNameResponse, itemName, true) == 0 &&
                            String.Compare(containerUri.Split(';')[3], containerNameResponse.Split(';')[2], true) == 0)
                            {
                                intentName = itemResponse.Name;
                                break;
                            }
                        }

                        var deleteResponse = ServiceClientAdapter.DeleteProtectionIntent(
                        intentName,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                        isDisableAutoProtectionSuccessful = true;
                    }
                    catch
                    {

                    }
                    if (PassThru.IsPresent)
                    {
                        WriteObject(isDisableAutoProtectionSuccessful);
                    }
                }
            });
        }
    }
}
