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
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
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
        [Parameter(Mandatory = false, ValueFromPipeline = false,
            ParameterSetName = RpParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.EndDate)]
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

        /// <summary>
        /// Target Container to which files will be written
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.TargetContainer)]
        public ContainerBase TargetContainer { get; set; }

        /// <summary>
        /// Use this switch to restore db as files to a given target container
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.RestoeAsFiles)]
        public SwitchParameter RestoreAsFiles { get; set; }

        /// <summary>
        /// Specify Recovery point from which logs will be applies
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.FromFull)]
        public RecoveryPointBase FromFull { get; set; }

        /// <summary>
        /// Specify Recovery point from which logs will be applies
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.FilePath)]
        public string FilePath { get; set; }

        /// <summary>
        /// Switch parameter to specify fetching resources from Secondary Region.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Common.UseSecondaryReg)]
        public SwitchParameter UseSecondaryRegion;

        /// <summary>
        /// List of disk ARM IDs to detach in case of a filesystem clash during SQL (MSSQL) Instance snapshot restore.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RestoreDisk.DisksToDetachOnClash)]
        [ValidateNotNullOrEmpty]
        public string[] DisksToDetachOnClash { get; set; }

        /// <summary>
        /// Target resource group name for SQL (MSSQL) Instance snapshot restore.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RestoreVM.TargetResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// ARM ID of the user-assigned managed identity used for SQL (MSSQL) Instance snapshot restore.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RestoreVM.UserAssignedIdentityId)]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentityId { get; set; }

        /// <summary>
        /// Target database name for SQL (MSSQL) Instance snapshot restore (maps to targetInfo.databaseName).
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RestoreDisk.TargetInstanceDatabaseName)]
        [ValidateNotNullOrEmpty]
        public string TargetInstanceDatabaseName { get; set; }

        /// <summary>
        /// Recovery mode for SQL (MSSQL) Instance snapshot restore.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.RecoveryMode)]
        [ValidateSet("SnapshotAttachAndRecover", "SnapshotAttach", "RecoveryUsingSnapshot")]
        public string RecoveryMode { get; set; }

        /// <summary>
        /// Restore the database(s) in NORECOVERY mode, leaving them non-recoverable so that further
        /// restores (for example a subsequent log restore) can be applied. Maps to isNonRecoverable.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.NoRecoveryMode)]
        public SwitchParameter NoRecoveryMode { get; set; }

        /// <summary>
        /// Target directory mapping for SnapshotAttach restore (e.g. @{ all = "C:/temp" }).
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.TargetDirectoryMapping)]
        [ValidateNotNullOrEmpty]
        public System.Collections.Hashtable TargetDirectoryMapping { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;
                string targetVaultName = "";
                string targetResourceGroupName = "";
                string targetSubscriptionId = "";

                if (!OriginalWorkloadRestore.IsPresent && !AlternateWorkloadRestore.IsPresent && !RestoreAsFiles.IsPresent)
                {
                    throw new ArgumentException(string.Format(Resources.AzureWorkloadRestoreLocationException));
                }

                AzureWorkloadRecoveryConfig azureWorkloadRecoveryConfig = GetConfigObject();
                azureWorkloadRecoveryConfig.SourceResourceId = Item != null ? Item.SourceResourceId : GetResourceId();
                DateTime currentTime = DateTime.Now;
                TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
                int offset = (int)timeSpan.TotalSeconds;
                string targetDb = "";

                if (AlternateWorkloadRestore.IsPresent || RestoreAsFiles.IsPresent)
                {
                    if (TargetContainer == null)
                    {
                        throw new ArgumentNullException("TargetContainer", Resources.TargetContainerRequiredException);
                    }

                    azureWorkloadRecoveryConfig.TargetVirtualMachineId = (TargetContainer as AzureVmWorkloadContainer).SourceResourceId;
                }

                if (TargetItem != null)
                {
                    // getting Target vault/RG for TargetPhysicalPath in CRR
                    Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(TargetItem.Id);
                    targetResourceGroupName = HelperUtils.GetResourceGroupNameFromId(keyValueDict, TargetItem.Id);
                    targetVaultName = HelperUtils.GetVaultNameFromId(keyValueDict, TargetItem.Id);
                    targetSubscriptionId = HelperUtils.GetSubscriptionIdFromId(keyValueDict, TargetItem.Id);

                    // check if the TargetItem provided is of workload type
                    if (!string.Equals(((AzureWorkloadProtectableItem)TargetItem).ProtectableItemType,
                        ProtectableItemType.SQLInstance.ToString()))
                    {
                        throw new ArgumentException(string.Format(Resources.AzureWorkloadRestoreProtectableItemException));
                    }
                }

                bool isInstance = false;
                string instanceName = "";
                if (ParameterSetName == RpParameterSet)
                {
                    Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(RecoveryPoint.Id);
                    string itemUri = HelperUtils.GetProtectedItemUri(keyValueDict, RecoveryPoint.Id);
                    string[] itemUriParts = itemUri.Split(new string[] { ";" }, StringSplitOptions.None);

                    // SQL Instance protected item URI is "sqlinstance;<server>" (2 parts); a SQL Database item
                    // is "sqlinstance;<server>;<db>" (3 parts). Detect instance vs database accordingly.
                    isInstance = itemUriParts.Length < 3;
                    instanceName = itemUriParts.Length >= 2 ? itemUriParts[1] : "";
                    targetDb = isInstance ? itemUriParts[1] : itemUriParts[2];
                }
                else if (Item != null)
                {
                    // Point-in-time (log chain) path: there is no RecoveryPoint, so detect instance vs database
                    // from the source protected item URI instead ("sqlinstance;<server>" = instance).
                    Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(Item.Id);
                    string itemUri = HelperUtils.GetProtectedItemUri(keyValueDict, Item.Id);
                    string[] itemUriParts = itemUri.Split(new string[] { ";" }, StringSplitOptions.None);

                    isInstance = itemUriParts.Length < 3;
                    instanceName = itemUriParts.Length >= 2 ? itemUriParts[1] : "";
                    targetDb = isInstance ? itemUriParts[1] :
                        (itemUriParts.Length >= 3 ? itemUriParts[2] : "");
                }

                // Snapshot restore applies to SQL Instance (always snapshot) and to SQL Database items when the
                // caller requests a snapshot recovery mode via -RecoveryMode.
                bool isSnapshotRestore = isInstance || !string.IsNullOrEmpty(RecoveryMode);

                if (isSnapshotRestore)
                {
                    // Snapshot restore defaults to snapshot attach-and-recover mode; -RecoveryMode can select
                    // SnapshotAttach or RecoveryUsingSnapshot instead.
                    azureWorkloadRecoveryConfig.RecoveryMode = string.IsNullOrEmpty(RecoveryMode) ?
                        "SnapshotAttachAndRecover" : RecoveryMode;
                }

                if (OriginalWorkloadRestore.IsPresent)
                {
                    // Item may be a SQL Database or a SQL Instance protected item; both carry FriendlyName but
                    // neither derives from the other, so resolve the name without an unconditional DB cast.
                    AzureWorkloadSQLInstanceProtectedItem instanceItemForName = Item as AzureWorkloadSQLInstanceProtectedItem;
                    azureWorkloadRecoveryConfig.RestoredDBName = Item != null ?
                    (instanceItemForName != null ? instanceItemForName.FriendlyName :
                        ((AzureWorkloadSQLDatabaseProtectedItem)Item).FriendlyName) : targetDb;
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                    azureWorkloadRecoveryConfig.ContainerId = Item != null ?
                    GetContainerId(Item.Id) : GetContainerId(GetItemId(RecoveryPoint.Id));
                }
                else if (AlternateWorkloadRestore.IsPresent && Item == null)
                {
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

                    List<WorkloadItemResource> itemResponses;
                    if (targetVaultName != "" && targetResourceGroupName != "")
                    {
                        string subscriptionContext = ServiceClientAdapter.BmsAdapter.Client.SubscriptionId;
                        ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = targetSubscriptionId;

                        itemResponses = ServiceClientAdapter.ListWorkloadItem(
                        TargetItem.ContainerName,
                        queryParams,
                        vaultName: targetVaultName,
                        resourceGroupName: targetResourceGroupName);

                        ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = subscriptionContext;
                    }
                    else
                    {
                        itemResponses = ServiceClientAdapter.ListWorkloadItem(
                        TargetItem.ContainerName,
                        queryParams,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                    }

                    foreach (var itemResponse in itemResponses)
                    {
                        if (string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).FriendlyName,
                            ((AzureWorkloadProtectableItem)TargetItem).FriendlyName) == 0 &&
                            string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).ServerName,
                            ((AzureWorkloadProtectableItem)TargetItem).ServerName) == 0)
                        {
                            string itemId = GetItemId(RecoveryPoint.Id);

                            if(UseSecondaryRegion)
                            {
                                IList<CrrModel.SQLDataDirectory> dataDirectoryPathsCrr = GetRpDetailsFromSecondaryRegion(vaultName, resourceGroupName);
                                                                
                                foreach (var dataDirectoryPath in dataDirectoryPathsCrr)
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
                            }
                            else
                            {
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
                            }                            
                            break;
                        }
                    }
                    
                    azureWorkloadRecoveryConfig.targetPhysicalPath = targetPhysicalPath;
                    azureWorkloadRecoveryConfig.ContainerId = GetContainerId(TargetItem.Id);
                }
                else if (Item != null && TargetItem != null)
                {
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

                    List<WorkloadItemResource> itemResponses;
                    if (targetVaultName != "" && targetResourceGroupName != "")
                    {                        
                        string subscriptionContext = ServiceClientAdapter.BmsAdapter.Client.SubscriptionId;
                        ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = targetSubscriptionId;

                        itemResponses = ServiceClientAdapter.ListWorkloadItem(
                        TargetItem.ContainerName,
                        queryParams,
                        vaultName: targetVaultName,
                        resourceGroupName: targetResourceGroupName);

                        ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = subscriptionContext;
                    }
                    else
                    {
                        itemResponses = ServiceClientAdapter.ListWorkloadItem(
                        TargetItem.ContainerName,
                        queryParams,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                    }

                    foreach (var itemResponse in itemResponses)
                    {
                        if (string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).FriendlyName,
                            ((AzureWorkloadProtectableItem)TargetItem).FriendlyName) == 0 &&
                            string.Compare(((AzureVmWorkloadSQLInstanceWorkloadItem)itemResponse.Properties).ServerName,
                            ((AzureWorkloadProtectableItem)TargetItem).ServerName) == 0)
                        {
                            if (UseSecondaryRegion)
                            {
                                List<CrrModel.SQLDataDirectory> dataDirectory = GetDataDirectoryFromSecondaryRegion(vaultName, resourceGroupName, Item.Id, PointInTime);
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
                            }
                            else
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
                            }
                            break;
                        }
                    }
                    azureWorkloadRecoveryConfig.targetPhysicalPath = targetPhysicalPath;
                    azureWorkloadRecoveryConfig.ContainerId = GetContainerId(TargetItem.Id);
                }
                else if (RestoreAsFiles.IsPresent)
                {
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                    azureWorkloadRecoveryConfig.ContainerId = (TargetContainer as AzureVmWorkloadContainer).Id;
                    azureWorkloadRecoveryConfig.RestoreRequestType = "Alternate WL Restore";
                    azureWorkloadRecoveryConfig.RecoveryMode = "FileRecovery";
                    azureWorkloadRecoveryConfig.FilePath = FilePath;
                    azureWorkloadRecoveryConfig.FullRP = FromFull;
                }

                // Snapshot restore (SQL Instance always, or SQL Database with -RecoveryMode) requires a target
                // resource group and user-assigned managed identity, and surfaces the source volume paths for
                // customer-supplied drive remapping.
                if (isSnapshotRestore)
                {
                    // Target resource group and user-assigned managed identity are required for snapshot
                    // restore (both original and alternate location).
                    if (string.IsNullOrEmpty(TargetResourceGroupName))
                    {
                        throw new ArgumentException(Resources.AzureWorkloadSQLInstanceSnapshotTargetResourceGroupRequired);
                    }
                    if (string.IsNullOrEmpty(UserAssignedIdentityId))
                    {
                        throw new ArgumentException(Resources.AzureWorkloadSQLInstanceSnapshotUserAssignedIdentityRequired);
                    }

                    azureWorkloadRecoveryConfig.TargetResourceGroupName = TargetResourceGroupName;
                    azureWorkloadRecoveryConfig.UserAssignedIdentityId = UserAssignedIdentityId;

                    // SQL Instance snapshot restore targets the instance; the restored name follows the
                    // "*_restored_<timestamp>" pattern, producing a "<targetInstance>/*_restored_<timestamp>"
                    // databaseName (users can override the full value via -TargetInstanceDatabaseName). SQL
                    // Database snapshot restore keeps its restored database name from the classic path.
                    if (isInstance)
                    {
                        string itemSuffix = currentTime.Month.ToString() + "_" + currentTime.Day.ToString() + "_" +
                            currentTime.Year.ToString() + "_" + currentTime.Hour.ToString() + currentTime.Minute.ToString();
                        azureWorkloadRecoveryConfig.RestoredDBName = "*_restored_" + itemSuffix;
                        if (!string.IsNullOrEmpty(TargetInstanceDatabaseName))
                        {
                            azureWorkloadRecoveryConfig.TargetInstanceDatabaseName = TargetInstanceDatabaseName;
                        }
                    }

                    // The portal snapshot-restore experience displays each source volume path from the
                    // recovery point and asks the customer to supply a target path (drive remapping on
                    // filesystem clash). Surface those source volume paths on the returned config with an
                    // empty TargetPath so the user can set the remapping (for both original and alternate
                    // location restore) before piping the config to Restore-AzRecoveryServicesBackupItem.
                    // The recovery point set carries the snapshot RP directly; the point-in-time (log chain)
                    // set fetches it by time from the source item.
                    SnapshotRecoveryPointInfo snapshotRecoveryPointInfo = ParameterSetName == RpParameterSet ?
                        GetSnapshotRecoveryPointInfo(vaultName, resourceGroupName) :
                        GetSnapshotRecoveryPointInfoByTime(vaultName, resourceGroupName, Item.Id, PointInTime);
                    if (snapshotRecoveryPointInfo != null && snapshotRecoveryPointInfo.SourceFilesystemInfo != null)
                    {
                        // "Data" mapping applies to an attach-and-recover restore without a point in time;
                        // every other case (point-in-time or SnapshotAttach) remaps whole volumes as
                        // "DiskDrives". SnapshotAttach omits the source logical name; attach-and-recover
                        // carries the SQL instance name. This is identical for SQL Instance and SQL Database.
                        bool hasPointInTime = PointInTime != default(DateTime);
                        bool isSnapshotAttach = string.Compare(RecoveryMode, "SnapshotAttach") == 0;
                        string mappingType = (!hasPointInTime && !isSnapshotAttach) ? "Data" : "DiskDrives";
                        string sourceLogicalName = isSnapshotAttach ? null : instanceName;

                        List<SQLDataDirectoryMapping> snapshotPhysicalPath = new List<SQLDataDirectoryMapping>();
                        foreach (var filesystemInfo in snapshotRecoveryPointInfo.SourceFilesystemInfo)
                        {
                            if (filesystemInfo.AccessPaths == null)
                            {
                                continue;
                            }
                            foreach (var accessPath in filesystemInfo.AccessPaths)
                            {
                                snapshotPhysicalPath.Add(new SQLDataDirectoryMapping()
                                {
                                    MappingType = mappingType,
                                    SourceLogicalName = sourceLogicalName,
                                    SourcePath = accessPath,
                                    TargetPath = ""
                                });
                            }
                        }
                        azureWorkloadRecoveryConfig.targetPhysicalPath = snapshotPhysicalPath;
                    }
                }

                if (DisksToDetachOnClash != null && DisksToDetachOnClash.Length > 0)
                {
                    azureWorkloadRecoveryConfig.DisksToDetachOnClash = new List<string>(DisksToDetachOnClash);
                }

                // -NoRecoveryMode restores in NORECOVERY state (isNonRecoverable = true) so further restores
                // can be applied. The OLR/ALR branches default this to "Disabled"; honor the switch here.
                if (NoRecoveryMode.IsPresent)
                {
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Enabled";
                }

                // -TargetDirectoryMapping (e.g. @{ all = "C:/temp" }) is applied to targetInfo for SnapshotAttach.
                if (TargetDirectoryMapping != null && TargetDirectoryMapping.Count > 0)
                {
                    Dictionary<string, string> targetDirectoryMapping = new Dictionary<string, string>();
                    foreach (object key in TargetDirectoryMapping.Keys)
                    {
                        targetDirectoryMapping[key.ToString()] = TargetDirectoryMapping[key]?.ToString();
                    }
                    azureWorkloadRecoveryConfig.TargetDirectoryMapping = targetDirectoryMapping;
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
            string newFileName = "";
            if (fileNameParts.Count == 2)
            {
                newFileName = name + "_" + offset.ToString() + "." + fileNameParts[1];
            }
            else
            {
                newFileName = name + "_" + offset.ToString();
            }
            return sqlDataDirectory.Path + newFileName;
        }

        public string GetResourceId()
        {
            try
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier();
                resourceIdentifier.Subscription = ServiceClientAdapter.SubscriptionId;
                resourceIdentifier.ResourceGroupName = RecoveryPoint.ContainerName.Split(new string[] { ";" }, StringSplitOptions.None)[1];
                resourceIdentifier.ResourceType = "Microsoft.Compute/virtualMachines";
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
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BmsrpQueryObject()
            {
                RestorePointQueryType = RestorePointQueryType.Log,
                ExtendedInfo = true
            });

            ODataQuery<BmsrpQueryObject> queryFilter = new ODataQuery<BmsrpQueryObject>();
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

        /// <summary>
        /// Fetches the snapshot recovery point info (per-volume source filesystem metadata) for the point-in-time
        /// (log chain) restore flow, where there is no explicit recovery point. Queries the snapshot recovery
        /// points for the source item and returns the snapshot info from the latest one.
        /// </summary>
        public SnapshotRecoveryPointInfo GetSnapshotRecoveryPointInfoByTime(string vaultName, string resourceGroupName, string itemId, DateTime pointInTime)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(itemId);
            string containerUri = HelperUtils.GetContainerUri(uriDict, itemId);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, itemId);
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BmsrpQueryObject()
            {
                RestorePointQueryType = RestorePointQueryType.Snapshot,
                ExtendedInfo = true
            });

            ODataQuery<BmsrpQueryObject> queryFilter = new ODataQuery<BmsrpQueryObject>();
            queryFilter.Filter = queryFilterString;

            var rpResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            foreach (var rp in rpResponse)
            {
                AzureWorkloadSQLRecoveryPoint sqlRp = rp.Properties as AzureWorkloadSQLRecoveryPoint;
                if (sqlRp != null && sqlRp.ExtendedInfo != null && sqlRp.ExtendedInfo.SnapshotRecoveryPointInfo != null)
                {
                    return sqlRp.ExtendedInfo.SnapshotRecoveryPointInfo;
                }
            }
            return null;
        }

        public List<CrrModel.SQLDataDirectory> GetDataDirectoryFromSecondaryRegion(string vaultName, string resourceGroupName, string itemId, DateTime pointInTime)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(itemId);
            string containerUri = HelperUtils.GetContainerUri(uriDict, itemId);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, itemId);
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BmsrpQueryObject()
            {
                RestorePointQueryType = RestorePointQueryType.Log,
                ExtendedInfo = true
            });

            ODataQuery<CrrModel.BmsrpQueryObject> queryFilter = new ODataQuery<CrrModel.BmsrpQueryObject>();
            queryFilter.Filter = queryFilterString;
                        
            var rpResponse = ServiceClientAdapter.GetRecoveryPointsFromSecondaryRegion(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            List<CrrModel.SQLDataDirectory> dataDirectoryPaths = new List<CrrModel.SQLDataDirectory>();
            
            if (rpResponse[0].Properties.GetType() == typeof(CrrModel.AzureWorkloadSQLPointInTimeRecoveryPoint))
            {
                CrrModel.AzureWorkloadSQLPointInTimeRecoveryPoint recoveryPoint =
                    rpResponse[0].Properties as CrrModel.AzureWorkloadSQLPointInTimeRecoveryPoint;
                if (recoveryPoint.ExtendedInfo != null)
                {
                    foreach(CrrModel.SQLDataDirectory dataDirectoryPath in recoveryPoint.ExtendedInfo.DataDirectoryPaths)
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

            AzureWorkloadSQLRecoveryPoint recoveryPoint = null;

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetails(
            containerUri,
            protectedItemName,
            RecoveryPoint.RecoveryPointId,
            vaultName: vaultName,
            resourceGroupName: resourceGroupName);

            recoveryPoint = rpResponse.Properties as AzureWorkloadSQLRecoveryPoint;
            return recoveryPoint.ExtendedInfo.DataDirectoryPaths;
        }

        /// <summary>
        /// Fetches the snapshot recovery point info (per-volume source filesystem metadata) for the
        /// recovery point. Used to surface the source volume paths that the customer remaps to target
        /// paths during a SQL Instance snapshot restore.
        /// </summary>
        public SnapshotRecoveryPointInfo GetSnapshotRecoveryPointInfo(string vaultName, string resourceGroupName)
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
            return recoveryPoint?.ExtendedInfo?.SnapshotRecoveryPointInfo;
        }

        public IList<CrrModel.SQLDataDirectory> GetRpDetailsFromSecondaryRegion(string vaultName, string resourceGroupName)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(RecoveryPoint.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, RecoveryPoint.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, RecoveryPoint.Id);

            CrrModel.AzureWorkloadSQLRecoveryPoint recoveryPoint = null;

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetailsFromSecondaryRegion(
            containerUri,
            protectedItemName,
            RecoveryPoint.RecoveryPointId,
            vaultName: vaultName,
            resourceGroupName: resourceGroupName);

            recoveryPoint = rpResponse.Properties as CrrModel.AzureWorkloadSQLRecoveryPoint;
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
                    // Item may be a SQL Database or a SQL Instance protected item; resolve server/parent
                    // without an unconditional DB cast (neither type derives from the other).
                    AzureWorkloadSQLInstanceProtectedItem instanceItem = Item as AzureWorkloadSQLInstanceProtectedItem;
                    if (instanceItem != null)
                    {
                        targetServer = instanceItem.ServerName;
                        parentName = instanceItem.ParentName;
                    }
                    else
                    {
                        targetServer = ((AzureWorkloadSQLDatabaseProtectedItem)Item).ServerName;
                        parentName = ((AzureWorkloadSQLDatabaseProtectedItem)Item).ParentName;
                    }
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
            else if (RestoreAsFiles.IsPresent)
            {
                restoreRequestType = "Alternate WL Restore";
                targetServer = TargetContainer.Name;
                if(recoveryPoint == null && FromFull == null)
                {
                    Models.AzureWorkloadRecoveryPoint azureWorkloadRecoveryPoint = new Models.AzureWorkloadRecoveryPoint()
                    {
                        Id = Item.Id + "/recoveryPoints/DefaultRangeRecoveryPoint",
                        RecoveryPointId = "DefaultRangeRecoveryPoint"
                    };
                    recoveryPoint = azureWorkloadRecoveryPoint;
                }
                else if(FromFull != null)
                {
                    recoveryPoint = FromFull;
                }
            }

            return new AzureWorkloadRecoveryConfig(targetServer, parentName, restoreRequestType, recoveryPoint, pointInTime);
        }
    }
}