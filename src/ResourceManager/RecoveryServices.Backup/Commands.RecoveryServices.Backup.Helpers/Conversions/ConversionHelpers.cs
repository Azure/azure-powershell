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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using CmdletModels = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

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
                if (protectionContainer.Properties.GetType().IsSubclassOf(typeof(ServiceClientModel.AzureIaaSVMProtectionContainer)))
                {
                    containerModel = new AzureVmContainer(protectionContainer);
                }
                if (protectionContainer.Properties.GetType() == typeof(ServiceClientModel.MabProtectionContainer))
                {
                    containerModel = new MabContainer(protectionContainer);
                }
                else if (protectionContainer.Properties.GetType() ==
                    typeof(ServiceClientModel.AzureSqlProtectionContainer))
                {
                    containerModel = new AzureSqlContainer(protectionContainer);
                }
            }

            return containerModel;
        }

        /// <summary>
        /// Helper function to convert ps backup engine model from service response.
        /// </summary>
        public static BackupEngineBase GetBackupEngineModel(ServiceClientModel.BackupEngineResource backupEngine)
        {
            BackupEngineBase backupEngineModel = null;

            if (backupEngine != null &&
                backupEngine.Properties != null)
            {
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
        public static List<BackupEngineBase> GetBackupEngineModelList(IEnumerable<ServiceClientModel.BackupEngineResource> backupEngines)
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
                if (((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).RetentionPolicy.GetType() !=
                                                                           typeof(ServiceClientModel.LongTermRetentionPolicy))
                {
                    Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                               ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).RetentionPolicy.GetType());
                    Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                    return null;
                }

                if (((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).SchedulePolicy.GetType() !=
                                                                            typeof(ServiceClientModel.SimpleSchedulePolicy))
                {
                    Logger.Instance.WriteDebug("Unknown SchedulePolicy object received: " +
                               ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).SchedulePolicy.GetType());
                    Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                    return null;
                }

                policyModel = new AzureVmPolicy();
                AzureVmPolicy iaasPolicyModel = policyModel as AzureVmPolicy;
                iaasPolicyModel.WorkloadType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM;
                iaasPolicyModel.BackupManagementType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.BackupManagementType.AzureVM;
                iaasPolicyModel.RetentionPolicy = PolicyHelpers.GetPSLongTermRetentionPolicy((ServiceClientModel.LongTermRetentionPolicy)
                                                  ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).RetentionPolicy);
                iaasPolicyModel.SchedulePolicy = PolicyHelpers.GetPSSimpleSchedulePolicy((ServiceClientModel.SimpleSchedulePolicy)
                                                 ((ServiceClientModel.AzureIaaSVMProtectionPolicy)serviceClientResponse.Properties).SchedulePolicy);
            }
            else if (serviceClientResponse.Properties.GetType() ==
                typeof(ServiceClientModel.AzureSqlProtectionPolicy))
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
                sqlPolicyModel.WorkloadType = CmdletModels.WorkloadType.AzureSQLDatabase;
                sqlPolicyModel.BackupManagementType = CmdletModels.BackupManagementType.AzureSQL;

                ServiceClientModel.SimpleRetentionPolicy azureSqlRetentionPolicy =
                    (ServiceClientModel.SimpleRetentionPolicy)azureSqlPolicy.RetentionPolicy;
                sqlPolicyModel.RetentionPolicy =
                    PolicyHelpers.GetPSSimpleRetentionPolicy(azureSqlRetentionPolicy);
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

            policyModel.Name = serviceClientResponse.Name;
            policyModel.Id = serviceClientResponse.Id;

            return policyModel;
        }

        /// <summary>
        /// Helper function to convert ps backup policy list model from service response.
        /// </summary>
        public static List<PolicyBase> GetPolicyModelList(
            ServiceClientModel.ProtectionPolicyListResponse serviceClientListResponse)
        {
            if (serviceClientListResponse == null || serviceClientListResponse.ItemList == null ||
               serviceClientListResponse.ItemList.Value == null || serviceClientListResponse.ItemList.Value.Count == 0)
            {
                Logger.Instance.WriteDebug("Received empty list of policies from service");
                return null;
            }

            List<PolicyBase> policyModels = new List<PolicyBase>();
            PolicyBase policyModel = null;

            foreach (ServiceClientModel.ProtectionPolicyResource resource in serviceClientListResponse.ItemList.Value)
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
                        Cmdlets.Models.ContainerType.AzureVM,
                        policyName);
                }

                if (protectedItem.Properties.GetType() == 
                    typeof(ServiceClientModel.AzureSqlProtectedItem))
                {
                    ServiceClientModel.AzureSqlProtectedItem azureSqlProtectedItem =
                        (ServiceClientModel.AzureSqlProtectedItem)protectedItem.Properties;
                    string policyName = null;
                    string policyId = azureSqlProtectedItem.PolicyId;
                    if (!String.IsNullOrEmpty(policyId))
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
                        Cmdlets.Models.ContainerType.AzureSQL,
                        policyName);
                }
            }

            return itemModel;
        }

        /// <summary>
        /// Helper function to convert ps backup policy item list from service response.
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
        #endregion
    }
}
