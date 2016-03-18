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
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 10 sec
        private const string separator = ";";

        ProviderData ProviderData { get; set; }
        HydraAdapter.HydraAdapter HydraAdapter { get; set; }

        public void Initialize(ProviderData providerData, HydraAdapter.HydraAdapter hydraAdapter)
        {
            this.ProviderData = providerData;
            this.HydraAdapter = hydraAdapter;
        }

        public BaseRecoveryServicesJobResponse EnableProtection()
        {
            string azureVMName = (string)ProviderData.ProviderParameters[ItemParams.AzureVMName];
            string azureVMCloudServiceName = (string)ProviderData.ProviderParameters[ItemParams.AzureVMCloudServiceName];
            string azureVMResourceGroupName = (string)ProviderData.ProviderParameters[ItemParams.AzureVMResourceGroupName];
            string parameterSetName = (string)ProviderData.ProviderParameters[ItemParams.ParameterSetName];

            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType workloadType =
                (Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType)ProviderData.ProviderParameters[ItemParams.WorkloadType];

            AzureRmRecoveryServicesPolicyBase policy = (AzureRmRecoveryServicesPolicyBase)
                                                 ProviderData.ProviderParameters[ItemParams.Policy];
            if (policy == null)
            {
                // throw error -- TBD
            }

            AzureRmRecoveryServicesIaasVmItem item = (AzureRmRecoveryServicesIaasVmItem)
                                                 ProviderData.ProviderParameters[ItemParams.Item];
            // do validations
            //ValidateAzureVMWorkloadType(workloadType, policy); -- TBD

            string containerUri = "";
            string protectedItemUri = "";
            bool isComputeAzureVM = false;

            if (item == null)
            {
                isComputeAzureVM = string.IsNullOrEmpty(azureVMCloudServiceName) ? true : false;
                string azureVMRGName = (isComputeAzureVM) ? azureVMResourceGroupName : azureVMCloudServiceName;

                //ValidateEnableProtectionRequest(azureVMName, azureVMCloudServiceName, azureVMResourceGroupName); -- TBD

                AzureIaaSVMProtectableItem protectableObject = GetAzureVMProtectableObject(azureVMName, azureVMRGName, isComputeAzureVM);

                containerUri = protectableObject.ContainerUri;
                protectedItemUri = protectableObject.ProtectableObjectUri;
            }
            else
            {
                //ValidateMofifyProtectionRequest(item) -- TBD
                string containerType = HydraHelpers.GetHydraContainerType(item.ContainerType);
                string vmType = HydraHelpers.GetHydraWorkloadType(item.WorkloadType);
                containerUri = string.Join(separator, new string[] { containerType, item.ContainerName });
                protectedItemUri = string.Join(separator, new string[] { vmType, item.Name });
            }

            // construct Hydra protectedItem request

            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }

            properties.PolicyName = policy.Name;

            ProtectedItemCreateOrUpdateRequest hydraRequest = new ProtectedItemCreateOrUpdateRequest()
            {
                Item = new ProtectedItemResource()
                {
                    Properties = properties,
                }
            };

            return HydraAdapter.CreateOrUpdateProtectedItem(
                                containerUri,
                                protectedItemUri,
                                hydraRequest);
        }

        public BaseRecoveryServicesJobResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public RecoveryPointResponse GetRecoveryPoint()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse CreatePolicy()
        {
            string policyName = (string)ProviderData.ProviderParameters[PolicyParams.PolicyName];
            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType workloadType = 
                (Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType)ProviderData.ProviderParameters[PolicyParams.WorkloadType];
            BackupManagementType backupManagementType = (BackupManagementType)ProviderData.ProviderParameters[
                                                                              PolicyParams.BackupManagementType];
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.SchedulePolicy];           

            // do validations
            ValidateAzureVMWorkloadType(workloadType);

            // validate both RetentionPolicy and SchedulePolicy
            ValidateAzureVMRetentionPolicy(retentionPolicy);
            ValidateAzureVMSchedulePolicy(schedulePolicy);

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                                (AzureRmRecoveryServicesLongTermRetentionPolicy)retentionPolicy,
                                (AzureRmRecoveryServicesSimpleSchedulePolicy)schedulePolicy);

            // construct Hydra policy request            
            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetHydraLongTermRetentionPolicy(
                                                (AzureRmRecoveryServicesLongTermRetentionPolicy)retentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetHydraSimpleSchedulePolicy(
                                                (AzureRmRecoveryServicesSimpleSchedulePolicy)schedulePolicy)
                    }
                }
            };

            return HydraAdapter.CreateOrUpdateProtectionPolicy(
                                 policyName,
                                 hydraRequest);
        }

        public List<AzureRmRecoveryServicesJobBase> ModifyPolicy()
        {
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.SchedulePolicy];
            AzureRmRecoveryServicesPolicyBase policy = (AzureRmRecoveryServicesPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.ProtectionPolicy];
           
            // do validations
            ValidateAzureVMProtectionPolicy(policy);

            // RetentionPolicy and SchedulePolicy both should not be empty
            if (retentionPolicy == null && schedulePolicy == null)
            {
                throw new ArgumentException(Resources.BothRetentionAndSchedulePoliciesEmpty);
            }

            // validate RetentionPolicy and SchedulePolicy
            if (schedulePolicy != null)
            {
                ValidateAzureVMSchedulePolicy(schedulePolicy);
                ((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy = schedulePolicy;
            }
            if (retentionPolicy != null)
            {
                ValidateAzureVMRetentionPolicy(retentionPolicy);
                ((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy = retentionPolicy;
            }

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                (AzureRmRecoveryServicesLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy,
                (AzureRmRecoveryServicesSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy);

            // construct Hydra policy request            
            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetHydraLongTermRetentionPolicy(
                                  (AzureRmRecoveryServicesLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetHydraSimpleSchedulePolicy(
                                  (AzureRmRecoveryServicesSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy)
                    }
                }
            };

            ProtectionPolicyResponse response = HydraAdapter.CreateOrUpdateProtectionPolicy(
                                                               policy.Name,
                                                               hydraRequest);

            List<AzureRmRecoveryServicesJobBase> jobsList = new List<AzureRmRecoveryServicesJobBase>();

            if (/*response.StatusCode == System.Net.HttpStatusCode.Accepted*/ true)
            {
                // poll for AsyncHeader and get the jobsList
                // TBD
            }
            else
            {
                // no datasources attached to policy
                // hence no jobs and no action.
            }

            return jobsList;
        }

        public List<AzureRmRecoveryServicesContainerBase> ListProtectionContainers()
        {
            string name = (string)this.ProviderData.ProviderParameters[ContainerParams.Name];
            ContainerRegistrationStatus status = (ContainerRegistrationStatus)this.ProviderData.ProviderParameters[ContainerParams.Status];
            ARSVault vault = (ARSVault)this.ProviderData.ProviderParameters[ContainerParams.Vault];
            string resourceGroupName = (string)this.ProviderData.ProviderParameters[ContainerParams.ResourceGroupName];

            ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();

            // 1. Filter by Name
            queryParams.FriendlyName = name;

            // 2. Filter by ContainerType
            queryParams.ProviderType = ProviderType.AzureIaasVM.ToString();

            // 3. Filter by Status
            queryParams.RegistrationStatus = status.ToString();

            var listResponse = HydraAdapter.ListContainers(vault.ResouceGroupName, vault.Name, queryParams);

            List<AzureRmRecoveryServicesContainerBase> containerModels = ConversionHelpers.GetContainerModelList(listResponse);

            // 4. Filter by RG Name
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                containerModels = containerModels.Where(containerModel =>
                    (containerModel as AzureRmRecoveryServicesIaasVmContainer).ResourceGroupName == resourceGroupName).ToList();
            }

            return containerModels;
        }

        public ProtectionPolicyResponse GetPolicy()
        {
            throw new NotImplementedException();
        }

        public void DeletePolicy()
        {
            throw new NotImplementedException();
        }

        #region private
        private void ValidateAzureVMWorkloadType(Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType type)
        {
            if (type != Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureVMProtectionPolicy(AzureRmRecoveryServicesPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesIaasVmPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureRmRecoveryServicesIaasVmPolicy).ToString()));                
            }

            ValidateAzureVMWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMSchedulePolicy(AzureRmRecoveryServicesSchedulePolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesSimpleSchedulePolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(AzureRmRecoveryServicesSimpleSchedulePolicy).ToString()));                
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMRetentionPolicy(AzureRmRecoveryServicesRetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesLongTermRetentionPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRetentionPolicyException,
                                            typeof(AzureRmRecoveryServicesLongTermRetentionPolicy).ToString())); 
            }

            // call validation
            policy.Validate();
        }

        private AzureIaaSVMProtectableItem GetAzureVMProtectableObject( string azureVMName, string azureVMRGName, bool isComputeAzureVM)
        {
            //TriggerDiscovery if needed

            bool isDiscoveryNeed = false;

            AzureIaaSVMProtectableItem protectableObject = null;
            isDiscoveryNeed = IsDiscoveryNeeded(azureVMName, azureVMRGName, isComputeAzureVM, out protectableObject);
            if (isDiscoveryNeed)
            {
                // WriteDebug(String.Format(Resources.VMNotDiscovered, vmName));
                RefreshContainer();
                isDiscoveryNeed = IsDiscoveryNeeded(azureVMName, azureVMRGName, isComputeAzureVM, out protectableObject);
                if (isDiscoveryNeed == true)
                {
                    // TBD Container is not discovered. Throw exception
                    //string errMsg = String.Format(Resources.DiscoveryFailure, vmName, ServiceOrRG, rgName);
                    //WriteDebug(errMsg);
                    //ThrowTerminatingError(new ErrorRecord(new Exception(Resources.AzureVMNotFound), string.Empty, ErrorCategory.InvalidArgument, null));
                }
            }
            if(protectableObject == null)
            {
                // TBD throw exception.
            }

            return protectableObject;

        }
        private bool IsDiscoveryNeeded(string vmName, string rgName, bool isComputeAzureVM,
            out AzureIaaSVMProtectableItem protectableObject)
        {
            bool isDiscoveryNeed = true;
            protectableObject = null;
            string vmVersion = string.Empty;
            vmVersion = (isComputeAzureVM) == true ? "Compute" : "ClassicCompute"; // -- TBD Move hard coded values to a constant.

            ProtectableObjectListQueryParameters queryParam = new ProtectableObjectListQueryParameters();
            queryParam.ProviderType = ProviderType.AzureIaasVM.ToString();
            // Add FriendlyName query param here -- TBD
            // No need to use skip or top token here as no pagination support of IaaSVM PO.

            //First check if container is discovered or not            
            var protectableItemList = HydraAdapter.ListProtectableItem(queryParam).ItemList;

            //WriteDebug(String.Format(Resources.ContainerCountFromService, containers.Count())); -- TBD
            if (protectableItemList.ProtectableObjects.Count() == 0)
            {
                //Container is not discovered
                //WriteDebug(Resources.ContainerNotDiscovered); -- TBD
                isDiscoveryNeed = true;
            }
            else
            {
                foreach (var protectableItem in protectableItemList.ProtectableObjects)
                {
                    AzureIaaSVMProtectableItem iaaSVMProtectableItem = (AzureIaaSVMProtectableItem)protectableItem.Properties;
                    if (iaaSVMProtectableItem != null &&
                        iaaSVMProtectableItem.FriendlyName == vmName && iaaSVMProtectableItem.ResourceGroup == rgName
                        && iaaSVMProtectableItem.VirtualMachineVersion == vmVersion)
                    {
                        protectableObject = iaaSVMProtectableItem;
                        isDiscoveryNeed = false;
                        break;
                    }
                }
            }

            return isDiscoveryNeed;
        }

        private void RefreshContainer()
        {
            bool isRetryNeeded = true;
            int retryCount = 1;
            bool isDiscoverySuccessful = false;
            string errorMessage = string.Empty;
            while (isRetryNeeded && retryCount <= 3)
            {
                var refreshContainerJobResponse = HydraAdapter.RefreshContainers();

                //Now wait for the operation to Complete               
                isRetryNeeded = WaitForDiscoveryToComplete(refreshContainerJobResponse.Location, out isDiscoverySuccessful, out errorMessage);
                retryCount++;
            }

            if (!isDiscoverySuccessful)
            {
                // TBD ThrowTerminatingError(new ErrorRecord(new Exception(errorMessage), string.Empty, ErrorCategory.InvalidArgument, null));
            }
        }

        private bool WaitForDiscoveryToComplete(string locationUri, out bool isDiscoverySuccessful, out string errorMessage)
        {
            bool isRetryNeeded = false;
            var status = TrackRefreshContainerOperation(locationUri);
            errorMessage = String.Empty;

            isDiscoverySuccessful = true;
            //If operation fails check if retry is needed or not
            if (status != HttpStatusCode.OK)
            {
                isDiscoverySuccessful = false;
                errorMessage = "";
                // TBDs
                //Check if retry needed.
                //WriteDebug(String.Format(Resources.DiscoveryFailureErrorCode, status.Error.Code));
                //if ((status.Error.Code == AzureBackupOperationErrorCode.DiscoveryInProgress.ToString() ||
                //    (status.Error.Code == AzureBackupOperationErrorCode.BMSUserErrorObjectLocked.ToString())))
                //{
                //    //Need to retry for this errors
                //    isRetryNeeded = true;
                //    WriteDebug(String.Format(Resources.RertyDiscovery));
                //}
            }
            return isRetryNeeded;
        }

        private HttpStatusCode TrackRefreshContainerOperation(string operationResultLink, int checkFrequency = defaultOperationStatusRetryTimeInMilliSec)
        {
            HttpStatusCode status = HttpStatusCode.Accepted;
            while (status == HttpStatusCode.Accepted)
            {
                try
                {
                    var response = HydraAdapter.GetRefreshContainerOperationResultByURL(operationResultLink);
                    status = response.StatusCode;

                    Thread.Sleep(checkFrequency);
                }
                catch (Exception ex)
                {
                     // TBD throw exception
                    throw ex;
                }                
            }

            if (status == HttpStatusCode.NoContent)
            {
                // TBD WriteDebug("Refresh Container Job completed with success");
            }
            else
            {
                string msg = String.Format("Unexpected http status in response header{ {0}", status);
                // -- TBD WriteDebug(msg);
                throw new Exception(msg);
            }

            return status;
        }

        #endregion
    }
}
