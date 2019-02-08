﻿// ----------------------------------------------------------------------------------
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
using System.Linq;
using System.Management.Automation;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of items associated with the recovery services vault 
    /// according to the filters passed via the cmdlet parameters.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtectableItem",
        DefaultParameterSetName = NoFilterParamSet), OutputType(typeof(ProtectableItemBase))]
    public class GetAzureRmRecoveryServicesBackupProtectableItem : RSBackupVaultCmdletBase
    {
        internal const string NoFilterParamSet = "NoFilterParamSet";
        internal const string FilterParamSet = "FilterParamSet";
        internal const string IdParamSet = "IdParamSet";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = NoFilterParamSet,
            HelpMessage = ParamHelpMsgs.Item.Container, ValueFromPipelineByPropertyName = true)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = FilterParamSet,
            HelpMessage = ParamHelpMsgs.Item.Container, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public ContainerBase Container { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = IdParamSet,
            HelpMessage = ParamHelpMsgs.Item.ParentID, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ParentID { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = NoFilterParamSet,
            HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = FilterParamSet,
            HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public Models.WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// When this option is specified, only those items which belong to this container will be returned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = FilterParamSet,
            HelpMessage = ParamHelpMsgs.ProtectableItem.ItemType, ValueFromPipelineByPropertyName = false)]
        public ProtectableItemType ItemType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                string backupManagementType = "";
                string workloadType = "";
                string containerName = "";
                if (ParameterSetName == IdParamSet)
                {
                    Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(ParentID);
                    containerName = HelperUtils.GetContainerUri(keyValueDict, ParentID);
                    if (containerName.Split(new string[] { ";" }, System.StringSplitOptions.None)[0].ToLower() == "vmappcontainer")
                    {
                        backupManagementType = ServiceClientModel.BackupManagementType.AzureWorkload;
                    }
                    string protectableItem = HelperUtils.GetProtectableItemUri(keyValueDict, ParentID);
                    if (protectableItem.Split(new string[] { ";" }, System.StringSplitOptions.None)[0].ToLower() == "sqlinstance" ||
                    protectableItem.Split(new string[] { ";" }, System.StringSplitOptions.None)[0].ToLower() == "sqlavailabilitygroupcontainer")
                    {
                        workloadType = ServiceClientModel.WorkloadType.SQLDataBase;
                    }
                }
                else
                {
                    backupManagementType = Container.BackupManagementType.ToString();
                    workloadType = ConversionUtils.GetServiceClientWorkloadType(WorkloadType.ToString());
                    containerName = Container.Name;
                }
                ODataQuery<BMSPOQueryObject> queryParam = new ODataQuery<BMSPOQueryObject>(
                q => q.BackupManagementType
                     == backupManagementType &&
                     q.WorkloadType == workloadType &&
                     q.ContainerName == containerName);

                WriteDebug("going to query service to get list of protectable items");
                List<WorkloadProtectableItemResource> protectableItems =
                    ServiceClientAdapter.ListProtectableItem(
                        queryParam,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                WriteDebug("Successfully got response from service");
                List<ProtectableItemBase> itemModels = ConversionHelpers.GetProtectableItemModelList(protectableItems);

                if (ParameterSetName == FilterParamSet)
                {
                    string protectableItemType = ItemType.ToString();
                    itemModels = itemModels.Where(itemModel =>
                    {
                        return ((AzureWorkloadProtectableItem)itemModel).ProtectableItemType == protectableItemType;
                    }).ToList();
                }
                WriteObject(itemModels, enumerateCollection: true);
            });
        }
    }
}