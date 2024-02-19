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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System;
using System.Collections.Generic;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Conversion helpers.
    /// </summary>
    public class ConversionHelpers
    {
        #region containers

        /// <summary>
        /// Helper function to convert ps backup container model from service response.
        /// </summary>
        public static ContainerBase GetContainerModel(ServiceClientModel.ProtectionContainerResource protectionContainer)
        {
            ContainerBase containerModel = null;

            if (protectionContainer != null &&
                protectionContainer.Properties != null)
            {
                if (protectionContainer.Properties.GetType().IsSubclassOf(typeof(ServiceClientModel.IaaSVMContainer)))
                {
                    containerModel = new AzureVmContainer(protectionContainer);
                }
                else if (protectionContainer.Properties.GetType() == typeof(ServiceClientModel.MabContainer))
                {
                    containerModel = new MabContainer(protectionContainer);
                }
                else if (protectionContainer.Properties.GetType() ==
                    typeof(ServiceClientModel.AzureSqlContainer))
                {
                    containerModel = new AzureSqlContainer(protectionContainer);
                }
                else if (protectionContainer.Properties.GetType() ==
                    typeof(ServiceClientModel.AzureStorageContainer))
                {
                    containerModel = new AzureFileShareContainer(protectionContainer);
                }
                else if (protectionContainer.Properties.GetType() ==
                    typeof(ServiceClientModel.AzureVMAppContainerProtectionContainer))
                {
                    containerModel = new AzureVmWorkloadContainer(protectionContainer);
                }
            }

            return containerModel;
        }

        /// <summary>
        /// Helper function to convert ps backup engine model from service response.
        /// </summary>
        public static BackupEngineBase GetBackupEngineModel(
            ServiceClientModel.BackupEngineBaseResource backupEngine)
        {
            BackupEngineBase backupEngineModel = null;

            if (backupEngine != null &&
                backupEngine.Properties != null)
            {
                string friendlyName = backupEngine.Properties.FriendlyName;
                string backupManagementType =
                    backupEngine.Properties.BackupManagementType.ToString();
                string registrationStatus = backupEngine.Properties.RegistrationStatus;
                string healthStatus = backupEngine.Properties.HealthStatus;
                bool? canReRegister = backupEngine.Properties.CanReRegister;
                string backupEngineId = backupEngine.Properties.BackupEngineId;

                if (backupEngine.Properties.GetType() == (typeof(ServiceClientModel.DpmBackupEngine)))
                {
                    backupEngineModel = new DpmBackupEngine(backupEngine);
                }
                else if (backupEngine.Properties.GetType() == (typeof(ServiceClientModel.AzureBackupServerEngine)))
                {
                    backupEngineModel = new AzureBackupServerEngine(backupEngine);
                }
            }

            return backupEngineModel;
        }

        /// <summary>
        /// Helper function to convert ps backup container model list from service response.
        /// </summary>
        public static List<ContainerBase> GetContainerModelList(IEnumerable<ServiceClientModel.ProtectionContainerResource> protectionContainers)
        {
            List<ContainerBase> containerModels = new List<ContainerBase>();

            foreach (var protectionContainer in protectionContainers)
            {
                containerModels.Add(GetContainerModel(protectionContainer));
            }

            return containerModels;
        }

        /// <summary>
        /// Helper function to convert ps backup engine model list from service response.
        /// </summary>
        public static List<BackupEngineBase> GetBackupEngineModelList(
            IEnumerable<ServiceClientModel.BackupEngineBaseResource> backupEngines)
        {
            List<BackupEngineBase> backupEngineModel = new List<BackupEngineBase>();

            foreach (var backupEngine in backupEngines)
            {
                backupEngineModel.Add(GetBackupEngineModel(backupEngine));
            }

            return backupEngineModel;
        }

        #endregion

        #region policy

        /// <summary>
        /// Helper function to convert ps backup policy model for AzureVM from service response.
        /// </summary>
        public static PolicyBase GetPolicyModelForAzureIaaSVM(ServiceClientModel.ProtectionPolicyResource serviceClientResponse,
           PolicyBase policyModel)
        {
            string backupManagementType = Management.RecoveryServices.Backup.Models.BackupManagementType.AzureIaasVM;
            if (((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).RetentionPolicy.GetType() !=
                                                                       typeof(ServiceClientModel.LongTermRetentionPolicy))
            {
                Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                           ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).RetentionPolicy.GetType());
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }

            Type schedulePolicyType = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).SchedulePolicy.GetType();            
            if (schedulePolicyType != typeof(ServiceClientModel.SimpleSchedulePolicy) && schedulePolicyType != typeof(ServiceClientModel.SimpleSchedulePolicyV2))
            {
                Logger.Instance.WriteDebug("Unknown SchedulePolicy object received: " + schedulePolicyType);                           
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }
            
            policyModel = new AzureVmPolicy();
            AzureVmPolicy iaasPolicyModel = policyModel as AzureVmPolicy;
            iaasPolicyModel.WorkloadType = WorkloadType.AzureVM;
            iaasPolicyModel.BackupManagementType = BackupManagementType.AzureVM;
            iaasPolicyModel.SnapshotRetentionInDays = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.
                Properties).InstantRpRetentionRangeInDays;

            string policyType = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).PolicyType;
            iaasPolicyModel.PolicySubType = (policyType != null && policyType.ToLower().Contains("v2")) ? PSPolicyType.Enhanced : PSPolicyType.Standard;
            iaasPolicyModel.ProtectedItemsCount = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.
                Properties).ProtectedItemsCount;
            iaasPolicyModel.RetentionPolicy = PolicyHelpers.GetPSLongTermRetentionPolicy((ServiceClientModel.LongTermRetentionPolicy)
                                              ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).RetentionPolicy,
                                              ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TimeZone,
                                              backupManagementType);
            
            if (schedulePolicyType == typeof(ServiceClientModel.SimpleSchedulePolicyV2))
            {
                iaasPolicyModel.SchedulePolicy = PolicyHelpers.GetPSSimpleSchedulePolicyV2((ServiceClientModel.SimpleSchedulePolicyV2)
                                             ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).SchedulePolicy,
                                             ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TimeZone);
            }
            else
            {
                iaasPolicyModel.SchedulePolicy = PolicyHelpers.GetPSSimpleSchedulePolicy((ServiceClientModel.SimpleSchedulePolicy)
                                             ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).SchedulePolicy,
                                             ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TimeZone);
            }
            
            iaasPolicyModel.AzureBackupRGName = 
                ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).InstantRpDetails.AzureBackupRgNamePrefix;
            iaasPolicyModel.AzureBackupRGNameSuffix = 
                ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).InstantRpDetails.AzureBackupRgNameSuffix;
            iaasPolicyModel.SnapshotConsistencyType =
                ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).SnapshotConsistencyType;

            // fetch the smart tiering details          
            if (((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TieringPolicy != null &&
                ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TieringPolicy.ContainsKey(ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()))
            {
                iaasPolicyModel.TieringPolicy = new TieringPolicy();

                string tieringMode = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TieringPolicy[ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()].TieringMode;

                iaasPolicyModel.TieringPolicy.TieringMode = (tieringMode == "TierRecommended") ? TieringMode.TierRecommended : ((tieringMode == "TierAfter") ? TieringMode.TierAllEligible : ((tieringMode == "DoNotTier") ? TieringMode.DoNotTier : 0));

                iaasPolicyModel.TieringPolicy.TierAfterDuration = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TieringPolicy[ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()].Duration;

                iaasPolicyModel.TieringPolicy.TierAfterDurationType = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).TieringPolicy[ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()].DurationType;
            }

            return policyModel;
        }

        /// <summary>
        /// Helper function to convert ps backup policy model for AzureSql from service response.
        /// </summary>
        public static PolicyBase GetPolicyModelForAzureSql(ServiceClientModel.ProtectionPolicyResource serviceClientResponse,
           PolicyBase policyModel)
        {
            ServiceClientModel.AzureSqlProtectionPolicy azureSqlPolicy =
                    (ServiceClientModel.AzureSqlProtectionPolicy)serviceClientResponse.Properties;

            if (azureSqlPolicy.RetentionPolicy.GetType() !=
                typeof(ServiceClientModel.SimpleRetentionPolicy))
            {
                Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                    azureSqlPolicy.RetentionPolicy.GetType());
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }

            policyModel = new AzureSqlPolicy();
            AzureSqlPolicy sqlPolicyModel = policyModel as AzureSqlPolicy;
            sqlPolicyModel.WorkloadType = WorkloadType.AzureSQLDatabase;
            sqlPolicyModel.BackupManagementType = BackupManagementType.AzureSQL;

            ServiceClientModel.SimpleRetentionPolicy azureSqlRetentionPolicy =
                (ServiceClientModel.SimpleRetentionPolicy)azureSqlPolicy.RetentionPolicy;
            sqlPolicyModel.RetentionPolicy =
                PolicyHelpers.GetPSSimpleRetentionPolicy(azureSqlRetentionPolicy, null, "AzureSql");
            return policyModel;
        }

        /// <summary>
        /// Helper function to convert ps backup policy model for Azure FileShare from service response.
        /// </summary>
        public static PolicyBase GetPolicyModelForAzureFileShare(ServiceClientModel.ProtectionPolicyResource serviceClientResponse,
           PolicyBase policyModel)
        {
            string backupManagementType = Management.RecoveryServices.Backup.Models.BackupManagementType.AzureStorage;
            ServiceClientModel.AzureFileShareProtectionPolicy azureFileSharePolicy =
                    (ServiceClientModel.AzureFileShareProtectionPolicy)serviceClientResponse.Properties;

            if (azureFileSharePolicy.RetentionPolicy != null && azureFileSharePolicy.RetentionPolicy.GetType() !=
                typeof(ServiceClientModel.LongTermRetentionPolicy))
            {
                Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                    azureFileSharePolicy.RetentionPolicy.GetType());
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }

            if (azureFileSharePolicy.SchedulePolicy.GetType() !=
                typeof(ServiceClientModel.SimpleSchedulePolicy))
            {
                Logger.Instance.WriteDebug("Unknown SchedulePolicy object received: " +
                    azureFileSharePolicy.SchedulePolicy.GetType());
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }

            policyModel = new AzureFileSharePolicy();
            AzureFileSharePolicy fileSharePolicyModel = policyModel as AzureFileSharePolicy;
            fileSharePolicyModel.WorkloadType = WorkloadType.AzureFiles;
            fileSharePolicyModel.BackupManagementType = BackupManagementType.AzureStorage;

            if(azureFileSharePolicy.RetentionPolicy != null)
            {
                fileSharePolicyModel.RetentionPolicy =
                PolicyHelpers.GetPSLongTermRetentionPolicy((ServiceClientModel.LongTermRetentionPolicy)((ServiceClientModel.AzureFileShareProtectionPolicy)serviceClientResponse.Properties).RetentionPolicy,
                  ((ServiceClientModel.AzureFileShareProtectionPolicy)serviceClientResponse.Properties).TimeZone, backupManagementType);
            }
            
            fileSharePolicyModel.SchedulePolicy =
                PolicyHelpers.GetPSSimpleSchedulePolicy((ServiceClientModel.SimpleSchedulePolicy)
                 ((ServiceClientModel.AzureFileShareProtectionPolicy)serviceClientResponse.Properties).SchedulePolicy,
                 ((ServiceClientModel.AzureFileShareProtectionPolicy)serviceClientResponse.Properties).TimeZone);
            fileSharePolicyModel.ProtectedItemsCount = ((ServiceClientModel.AzureFileShareProtectionPolicy)serviceClientResponse.
                Properties).ProtectedItemsCount;            
            return policyModel;
        }

        public static PolicyBase GetPolicyModelForAzureVmWorkload(ServiceClientModel.ProtectionPolicyResource serviceClientResponse,
           PolicyBase policyModel)
        {
            ServiceClientModel.AzureVmWorkloadProtectionPolicy azureVmWorkloadPolicy =
                    (ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties;

            foreach (var policy in azureVmWorkloadPolicy.SubProtectionPolicy)
            {
                if (string.Compare(policy.PolicyType, "Full") == 0)
                {
                    if (policy.SchedulePolicy.GetType() !=
                        typeof(ServiceClientModel.SimpleSchedulePolicy))
                    {
                        Logger.Instance.WriteDebug("Unknown Schedule object received: " +
                            policy.SchedulePolicy.GetType());
                        Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                        return null;
                    }
                    if (policy.RetentionPolicy.GetType() !=
                        typeof(ServiceClientModel.LongTermRetentionPolicy))
                    {
                        Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                            policy.RetentionPolicy.GetType());
                        Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                        return null;
                    }                    
                }
                else if (string.Compare(policy.PolicyType, "Differential") == 0)
                {
                    if (policy.SchedulePolicy.GetType() !=
                        typeof(ServiceClientModel.SimpleSchedulePolicy))
                    {
                        Logger.Instance.WriteDebug("Unknown Schedule object received: " +
                            policy.SchedulePolicy.GetType());
                        Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                        return null;
                    }
                    if (policy.RetentionPolicy.GetType() !=
                        typeof(ServiceClientModel.SimpleRetentionPolicy))
                    {
                        Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                            policy.RetentionPolicy.GetType());
                        Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                        return null;
                    }
                }
                else if (string.Compare(policy.PolicyType, "Log") == 0)
                {
                    if (policy.SchedulePolicy.GetType() !=
                        typeof(ServiceClientModel.LogSchedulePolicy))
                    {
                        Logger.Instance.WriteDebug("Unknown Schedule object received: " +
                            policy.SchedulePolicy.GetType());
                        Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                        return null;
                    }
                    if (policy.RetentionPolicy.GetType() !=
                        typeof(ServiceClientModel.SimpleRetentionPolicy))
                    {
                        Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                            policy.RetentionPolicy.GetType());
                        Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                        return null;
                    }
                }
            }

            policyModel = new AzureVmWorkloadPolicy();
            AzureVmWorkloadPolicy azureVmWorkloadPolicyModel = policyModel as AzureVmWorkloadPolicy;
            azureVmWorkloadPolicyModel.WorkloadType = WorkloadType.MSSQL;
            azureVmWorkloadPolicyModel.BackupManagementType = BackupManagementType.AzureWorkload;
            azureVmWorkloadPolicyModel.IsCompression =
                ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.IsCompression;
            azureVmWorkloadPolicyModel.IsDifferentialBackupEnabled = false;
            azureVmWorkloadPolicyModel.IsLogBackupEnabled = false;
            GetPSSubProtectionPolicy(azureVmWorkloadPolicyModel, serviceClientResponse,
                ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.TimeZone);
            azureVmWorkloadPolicyModel.ProtectedItemsCount = ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.
                Properties).ProtectedItemsCount;
                        
            return policyModel;
        }

        /// <summary>
        /// Helper function to convert ps backup policy model from service response.
        /// </summary>
        public static PolicyBase GetPolicyModel(ServiceClientModel.ProtectionPolicyResource serviceClientResponse)
        {
            PolicyBase policyModel = null;

            if (serviceClientResponse == null || serviceClientResponse.Properties == null)
            {
                Logger.Instance.WriteDebug("Policy Service Client response is Null/Empty");
                throw new ArgumentException(Resources.EmptyServiceClientResponseException);
            }

            if (serviceClientResponse.Properties.GetType() == typeof(ServiceClientModel.AzureIaaSVMProtectionPolicy))
            {
                policyModel = GetPolicyModelForAzureIaaSVM(serviceClientResponse, policyModel);
            }
            else if (serviceClientResponse.Properties.GetType() ==
                typeof(ServiceClientModel.AzureSqlProtectionPolicy))
            {
                policyModel = GetPolicyModelForAzureSql(serviceClientResponse, policyModel);
            }
            else if (serviceClientResponse.Properties.GetType() ==
                typeof(ServiceClientModel.AzureFileShareProtectionPolicy))
            {   
                policyModel = GetPolicyModelForAzureFileShare(serviceClientResponse, policyModel);
            }
            else if (serviceClientResponse.Properties.GetType() ==
                typeof(ServiceClientModel.AzureVmWorkloadProtectionPolicy))
            {
                policyModel = GetPolicyModelForAzureVmWorkload(serviceClientResponse, policyModel);
            }
            else
            {
                // we will enter this case when service supports new workload and customer 
                // still using old version of azure powershell. Trace warning message, ignore and return
                Logger.Instance.WriteDebug("Unknown Policy object received: " +
                                           serviceClientResponse.Properties.GetType());
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }

            if (policyModel != null)
            {
                policyModel.Name = serviceClientResponse.Name;
                policyModel.Id = serviceClientResponse.Id;
            }
            else
            {
                Logger.Instance.WriteWarning("couldn't fetch policy model for one of the listed policies, skipping");
            }

            return policyModel;
        }

        /// <summary>
        /// Helper function to convert ps backup policy list model from service response.
        /// </summary>
        public static List<PolicyBase> GetPolicyModelList(
            List<ServiceClientModel.ProtectionPolicyResource> serviceClientListResponse)
        {
            if (serviceClientListResponse == null && serviceClientListResponse.Count == 0)
            {
                Logger.Instance.WriteDebug("Received empty list of policies from service");
                return null;
            }

            List<PolicyBase> policyModels = new List<PolicyBase>();
            PolicyBase policyModel = null;

            foreach (ServiceClientModel.ProtectionPolicyResource resource
                in serviceClientListResponse)
            {
                policyModel = GetPolicyModel(resource);
                if (policyModel != null)
                {
                    policyModels.Add(policyModel);
                }
            }

            Logger.Instance.WriteDebug("Total policies in list: " + policyModels.Count);
            return policyModels;
        }

        #endregion

        #region Item

        /// <summary>
        /// Helper function to convert ps backup policy item from service response.
        /// </summary>
        public static ItemBase GetItemModel(ServiceClientModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel = null;

            if (protectedItem != null &&
                protectedItem.Properties != null)
            {
                if (protectedItem.Properties.GetType().IsSubclassOf(typeof(ServiceClientModel.AzureIaaSVMProtectedItem)))
                {
                    itemModel = GetAzureVmItemModel(protectedItem);
                }

                if (protectedItem.Properties.GetType() ==
                    typeof(ServiceClientModel.AzureSqlProtectedItem))
                {
                    itemModel = GetAzureSqlItemModel(protectedItem);
                }

                if (protectedItem.Properties.GetType() ==
                    typeof(ServiceClientModel.AzureFileshareProtectedItem))
                {
                    itemModel = GetAzureFileShareItemModel(protectedItem);
                }

                if (protectedItem.Properties.GetType() == 
                    typeof(ServiceClientModel.AzureVmWorkloadSQLDatabaseProtectedItem))
                {
                    itemModel = GetAzureVmWorkloadItemModel(protectedItem);
                }

                if (protectedItem.Properties.GetType() == 
                    typeof(ServiceClientModel.AzureVmWorkloadSAPHanaDatabaseProtectedItem))
                {
                    itemModel = GetAzureVmWorkloadSAPHanaItemModel(protectedItem);
                }

                if (protectedItem.Properties.GetType() ==
                    typeof(ServiceClientModel.MabFileFolderProtectedItem))
                {
                    itemModel = GetMabItemModel(protectedItem);
                }
            }

            return itemModel;
        }

        /// <summary>
        /// Helper function to convert ps backup item from service response.
        /// </summary>
        public static ItemBase GetItemModelCrr(CrrModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel = null;

            if (protectedItem != null &&
                protectedItem.Properties != null)
            {
                if (protectedItem.Properties.GetType().IsSubclassOf(typeof(CrrModel.AzureIaaSVMProtectedItem)))
                {
                    itemModel = GetAzureVmItemModelCrr(protectedItem);
                }

                /*if (protectedItem.Properties.GetType() ==
                    typeof(CrrModel.AzureFileshareProtectedItem))
                {
                    itemModel = GetAzureFileShareItemModel(protectedItem);
                }*/

                if (protectedItem.Properties.GetType() ==
                    typeof(CrrModel.AzureVmWorkloadSQLDatabaseProtectedItem))
                {
                    itemModel = GetAzureVmWorkloadItemModelCrr(protectedItem);
                }

                if (protectedItem.Properties.GetType() ==
                    typeof(CrrModel.AzureVmWorkloadSAPHanaDatabaseProtectedItem))
                {
                    itemModel = GetAzureVmWorkloadSAPHanaItemModelCrr(protectedItem);
                }

                /*if (protectedItem.Properties.GetType() ==
                    typeof(CrrModel.MabFileFolderProtectedItem))
                {
                    itemModel = GetMabItemModel(protectedItem);
                }*/
            }
            return itemModel;
        }

        private static ItemBase GetAzureVmWorkloadItemModel(ServiceClientModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            string policyName = null;
            string policyId = ((ServiceClientModel.AzureVmWorkloadSQLDatabaseProtectedItem)protectedItem.Properties).PolicyId;
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyValueDict =
                HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);

            itemModel = new AzureWorkloadSQLDatabaseProtectedItem(
                protectedItem,
                containerUri,
                ContainerType.AzureVMAppContainer,
                policyName);
            return itemModel;
        }

        private static ItemBase GetAzureVmWorkloadItemModelCrr(CrrModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            string policyName = null;
            string policyId = ((CrrModel.AzureVmWorkloadSQLDatabaseProtectedItem)protectedItem.Properties).PolicyId;
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);
            itemModel = new AzureWorkloadSQLDatabaseProtectedItem(
                protectedItem,
                containerUri,
                ContainerType.AzureVMAppContainer,
                policyName);
            return itemModel;
        }


        private static ItemBase GetAzureVmWorkloadSAPHanaItemModel(ServiceClientModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            string policyName = null;
            // can try changing it to AzureVmWorkloadProtectedItem
            string policyId = ((ServiceClientModel.AzureVmWorkloadSAPHanaDatabaseProtectedItem)protectedItem.Properties).PolicyId;
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);            

            itemModel = new AzureWorkloadSAPHanaDatabaseProtectedItem(
                protectedItem,
                containerUri,
                ContainerType.AzureVMAppContainer,
                policyName);            

            return itemModel;
        }

        private static ItemBase GetAzureVmWorkloadSAPHanaItemModelCrr(CrrModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            string policyName = null;

            // can also be type-casted to AzureVmWorkloadProtectedItem
            string policyId = ((CrrModel.AzureVmWorkloadSAPHanaDatabaseProtectedItem)protectedItem.Properties).PolicyId;
            
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);

            itemModel = new AzureWorkloadSAPHanaDatabaseProtectedItem(
                protectedItem,
                containerUri,
                ContainerType.AzureVMAppContainer,
                policyName);

            return itemModel;
        }

        private static ItemBase GetAzureFileShareItemModel(ServiceClientModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            string policyName = null;
            string policyId = ((ServiceClientModel.AzureFileshareProtectedItem)protectedItem.Properties).PolicyId;
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyValueDict =
                HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);

            itemModel = new AzureFileShareItem(
                protectedItem,
                containerUri,
                ContainerType.AzureStorage,
                policyName);
            return itemModel;
        }

        private static ItemBase GetMabItemModel(ServiceClientModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;

            string containerUri = (protectedItem.Properties as ServiceClientModel.MabFileFolderProtectedItem).ContainerName;

            itemModel = new MabItem(
                protectedItem,
                containerUri,
                ContainerType.Windows,
                null);
            return itemModel;
        }

        private static ItemBase GetAzureSqlItemModel(ServiceClientModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            ServiceClientModel.AzureSqlProtectedItem azureSqlProtectedItem =
                  (ServiceClientModel.AzureSqlProtectedItem)protectedItem.Properties;
            string policyName = null;
            string policyId = azureSqlProtectedItem.PolicyId;
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyVauleDict =
                HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyVauleDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);

            itemModel = new AzureSqlItem(
                protectedItem,
                IdUtils.GetNameFromUri(containerUri),
                ContainerType.AzureSQL,
                policyName);
            return itemModel;
        }

        private static ItemBase GetAzureVmItemModel(ServiceClientModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            string policyName = null;
            string policyId = ((ServiceClientModel.AzureIaaSVMProtectedItem)protectedItem.Properties).PolicyId;
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyValueDict =
                HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);

            itemModel = new AzureVmItem(
                protectedItem,
                IdUtils.GetNameFromUri(containerUri),
                ContainerType.AzureVM,
                policyName);
            return itemModel;
        }

        private static ItemBase GetAzureVmItemModelCrr(CrrModel.ProtectedItemResource protectedItem)
        {
            ItemBase itemModel;
            string policyName = null;
            string policyId = ((CrrModel.AzureIaaSVMProtectedItem)protectedItem.Properties).PolicyId;
            if (!string.IsNullOrEmpty(policyId))
            {
                Dictionary<UriEnums, string> keyValueDict =
                HelperUtils.ParseUri(policyId);
                policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
            }

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectedItem.Id),
                protectedItem.Id);

            itemModel = new AzureVmItem(
                protectedItem,
                IdUtils.GetNameFromUri(containerUri),
                ContainerType.AzureVM,
                policyName);

            return itemModel;
        }

        /// <summary>
        /// Helper function to convert ps protectable item from service response.
        /// </summary>
        public static ProtectableItemBase GetProtectableItemModel(ServiceClientModel.WorkloadProtectableItemResource protectableItem)
        {
            ProtectableItemBase itemModel = null;

            if (protectableItem != null &&
                protectableItem.Properties != null)
            {
                if (protectableItem.Properties.GetType().IsSubclassOf(typeof(ServiceClientModel.AzureVmWorkloadProtectableItem)))
                {
                    itemModel = GetAzureWorkloadProtectableItemModel(protectableItem);
                }
            }

            return itemModel;
        }

        private static ProtectableItemBase GetAzureWorkloadProtectableItemModel(ServiceClientModel.WorkloadProtectableItemResource protectableItem)
        {
            ProtectableItemBase itemModel;

            string containerUri = HelperUtils.GetContainerUri(
                HelperUtils.ParseUri(protectableItem.Id),
                protectableItem.Id);

            itemModel = new AzureWorkloadProtectableItem(
                protectableItem,
                containerUri,
                ContainerType.AzureVMAppContainer);

            return itemModel;
        }

        /// <summary>
        /// Helper function to convert ps item list from service response.
        /// </summary>
        public static List<ItemBase> GetItemModelList(IEnumerable<ServiceClientModel.ProtectedItemResource> protectedItems)
        {
            List<ItemBase> itemModels = new List<ItemBase>();

            foreach (var protectedItem in protectedItems)
            {
                itemModels.Add(GetItemModel(protectedItem));                
            }

            return itemModels;
        }

        /// <summary>
        /// Helper function to convert ps item list from service response.
        /// </summary>
        public static List<ItemBase> GetItemModelListCrr(IEnumerable<CrrModel.ProtectedItemResource> protectedItems)
        {
            List<ItemBase> itemModels = new List<ItemBase>();
            foreach (var protectedItem in protectedItems)
            {
                itemModels.Add(GetItemModelCrr(protectedItem));
            }    
            return itemModels;
        }

        public static void GetPSSubProtectionPolicy(AzureVmWorkloadPolicy azureVmWorkloadPolicyModel,
           ServiceClientModel.ProtectionPolicyResource serviceClientResponse, string timeZone)
        {
            foreach (var subProtectionPolicy in
                ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).SubProtectionPolicy)
            {
                if (string.Compare(subProtectionPolicy.PolicyType, "Full") == 0)
                {
                    azureVmWorkloadPolicyModel.FullBackupSchedulePolicy = PolicyHelpers.GetPSSimpleSchedulePolicy(
                        (ServiceClientModel.SimpleSchedulePolicy)subProtectionPolicy.SchedulePolicy,
                        ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.TimeZone);

                    azureVmWorkloadPolicyModel.FullBackupRetentionPolicy = PolicyHelpers.GetPSLongTermRetentionPolicy(
                        (ServiceClientModel.LongTermRetentionPolicy)subProtectionPolicy.RetentionPolicy,
                        ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.TimeZone);

                    // fetch the smart tiering details            
                    if (subProtectionPolicy.TieringPolicy != null &&
                        subProtectionPolicy.TieringPolicy.ContainsKey(ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()))
                    {
                        azureVmWorkloadPolicyModel.FullBackupTieringPolicy = new TieringPolicy();

                        string tieringMode = subProtectionPolicy.TieringPolicy[ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()].TieringMode;

                        azureVmWorkloadPolicyModel.FullBackupTieringPolicy.TieringMode = (tieringMode == "TierRecommended") ? TieringMode.TierRecommended : ((tieringMode == "TierAfter") ? TieringMode.TierAllEligible : ((tieringMode == "DoNotTier") ? TieringMode.DoNotTier : 0));

                        azureVmWorkloadPolicyModel.FullBackupTieringPolicy.TierAfterDuration = subProtectionPolicy.TieringPolicy[ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()].Duration;

                        azureVmWorkloadPolicyModel.FullBackupTieringPolicy.TierAfterDurationType = subProtectionPolicy.TieringPolicy[ServiceClientModel.RecoveryPointTierType.ArchivedRP.ToString()].DurationType;
                    }
                }
                else if (string.Compare(subProtectionPolicy.PolicyType, "Differential") == 0)
                {
                    azureVmWorkloadPolicyModel.DifferentialBackupSchedulePolicy = PolicyHelpers.GetPSSimpleSchedulePolicy(
                        (ServiceClientModel.SimpleSchedulePolicy)subProtectionPolicy.SchedulePolicy,
                        ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.TimeZone);
                    azureVmWorkloadPolicyModel.DifferentialBackupRetentionPolicy = PolicyHelpers.GetPSSimpleRetentionPolicy(
                        (ServiceClientModel.SimpleRetentionPolicy)subProtectionPolicy.RetentionPolicy,
                        ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.TimeZone, "AzureWorkload");
                    azureVmWorkloadPolicyModel.IsDifferentialBackupEnabled = true;
                }
                else if (string.Compare(subProtectionPolicy.PolicyType, "Log") == 0)
                {
                    // timeZone paased as input but not used in below method calls
                    azureVmWorkloadPolicyModel.LogBackupSchedulePolicy = PolicyHelpers.GetPSLogSchedulePolicy((ServiceClientModel.LogSchedulePolicy)
                    subProtectionPolicy.SchedulePolicy,
                    ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.TimeZone);
                    azureVmWorkloadPolicyModel.LogBackupRetentionPolicy = PolicyHelpers.GetPSSimpleRetentionPolicy((ServiceClientModel.SimpleRetentionPolicy)
                    subProtectionPolicy.RetentionPolicy,
                    ((ServiceClientModel.AzureVmWorkloadProtectionPolicy)serviceClientResponse.Properties).Settings.TimeZone, "AzureWorkload");
                    azureVmWorkloadPolicyModel.IsLogBackupEnabled = true;
                }
            }
        }

        /// <summary>
        /// Helper function to convert ps protectable item list from service response.
        /// </summary>
        public static List<ProtectableItemBase> GetProtectableItemModelList(IEnumerable<ServiceClientModel.WorkloadProtectableItemResource> protectableItems)
        {
            List<ProtectableItemBase> itemModels = new List<ProtectableItemBase>();

            foreach (var protectableItem in protectableItems)
            {                
                itemModels.Add(GetProtectableItemModel(protectableItem));
            }

            return itemModels;
        }
        #endregion
    }
}
