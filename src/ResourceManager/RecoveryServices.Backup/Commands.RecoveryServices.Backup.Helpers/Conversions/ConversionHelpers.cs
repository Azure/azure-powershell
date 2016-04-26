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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class ConversionHelpers
    {
        #region containers
        public static AzureRmRecoveryServicesBackupContainerBase GetContainerModel(ProtectionContainerResource protectionContainer)
        {
            AzureRmRecoveryServicesBackupContainerBase containerModel = null;

            if (protectionContainer != null &&
                protectionContainer.Properties != null)
            {
                if (protectionContainer.Properties.GetType().IsSubclassOf(typeof(AzureIaaSVMProtectionContainer)))
                {
                    containerModel = new AzureRmRecoveryServicesBackupIaasVmContainer(protectionContainer);
                }
                if (protectionContainer.Properties.GetType() == typeof(MabProtectionContainer))
                {
                    containerModel = new AzureRmRecoveryServicesBackupMabContainer(protectionContainer);
                }
            }

            return containerModel;
        }

        public static AzureRmRecoveryServicesBackupEngineBase GetBackupEngineModel(BackupEngineResource backupEngine)
        {
            AzureRmRecoveryServicesBackupEngineBase backupEngineModel = null;

            if (backupEngine != null &&
                backupEngine.Properties != null)
            {
                if (backupEngine.Properties.GetType() == (typeof(DpmBackupEngine)))
                {
                    backupEngineModel = new AzureRmRecoveryServicesBackupDpmBackupEngine(backupEngine);
                }
                else if (backupEngine.Properties.GetType() == (typeof(AzureBackupServerEngine)))
                {
                    backupEngineModel = new AzureRmRecoveryServicesBackupAzureBackupServerEngine(backupEngine);
                }
            }

            return backupEngineModel;
        }

        public static List<AzureRmRecoveryServicesBackupContainerBase> GetContainerModelList(IEnumerable<ProtectionContainerResource> protectionContainers)
        {
            List<AzureRmRecoveryServicesBackupContainerBase> containerModels = new List<AzureRmRecoveryServicesBackupContainerBase>();

            foreach (var protectionContainer in protectionContainers)
            {
                containerModels.Add(GetContainerModel(protectionContainer));
            }

            return containerModels;
        }

        public static List<AzureRmRecoveryServicesBackupEngineBase> GetBackupEngineModelList(IEnumerable<BackupEngineResource> backupEngines)
        {
            List<AzureRmRecoveryServicesBackupEngineBase> backupEngineModel = new List<AzureRmRecoveryServicesBackupEngineBase>();

            foreach (var backupEngine in backupEngines)
            {
                backupEngineModel.Add(GetBackupEngineModel(backupEngine));
            }

            return backupEngineModel;
        }

        #endregion

        #region policy
        public static AzureRmRecoveryServicesBackupPolicyBase GetPolicyModel(ProtectionPolicyResource hydraResponse)
        {
            AzureRmRecoveryServicesBackupPolicyBase policyModel = null;

            if (hydraResponse == null || hydraResponse.Properties == null)
            {
                Logger.Instance.WriteDebug("Policy Hydra response is Null/Empty");
                throw new ArgumentException(Resources.EmptyHydraResponseException);
            }

            if (hydraResponse.Properties.GetType() == typeof(AzureIaaSVMProtectionPolicy))
            {
                if (((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).RetentionPolicy.GetType() !=
                                                                           typeof(LongTermRetentionPolicy))
                {
                    Logger.Instance.WriteDebug("Unknown RetentionPolicy object received: " +
                               ((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).RetentionPolicy.GetType());
                    Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                    return null;
                }

                if (((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).SchedulePolicy.GetType() !=
                                                                            typeof(SimpleSchedulePolicy))
                {
                    Logger.Instance.WriteDebug("Unknown SchedulePolicy object received: " +
                               ((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).SchedulePolicy.GetType());
                    Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                    return null;
                }

                policyModel = new AzureRmRecoveryServicesBackupIaasVmPolicy();
                AzureRmRecoveryServicesBackupIaasVmPolicy iaasPolicyModel = policyModel as AzureRmRecoveryServicesBackupIaasVmPolicy;
                iaasPolicyModel.WorkloadType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM;
                iaasPolicyModel.BackupManagementType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.BackupManagementType.AzureVM;
                iaasPolicyModel.RetentionPolicy = PolicyHelpers.GetPSLongTermRetentionPolicy((LongTermRetentionPolicy)
                                                  ((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).RetentionPolicy);
                iaasPolicyModel.SchedulePolicy = PolicyHelpers.GetPSSimpleSchedulePolicy((SimpleSchedulePolicy)
                                                 ((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).SchedulePolicy);
            }
            else
            {
                // we will enter this case when service supports new workload and customer 
                // still using old version of azure powershell. Trace warning message, ignore and return
                Logger.Instance.WriteDebug("Unknown Policy object received: " +
                                           hydraResponse.Properties.GetType());
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }

            policyModel.Name = hydraResponse.Name;
            policyModel.Id = hydraResponse.Id;

            return policyModel;
        }

        public static List<AzureRmRecoveryServicesBackupPolicyBase> GetPolicyModelList(
            ProtectionPolicyListResponse hydraListResponse)
        {
            if (hydraListResponse == null || hydraListResponse.ItemList == null ||
               hydraListResponse.ItemList.Value == null || hydraListResponse.ItemList.Value.Count == 0)
            {
                Logger.Instance.WriteDebug("Received empty list of policies from service");
                return null;
            }

            List<AzureRmRecoveryServicesBackupPolicyBase> policyModels = new List<AzureRmRecoveryServicesBackupPolicyBase>();
            AzureRmRecoveryServicesBackupPolicyBase policyModel = null;

            foreach (ProtectionPolicyResource resource in hydraListResponse.ItemList.Value)
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

        public static AzureRmRecoveryServicesBackupItemBase GetItemModel(ProtectedItemResource protectedItem)
        {
            AzureRmRecoveryServicesBackupItemBase itemModel = null;

            if (protectedItem != null &&
                protectedItem.Properties != null)
            {
                if (protectedItem.Properties.GetType().IsSubclassOf(typeof(AzureIaaSVMProtectedItem)))
                {
                    string policyName = null;
                    string policyId = ((AzureIaaSVMProtectedItem)protectedItem.Properties).PolicyId;
                    if (!string.IsNullOrEmpty(policyId))
                    {
                        Dictionary<UriEnums, string> keyValueDict =
                        HelperUtils.ParseUri(policyId);
                        policyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policyId);
                    }

                    string containerUri = HelperUtils.GetContainerUri(
                        HelperUtils.ParseUri(protectedItem.Id),
                        protectedItem.Id);

                    itemModel = new AzureRmRecoveryServicesBackupIaasVmItem(
                        protectedItem,
                        IdUtils.GetNameFromUri(containerUri),
                        Cmdlets.Models.ContainerType.AzureVM,
                        policyName);
                }
            }

            return itemModel;
        }

        public static List<AzureRmRecoveryServicesBackupItemBase> GetItemModelList(IEnumerable<ProtectedItemResource> protectedItems)
        {
            List<AzureRmRecoveryServicesBackupItemBase> itemModels = new List<AzureRmRecoveryServicesBackupItemBase>();

            foreach (var protectedItem in protectedItems)
            {
                itemModels.Add(GetItemModel(protectedItem));
            }

            return itemModels;
        }
        #endregion
    }
}
