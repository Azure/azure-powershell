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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Restores an item using the recovery point provided within the recovery services vault
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupWorkloadRecoveryConfig",
        DefaultParameterSetName = RpParameterSet), OutputType(typeof(RecoveryConfigBase))]
    public class GetAzureRmRecoveryServicesBackupWorkloadRecoveryConfig : RSBackupVaultCmdletBase
    {
        internal const string RpParameterSet = "RpParameterSet";
        internal const string LogChainParameterSet = "LogChainParameterSet";

        /// <summary>
        /// Recovery point of the item to be restored
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0,
             ParameterSetName = RpParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public RecoveryPointBase RecoveryPoint { get; set; }

        /// <summary>
        /// End time of Time range for which recovery points need to be fetched
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, Position = 0,
            ParameterSetName = LogChainParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.EndDate)]
        [ValidateNotNullOrEmpty]
        public DateTime PointInTime { get; set; }

        /// <summary>
        /// Protectable Item object for which recovery points need to be fetched
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, Position = 1,
            HelpMessage = ParamHelpMsgs.RecoveryPointConfig.TargetItem)]
        [ValidateNotNullOrEmpty]
        public ProtectableItemBase TargetItem { get; set; }

        /// <summary>
        /// Protected Item object for which recovery points need to be fetched
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, Position = 2,
            HelpMessage = ParamHelpMsgs.RecoveryPointConfig.Item)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// Use this switch if the disks from the recovery point are to be restored to their original storage accounts
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.OriginalWorkloadRestore)]
        public SwitchParameter OriginalWorkloadRestore { get; set; }

        /// <summary>
        /// Use this switch if the disks from the recovery point are to be restored to their original storage accounts
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.AlternateWorkloadRestore)]
        public SwitchParameter AlternateWorkloadRestore { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                if (!OriginalWorkloadRestore.IsPresent && !AlternateWorkloadRestore.IsPresent)
                {
                    throw new ArgumentException(string.Format(Resources.AzureWorkloadRestoreLocationException));
                }

                AzureWorkloadRecoveryConfig azureWorkloadRecoveryConfig = GetConfigObject();
                azureWorkloadRecoveryConfig.SourceResourceId = Item != null ? Item.SourceResourceId : GetResourceId();
                DateTime currentTime = DateTime.Now;
                TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
                int offset = (int)timeSpan.TotalSeconds;
                string targetDb = "";
                if (ParameterSetName == RpParameterSet)
                {
                    Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(RecoveryPoint.Id);
                    string itemUri = HelperUtils.GetProtectedItemUri(keyValueDict, RecoveryPoint.Id);
                    targetDb = itemUri.Split(new string[] { ";" }, StringSplitOptions.None)[2];
                }

                if (OriginalWorkloadRestore.IsPresent)
                {
                    azureWorkloadRecoveryConfig.RestoredDBName = Item != null ?
                    ((AzureWorkloadSQLDatabaseProtectedItem)Item).FriendlyName : targetDb;
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                    azureWorkloadRecoveryConfig.ContainerId = Item != null ?
                    GetContainerId(Item.Id) : GetContainerId(GetItemId(RecoveryPoint.Id));
                }
                else if (AlternateWorkloadRestore.IsPresent && Item == null)
                {
                    if (string.Compare(((AzureWorkloadProtectableItem)TargetItem).ProtectableItemType,
                        ProtectableItemType.SQLInstance.ToString()) != 0)
                    {
                        throw new ArgumentException(string.Format(Resources.AzureWorkloadRestoreProtectableItemException));
                    }

                    azureWorkloadRecoveryConfig.RestoredDBName =
                    GetRestoredDBName(RecoveryPoint.ItemName, currentTime);
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                    List<SQLDataDirectoryMapping> targetPhysicalPath = new List<SQLDataDirectoryMapping>();

                    //Get target workload item
                    ODataQuery<BMSWorkloadItemQueryObject> queryParams = null;
                    string backupManagementType = ServiceClientModel.BackupManagementType.AzureWorkload;
                    queryParams = new ODataQuery<BMSWorkloadItemQueryObject>(
                    q => q.WorkloadItemType == WorkloadItemType.SQLInstance &&
                    q.BackupManagementType == backupManagementType);

                    var itemResponses = ServiceClientAdapter.ListWorkloadItem(
                        TargetItem.ContainerName,
                        queryParams,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                    foreach (var itemResponse in itemResponses)
                    {
                        if (string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).FriendlyName,
                            ((AzureWorkloadProtectableItem)TargetItem).FriendlyName) == 0 &&
                            string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).ServerName,
                            ((AzureWorkloadProtectableItem)TargetItem).ServerName) == 0)
                        {
                            string itemId = GetItemId(RecoveryPoint.Id);
                            IList<SQLDataDirectory> dataDirectoryPaths = GetRpDetails(vaultName, resourceGroupName);
                            foreach (var dataDirectoryPath in dataDirectoryPaths)
                            {
                                targetPhysicalPath.Add(new SQLDataDirectoryMapping()
                                {
                                    MappingType = dataDirectoryPath.Type,
                                    SourceLogicalName = dataDirectoryPath.LogicalName,
                                    SourcePath = dataDirectoryPath.Path,
                                    TargetPath = GetTargetPath(dataDirectoryPath.Path, dataDirectoryPath.LogicalName, dataDirectoryPath.Type,
                                    ((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).DataDirectoryPaths
                                    as List<SQLDataDirectory>, offset)
                                });
                            }
                            break;
                        }
                    }
                    azureWorkloadRecoveryConfig.targetPhysicalPath = targetPhysicalPath;
                    azureWorkloadRecoveryConfig.ContainerId = GetContainerId(TargetItem.Id);
                }
                else if (Item != null && TargetItem != null)
                {
                    if (string.Compare(((AzureWorkloadProtectableItem)TargetItem).ProtectableItemType,
                        ProtectableItemType.SQLDataBase.ToString()) == 0)
                    {
                        throw new ArgumentException(string.Format(Resources.AzureWorkloadRestoreProtectableItemException));
                    }

                    azureWorkloadRecoveryConfig.RestoredDBName =
                    GetRestoredDBName(Item.Name, currentTime);
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                    List<SQLDataDirectoryMapping> targetPhysicalPath = new List<SQLDataDirectoryMapping>();

                    //Get target workload item
                    ODataQuery<BMSWorkloadItemQueryObject> queryParams = null;
                    string backupManagementType = ServiceClientModel.BackupManagementType.AzureWorkload;
                    queryParams = new ODataQuery<BMSWorkloadItemQueryObject>(
                    q => q.WorkloadItemType == WorkloadItemType.SQLInstance &&
                    q.BackupManagementType == backupManagementType);

                    var itemResponses = ServiceClientAdapter.ListWorkloadItem(
                        TargetItem.ContainerName,
                        queryParams,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                    foreach (var itemResponse in itemResponses)
                    {
                        if (string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).FriendlyName,
                            ((AzureWorkloadProtectableItem)TargetItem).FriendlyName) == 0 &&
                            string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).ServerName,
                            ((AzureWorkloadProtectableItem)TargetItem).ServerName) == 0)
                        {
                            List<SQLDataDirectory> dataDirectory = GetDataDirectory(vaultName, resourceGroupName, Item.Id, PointInTime);
                            foreach (var dataDirectoryPath in dataDirectory)
                            {
                                targetPhysicalPath.Add(new SQLDataDirectoryMapping()
                                {
                                    MappingType = dataDirectoryPath.Type,
                                    SourceLogicalName = dataDirectoryPath.LogicalName,
                                    SourcePath = dataDirectoryPath.Path,
                                    TargetPath = GetTargetPath(dataDirectoryPath.Path, dataDirectoryPath.LogicalName, dataDirectoryPath.Type,
                                    ((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).DataDirectoryPaths
                                    as List<SQLDataDirectory>, offset)
                                });
                            }
                            break;
                        }
                    }

                    azureWorkloadRecoveryConfig.targetPhysicalPath = targetPhysicalPath;
                    azureWorkloadRecoveryConfig.ContainerId = GetContainerId(TargetItem.Id);
                }
                RecoveryConfigBase baseobj = azureWorkloadRecoveryConfig;
                WriteObject(baseobj);
            });
        }

        public string GetTargetPath(string path, string name, string type, List<SQLDataDirectory> DataDirectoryPaths, int offset)
        {
            SQLDataDirectory sqlDataDirectory = DataDirectoryPaths.Find(
                dataDirectoryPaths => string.Compare(dataDirectoryPaths.Type,
                type, true) == 0);
            List<string> pathParts = new List<string>(path.Split(new string[] { "\\" }, StringSplitOptions.None));
            int len = pathParts.Count();
            List<string> fileNameParts = new List<string>(pathParts[len - 1].Split(new string[] { "." }, StringSplitOptions.None));
            string newFileName = name + "_" + offset.ToString() + "." + fileNameParts[1];
            return sqlDataDirectory.Path + newFileName;
        }

        public string GetResourceId()
        {
            try
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier();
                resourceIdentifier.Subscription = ServiceClientAdapter.SubscriptionId;
                resourceIdentifier.ResourceGroupName = RecoveryPoint.ContainerName.Split(new string[] { ";" }, StringSplitOptions.None)[1];
                resourceIdentifier.ResourceType = "/VMAppContainer";
                resourceIdentifier.ResourceName = RecoveryPoint.ContainerName.Split(new string[] { ";" }, StringSplitOptions.None)[2];
                return resourceIdentifier.ToString();
            }
            catch
            {
                return null;
            }
        }

        public string GetItemId(string recoveryPointId)
        {
            string[] split = recoveryPointId.Split(new string[] { "/" }, StringSplitOptions.None);
            return string.Join("/", split.ToList().GetRange(0, split.Length - 2));

        }
        public string GetContainerId(string itemId)
        {
            string[] split = itemId.Split(new string[] { "/" }, StringSplitOptions.None);
            return string.Join("/", split.ToList().GetRange(0, split.Length - 2));
        }

        public List<SQLDataDirectory> GetDataDirectory(string vaultName, string resourceGroupName, string itemId, DateTime pointInTime)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(itemId);
            string containerUri = HelperUtils.GetContainerUri(uriDict, itemId);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, itemId);
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BMSRPQueryObject()
            {
                RestorePointQueryType = RestorePointQueryType.Log,
                ExtendedInfo = true
            });

            ODataQuery<BMSRPQueryObject> queryFilter = new ODataQuery<BMSRPQueryObject>();
            queryFilter.Filter = queryFilterString;

            var rpResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
            List<SQLDataDirectory> dataDirectoryPaths = new List<SQLDataDirectory>();
            if (rpResponse[0].Properties.GetType() == typeof(AzureWorkloadSQLPointInTimeRecoveryPoint))
            {
                AzureWorkloadSQLPointInTimeRecoveryPoint recoveryPoint =
                    rpResponse[0].Properties as AzureWorkloadSQLPointInTimeRecoveryPoint;
                if (recoveryPoint.ExtendedInfo != null)
                {
                    foreach (SQLDataDirectory dataDirectoryPath in recoveryPoint.ExtendedInfo.DataDirectoryPaths)
                    {
                        dataDirectoryPaths.Add(dataDirectoryPath);
                    }
                }
            }
            return dataDirectoryPaths;
        }

        public IList<SQLDataDirectory> GetRpDetails(string vaultName, string resourceGroupName)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(RecoveryPoint.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, RecoveryPoint.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, RecoveryPoint.Id);

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetails(
                containerUri,
                protectedItemName,
                RecoveryPoint.RecoveryPointId,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
            AzureWorkloadSQLRecoveryPoint recoveryPoint = rpResponse.Properties as AzureWorkloadSQLRecoveryPoint;
            return recoveryPoint.ExtendedInfo.DataDirectoryPaths;
        }

        public string GetRestoredDBName(string itemName, DateTime currentTime)
        {
            List<string> nameList = new List<string>(itemName.Split(new string[] { ";" }, StringSplitOptions.None));

            string itemSuffix = currentTime.Month.ToString() + "_" + currentTime.Day.ToString() + "_" +
                currentTime.Year.ToString() + "_" + currentTime.Hour.ToString() + currentTime.Minute.ToString();

            return nameList.Last() + "_restored_" + itemSuffix;
        }

        public AzureWorkloadRecoveryConfig GetConfigObject()
        {
            string targetServer = "";
            string parentName = "";
            string restoreRequestType = "";
            RecoveryPointBase recoveryPoint = RecoveryPoint;
            DateTime pointInTime = PointInTime;

            if (ParameterSetName == RpParameterSet)
            {
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(RecoveryPoint.Id);
                string containerUri = HelperUtils.GetContainerUri(keyValueDict, RecoveryPoint.Id);
                try
                {
                    targetServer = containerUri.Split(new string[] { ";" }, StringSplitOptions.None)[3];
                }
                catch
                {
                    targetServer = containerUri.Split(new string[] { ";" }, StringSplitOptions.None)[1];
                }

                string itemUri = HelperUtils.GetProtectedItemUri(keyValueDict, RecoveryPoint.Id);
                parentName = itemUri.Split(new string[] { ";" }, StringSplitOptions.None)[1];
            }

            if (OriginalWorkloadRestore.IsPresent)
            {
                restoreRequestType = "Original WL Restore";
                if (Item != null)
                {
                    targetServer = ((AzureWorkloadSQLDatabaseProtectedItem)Item).ServerName;
                    parentName = ((AzureWorkloadSQLDatabaseProtectedItem)Item).ParentName;
                }
                if (RecoveryPoint == null)
                {
                    Models.AzureWorkloadRecoveryPoint azureWorkloadRecoveryPoint = new Models.AzureWorkloadRecoveryPoint()
                    {
                        Id = Item.Id + "/recoveryPoints/DefaultRangeRecoveryPoint",
                        RecoveryPointId = "DefaultRangeRecoveryPoint"
                    };
                    recoveryPoint = azureWorkloadRecoveryPoint;
                }
            }
            else if (AlternateWorkloadRestore.IsPresent && Item == null)
            {
                restoreRequestType = "Alternate WL Restore";
                targetServer = ((AzureWorkloadProtectableItem)TargetItem).ServerName;
                parentName = ((AzureWorkloadProtectableItem)TargetItem).ParentName;
            }
            else if (Item != null && TargetItem != null)
            {
                restoreRequestType = "Alternate WL Restore to diff item";
                targetServer = ((AzureWorkloadProtectableItem)TargetItem).ServerName;
                parentName = ((AzureWorkloadProtectableItem)TargetItem).ParentName;

                Models.AzureWorkloadRecoveryPoint azureWorkloadRecoveryPoint = new Models.AzureWorkloadRecoveryPoint()
                {
                    Id = Item.Id + "/recoveryPoints/DefaultRangeRecoveryPoint",
                    RecoveryPointId = "DefaultRangeRecoveryPoint"
                };
                recoveryPoint = azureWorkloadRecoveryPoint;
            }

            return new AzureWorkloadRecoveryConfig(targetServer, parentName, restoreRequestType, recoveryPoint, pointInTime);
        }
    }
}