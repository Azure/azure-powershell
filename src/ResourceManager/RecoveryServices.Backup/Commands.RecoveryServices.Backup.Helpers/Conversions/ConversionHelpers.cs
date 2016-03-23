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
        public static AzureRmRecoveryServicesContainerBase GetContainerModel(ProtectionContainerResource protectionContainer)
        {
            AzureRmRecoveryServicesContainerBase containerModel = null;

            if (protectionContainer != null &&
                protectionContainer.Properties != null)
            {
                if (protectionContainer.Properties.GetType().IsSubclassOf(typeof(AzureIaaSVMProtectionContainer)))
                {
                    containerModel = new AzureRmRecoveryServicesIaasVmContainer(protectionContainer);
                }
            }

            return containerModel;
        }

        public static List<AzureRmRecoveryServicesContainerBase> GetContainerModelList(IEnumerable<ProtectionContainerResource> protectionContainers)
        {
            List<AzureRmRecoveryServicesContainerBase> containerModels = new List<AzureRmRecoveryServicesContainerBase>();

            foreach (var protectionContainer in protectionContainers)
            {
                containerModels.Add(GetContainerModel(protectionContainer));
            }

            return containerModels;
        }

        #endregion

        #region policy
        public static AzureRmRecoveryServicesPolicyBase GetPolicyModel(ProtectionPolicyResource hydraResponse)
        {
            AzureRmRecoveryServicesPolicyBase policyModel = null;

            if(hydraResponse == null || hydraResponse.Properties == null)
            {
                throw new ArgumentException(Resources.EmptyHydraResponseException);
            }

            if (hydraResponse.Properties.GetType() == typeof(AzureIaaSVMProtectionPolicy))
            {
                if(((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).RetentionPolicy.GetType() !=
                                                                           typeof(LongTermRetentionPolicy))
                {
                    Logger.Instance.WriteDebug(Resources.UpdateToNewAzurePowershellWarning);
                    Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                    return null;
                }

                if (((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).SchedulePolicy.GetType() != 
                                                                            typeof(SimpleSchedulePolicy))
                {
                    Logger.Instance.WriteDebug(Resources.UpdateToNewAzurePowershellWarning);
                    Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                    return null;
                }

                policyModel = new AzureRmRecoveryServicesIaasVmPolicy();
                AzureRmRecoveryServicesIaasVmPolicy iaasPolicyModel = policyModel as AzureRmRecoveryServicesIaasVmPolicy;
                iaasPolicyModel.WorkloadType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM;
                iaasPolicyModel.BackupManagementType = BackupManagementType.AzureVM;
                iaasPolicyModel.RetentionPolicy = PolicyHelpers.GetPSLongTermRetentionPolicy((LongTermRetentionPolicy)
                                                  ((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).RetentionPolicy);
                iaasPolicyModel.SchedulePolicy = PolicyHelpers.GetPSSimpleSchedulePolicyPolicy((SimpleSchedulePolicy)
                                                 ((AzureIaaSVMProtectionPolicy)hydraResponse.Properties).SchedulePolicy);
            }
            else
            {
                // trace warning message, ignore and return
                // we will enter this case when service supports new workload and customer 
                // still using old version of azure powershell
                Logger.Instance.WriteDebug(Resources.UpdateToNewAzurePowershellWarning);
                Logger.Instance.WriteWarning(Resources.UpdateToNewAzurePowershellWarning);
                return null;
            }

            policyModel.Name = hydraResponse.Name;

            return policyModel;
        }

        public static List<AzureRmRecoveryServicesPolicyBase> GetPolicyModelList(ProtectionPolicyListResponse hydraListResponse)
        {
            if(hydraListResponse == null || hydraListResponse.ItemList == null ||
               hydraListResponse.ItemList.Value == null || hydraListResponse.ItemList.Value.Count == 0)
            {
                return null;
            }

            List<AzureRmRecoveryServicesPolicyBase> policyModels = new List<AzureRmRecoveryServicesPolicyBase>();
            AzureRmRecoveryServicesPolicyBase policyModel = null;

            foreach(ProtectionPolicyResource resource in hydraListResponse.ItemList.Value)
            {
                policyModel = GetPolicyModel(resource);
                if(policyModel != null)
                {
                    policyModels.Add(policyModel);
                }
            }

            return policyModels;
        }

        #endregion
    }
}
