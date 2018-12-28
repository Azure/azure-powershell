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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Restores an item using the recovery point provided within the recovery services vault
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupWorkloadRecoveryConfig",
        DefaultParameterSetName = RpParameterSet, SupportsShouldProcess = true), OutputType(typeof(RecoveryConfigBase))]
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
        /// Protected Item object for which recovery points need to be fetched
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, Position = 1,
            HelpMessage = ParamHelpMsgs.RecoveryPointConfig.TargetItem)]
        [ValidateNotNullOrEmpty]
        public ItemBase TargetItem { get; set; }

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

                AzureWorkloadRecoveryConfig azureWorkloadRecoveryConfig = new AzureWorkloadRecoveryConfig();
                azureWorkloadRecoveryConfig.SourceResourceId = Item != null ? Item.SourceResourceId : GetResourceId();
                DateTime currentTime = DateTime.Now.ToUniversalTime();
                TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
                int offset = (int)timeSpan.TotalSeconds;

                if (ParameterSetName == RpParameterSet)
                {
                    azureWorkloadRecoveryConfig.RecoveryPoint = RecoveryPoint;
                }
                else
                {
                    azureWorkloadRecoveryConfig.PointInTime = PointInTime;
                }
                if (OriginalWorkloadRestore.IsPresent)
                {
                    azureWorkloadRecoveryConfig.RestoreRequestType = "Original WL Restore";
                    azureWorkloadRecoveryConfig.TargetServer = null;
                    azureWorkloadRecoveryConfig.TargetInstance = null;
                    azureWorkloadRecoveryConfig.RestoredDBName = null;
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                }
                else if (AlternateWorkloadRestore.IsPresent)
                {
                    azureWorkloadRecoveryConfig.RestoreRequestType = "Alternate WL Restore";
                    azureWorkloadRecoveryConfig.TargetServer = ((AzureWorkloadSQLDatabaseProtectedItem)TargetItem).ServerName;
                    azureWorkloadRecoveryConfig.TargetInstance = ((AzureWorkloadSQLDatabaseProtectedItem)TargetItem).ParentName;
                    azureWorkloadRecoveryConfig.RestoredDBName =
                    GetRestoredDBName(((AzureWorkloadSQLDatabaseProtectedItem)TargetItem).ParentName, RecoveryPoint.ItemName, currentTime);
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                    List<SQLDataDirectoryMapping> targetPhysicalPath = new List<SQLDataDirectoryMapping>();

                    RecoveryPointBase rpDetails = GetRpDetails(vaultName, resourceGroupName);
                    foreach (var dataDirectoryPath in ((Models.AzureWorkloadRecoveryPoint)rpDetails).DataDirectoryPaths)
                    {
                        targetPhysicalPath.Add(new SQLDataDirectoryMapping()
                        {
                            MappingType = dataDirectoryPath.Type,
                            SourceLogicalName = dataDirectoryPath.LogicalName,
                            SourcePath = dataDirectoryPath.Path,
                            TargetPath = GetTargetPath(dataDirectoryPath.Path, dataDirectoryPath.LogicalName, offset)
                        });
                    }
                    azureWorkloadRecoveryConfig.targetPhysicalPath = targetPhysicalPath;
                    azureWorkloadRecoveryConfig.ContainerId = GetContainerId(TargetItem.Id);
                }
                else if (Item != null && TargetItem != null)
                {
                    azureWorkloadRecoveryConfig.RestoreRequestType = "Alternate WL Restore to diff item";
                    azureWorkloadRecoveryConfig.TargetServer = ((AzureWorkloadSQLDatabaseProtectedItem)TargetItem).ServerName;
                    azureWorkloadRecoveryConfig.TargetInstance = ((AzureWorkloadSQLDatabaseProtectedItem)TargetItem).ParentName;
                    azureWorkloadRecoveryConfig.RestoredDBName =
                    GetRestoredDBName(((AzureWorkloadSQLDatabaseProtectedItem)TargetItem).ParentName, RecoveryPoint.ItemName, currentTime);
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                    List<SQLDataDirectoryMapping> targetPhysicalPath = new List<SQLDataDirectoryMapping>();

                    RecoveryPointBase rpDetails = GetRpDetails(vaultName, resourceGroupName);
                    foreach (var dataDirectoryPath in ((Models.AzureWorkloadRecoveryPoint)rpDetails).DataDirectoryPaths)
                    {
                        targetPhysicalPath.Add(new SQLDataDirectoryMapping()
                        {
                            MappingType = dataDirectoryPath.Type,
                            SourceLogicalName = dataDirectoryPath.LogicalName,
                            SourcePath = dataDirectoryPath.Path,
                            TargetPath = GetTargetPath(dataDirectoryPath.Path, dataDirectoryPath.LogicalName, offset)
                        });
                    }
                    azureWorkloadRecoveryConfig.targetPhysicalPath = targetPhysicalPath;
                    azureWorkloadRecoveryConfig.ContainerId = GetContainerId(TargetItem.Id);
                }
                RecoveryConfigBase baseobj = azureWorkloadRecoveryConfig;
                WriteObject(baseobj);
            });
        }

        public string GetTargetPath(string path, string name, int offset)
        {
            List<string> parts = new List<string>(path.Split(new string[] { "\\" }, StringSplitOptions.None));
            int len = parts.Count();
            parts[len - 1] = name + "_" + offset.ToString() + parts[len - 1].Substring(parts[len - 1].Length - 4);
            return string.Join("\\", parts);
        }

        public string GetResourceId()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier();
            resourceIdentifier.Subscription = ServiceClientAdapter.SubscriptionId;
            resourceIdentifier.ResourceGroupName = RecoveryPoint.ContainerName.Split(new string[] { ";" }, StringSplitOptions.None)[1];
            resourceIdentifier.ResourceType = "/VMAppContainer";
            resourceIdentifier.ResourceName = RecoveryPoint.ContainerName.Split(new string[] { ";" }, StringSplitOptions.None)[2];
            return resourceIdentifier.ToString();
        }

        public string GetContainerId(string itemId)
        {
            string[] split = itemId.Split(new string[] { "/" }, StringSplitOptions.None);
            return string.Join("/", split.ToList().GetRange(0, split.Length - 2));
        }

        public RecoveryPointBase GetRpDetails(string vaultName, string resourceGroupName)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(TargetItem.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, TargetItem.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, TargetItem.Id);

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetails(
                containerUri,
                protectedItemName,
                RecoveryPoint.RecoveryPointId,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, TargetItem);
        }

        public string GetRestoredDBName(string parentName, string itemName, DateTime currentTime)
        {
            List<string> nameList = new List<string>(itemName.Split(new string[] { ";" }, StringSplitOptions.None));

            string itemSuffix = currentTime.Month.ToString() + currentTime.Month.ToString() + "_" + currentTime.Month.ToString() + "_" +
                currentTime.Year.ToString() + "_" + currentTime.Hour.ToString() + currentTime.Minute.ToString();

            return parentName + "/" + nameList.Last() + "_restored_" + itemSuffix;
        }
    }
}