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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using RestAzureNS = Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using SystemNet = System.Net;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for IaasVm backup provider
    /// </summary>
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 5 sec
        private const string separator = ";";
        private const string computeAzureVMVersion = "Microsoft.Compute";
        private const string classicComputeAzureVMVersion = "Microsoft.ClassicCompute";

        Dictionary<Enum, object> ProviderData { get; set; }
        ServiceClientAdapter ServiceClientAdapter { get; set; }
        AzureWorkloadProviderHelper AzureWorkloadProviderHelper { get; set; }

        /// <summary>
        /// Initializes the provider with the data received from the cmdlet layer
        /// </summary>
        /// <param name="providerData">Data from the cmdlet layer intended for the provider</param>
        /// <param name="serviceClientAdapter">Service client adapter for communicating with the backend service</param>
        public void Initialize(
            Dictionary<Enum, object> providerData, ServiceClientAdapter serviceClientAdapter)
        {
            ProviderData = providerData;
            ServiceClientAdapter = serviceClientAdapter;
            AzureWorkloadProviderHelper = new AzureWorkloadProviderHelper(ServiceClientAdapter);
        }

        /// <summary>
        /// Triggers the enable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> EnableProtection()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string azureVMName = (string)ProviderData[ItemParams.ItemName];
            string azureVMCloudServiceName = (string)ProviderData[ItemParams.AzureVMCloudServiceName];
            string azureVMResourceGroupName = (string)ProviderData[ItemParams.AzureVMResourceGroupName];
            string parameterSetName = (string)ProviderData[ItemParams.ParameterSetName];
            string[] inclusionDisksList = (string[])ProviderData[ItemParams.InclusionDisksList];
            string[] exclusionDisksList = (string[])ProviderData[ItemParams.ExclusionDisksList];
            SwitchParameter resetDiskExclusionSetting = (SwitchParameter)ProviderData[ItemParams.ResetExclusionSettings];

            PolicyBase policy = (PolicyBase)ProviderData[ItemParams.Policy];

            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];

            // do validations
            string containerUri = "";
            string protectedItemUri = "";
            bool isComputeAzureVM = false;
            string sourceResourceId = null;

            AzureVmPolicy azureVmPolicy = (AzureVmPolicy)ProviderData[ItemParams.Policy];
            ValidateProtectedItemCount(azureVmPolicy);

            if (itemBase == null)
            {
                isComputeAzureVM = string.IsNullOrEmpty(azureVMCloudServiceName) ? true : false;
                string azureVMRGName = (isComputeAzureVM) ?
                    azureVMResourceGroupName : azureVMCloudServiceName;

                ValidateAzureVMWorkloadType(policy.WorkloadType);

                ValidateAzureVMEnableProtectionRequest(
                    azureVMName,
                    azureVMCloudServiceName,
                    azureVMResourceGroupName,
                    policy);

                WorkloadProtectableItemResource protectableObjectResource =
                    GetAzureVMProtectableObject(
                        azureVMName,
                        azureVMRGName,
                        isComputeAzureVM,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                Dictionary<UriEnums, string> keyValueDict =
                    HelperUtils.ParseUri(protectableObjectResource.Id);
                containerUri = HelperUtils.GetContainerUri(
                    keyValueDict, protectableObjectResource.Id);
                protectedItemUri = HelperUtils.GetProtectableItemUri(
                    keyValueDict, protectableObjectResource.Id);

                IaaSVMProtectableItem iaasVmProtectableItem =
                    (IaaSVMProtectableItem)protectableObjectResource.Properties;
                if (iaasVmProtectableItem != null)
                {
                    sourceResourceId = iaasVmProtectableItem.VirtualMachineId;
                }
            }
            else
            {
                ValidateAzureVMWorkloadType(item.WorkloadType, policy.WorkloadType);
                ValidateAzureVMModifyProtectionRequest(itemBase, policy);

                isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
                containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
                protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);
                sourceResourceId = item.SourceResourceId;
            }

            // construct Service Client protectedItem request

            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }

            properties.PolicyId = policy.Id;
            properties.SourceResourceId = sourceResourceId;

            if(resetDiskExclusionSetting.IsPresent)
            {
                properties.ExtendedInfo
            }

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        /// <summary>
        /// Triggers the disable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> DisableProtection()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            bool deleteBackupData = (bool)ProviderData[ItemParams.DeleteBackupData];

            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];
            // do validations

            ValidateAzureVMDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            bool isComputeAzureVM = false;
            isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);

            // construct Service Client protectedItem request

            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }

            properties.PolicyId = string.Empty;
            properties.ProtectionState = ProtectionState.ProtectionStopped;
            properties.SourceResourceId = item.SourceResourceId;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties,
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        public RestAzureNS.AzureOperationResponse DisableProtectionWithDeleteData()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            bool deleteBackupData = (bool)ProviderData[ItemParams.DeleteBackupData];

            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];
            // do validations

            ValidateAzureVMDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            return ServiceClientAdapter.DeleteProtectedItem(
                                containerUri,
                                protectedItemUri,
                                vaultName: vaultName,
                                resourceGroupName: resourceGroupName);
        }


        /// <summary>
        /// Triggers the backup operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse TriggerBackup()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ItemBase item = (ItemBase)ProviderData[ItemParams.Item];
            DateTime? expiryDateTime = (DateTime?)ProviderData[ItemParams.ExpiryDateTimeUTC];
            AzureVmItem iaasVmItem = item as AzureVmItem;
            BackupRequestResource triggerBackupRequest = new BackupRequestResource();
            IaasVMBackupRequest iaasVmBackupRequest = new IaasVMBackupRequest();
            iaasVmBackupRequest.RecoveryPointExpiryTimeInUTC = expiryDateTime;
            triggerBackupRequest.Properties = iaasVmBackupRequest;

            return ServiceClientAdapter.TriggerBackup(
                IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectionContainerName),
                IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectedItemName),
                triggerBackupRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> UndeleteProtection()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            bool isComputeAzureVM = false;
            isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);

            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }

            properties.PolicyId = null;
            properties.ProtectionState = ProtectionState.ProtectionStopped;
            properties.SourceResourceId = item.SourceResourceId;
            properties.IsRehydrate = true;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties,
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        /// <summary>
        /// Triggers the recovery operation for the given recovery point
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse TriggerRestore()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string vaultLocation = (string)ProviderData[VaultParams.VaultLocation];
            AzureVmRecoveryPoint rp = ProviderData[RestoreBackupItemParams.RecoveryPoint]
                as AzureVmRecoveryPoint;
            string storageAccountName = ProviderData[RestoreBackupItemParams.StorageAccountName].ToString();
            string storageAccountResourceGroupName =
                ProviderData[RestoreBackupItemParams.StorageAccountResourceGroupName].ToString();
            string targetResourceGroupName =
                ProviderData.ContainsKey(RestoreVMBackupItemParams.TargetResourceGroupName) ?
                ProviderData[RestoreVMBackupItemParams.TargetResourceGroupName].ToString() : null;
            bool osaOption = (bool)ProviderData[RestoreVMBackupItemParams.OsaOption];
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);

            GenericResource storageAccountResource = ServiceClientAdapter.GetStorageAccountResource(storageAccountName);

            var useOsa = ShouldUseOsa(rp, osaOption);

            string vmType = containerUri.Split(';')[1].Equals("iaasvmcontainer", StringComparison.OrdinalIgnoreCase)
                ? "Classic" : "Compute";
            string strType = storageAccountResource.Type.Equals("Microsoft.ClassicStorage/StorageAccounts",
                StringComparison.OrdinalIgnoreCase) ? "Classic" : "Compute";
            if (vmType != strType)
            {
                throw new Exception(string.Format(Resources.RestoreDiskStorageTypeError, vmType));
            }

            if (targetResourceGroupName != null && rp.IsManagedVirtualMachine == false)
            {
                Logger.Instance.WriteWarning(Resources.UnManagedBackupVmWarning);
            }

            IaasVMRestoreRequest restoreRequest = new IaasVMRestoreRequest()
            {
                CreateNewCloudService = false,
                RecoveryPointId = rp.RecoveryPointId,
                RecoveryType = RecoveryType.RestoreDisks,
                Region = vaultLocation ?? ServiceClientAdapter.BmsAdapter.GetResourceLocation(),
                StorageAccountId = storageAccountResource.Id,
                SourceResourceId = rp.SourceResourceId,
                TargetResourceGroupId = targetResourceGroupName != null ?
                    "/subscriptions/" + ServiceClientAdapter.SubscriptionId + "/resourceGroups/" + targetResourceGroupName :
                    null,
                OriginalStorageAccountOption = useOsa,
            };

            RestoreRequestResource triggerRestoreRequest = new RestoreRequestResource();
            triggerRestoreRequest.Properties = restoreRequest;

            var response = ServiceClientAdapter.RestoreDisk(
                rp,
                storageAccountResource.Location,
                triggerRestoreRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                vaultLocation: vaultLocation ?? ServiceClientAdapter.BmsAdapter.GetResourceLocation());
            return response;
        }

        public ProtectedItemResource GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches the detail info for the given recovery point
        /// </summary>
        /// <returns>Recovery point detail as returned by the service</returns>
        public RecoveryPointBase GetRecoveryPointDetails()
        {
            return AzureWorkloadProviderHelper.GetRecoveryPointDetails(ProviderData);
        }

        /// <summary>
        /// Provisioning Item Level Recovery Access for the given recovery point
        /// </summary>
        /// <returns>Azure VM client script details as returned by the service</returns>
        public RPMountScriptDetails ProvisionItemLevelRecoveryAccess()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string content = string.Empty;
            AzureVmRecoveryPoint rp = ProviderData[RestoreBackupItemParams.RecoveryPoint]
                as AzureVmRecoveryPoint;
            if (rp.EncryptionEnabled == true)
            {
                throw new ArgumentException(Resources.ILREncryptedVmError);
            }
            content = string.Empty;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, rp.Id);

            IaasVMILRRegistrationRequest registrationRequest =
                new IaasVMILRRegistrationRequest();
            registrationRequest.RecoveryPointId = rp.RecoveryPointId;
            registrationRequest.VirtualMachineId = rp.SourceResourceId;
            registrationRequest.RenewExistingRegistration = (rp.IlrSessionActive == false) ? false : true;

            var ilRResponse = ServiceClientAdapter.ProvisioninItemLevelRecoveryAccess(
                containerUri,
                protectedItemName,
                rp.RecoveryPointId,
                registrationRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            IEnumerable<string> ie =
                    ilRResponse.Response.Headers.GetValues("Azure-AsyncOperation");
            string asyncHeader = string.Empty;
            foreach (string s in ie)
            {
                asyncHeader = s;
            }

            AzureVmRPMountScriptDetails result = null;
            var response = TrackingHelpers.GetOperationStatus(
                ilRResponse,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(
                    operationId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName));

            if (response != null && response.Status != null &&
                   response.Properties != null && ((OperationStatusProvisionILRExtendedInfo)
                   response.Properties).RecoveryTarget != null)
            {
                InstantItemRecoveryTarget recoveryTarget =
                    ((OperationStatusProvisionILRExtendedInfo)
                    response.Properties).RecoveryTarget;

                if (recoveryTarget.ClientScripts.Count != 0)
                {
                    if (recoveryTarget.ClientScripts.Count == 2)
                    {
                        // clientScriptForConnection.OsType == "Windows"
                        result = this.GenerateILRResponseForWindowsVMs(
                                recoveryTarget.ClientScripts[1], out content);
                    }
                    else
                    {
                        // clientScriptForConnection.OsType == "Linux"
                        result = this.GenerateILRResponseForLinuxVMs(
                                recoveryTarget.ClientScripts[0],
                                protectedItemName, rp.RecoveryPointTime.ToString(), out content);
                    }
                }
            }

            string scriptDownloadLocation =
                    (string)ProviderData[RecoveryPointParams.FileDownloadLocation];
            if (string.IsNullOrEmpty(scriptDownloadLocation))
            {
                scriptDownloadLocation = Directory.GetCurrentDirectory();
            }
            result.FilePath = Path.Combine(scriptDownloadLocation, result.Filename);
            AzureSession.Instance.DataStore.WriteFile(result.FilePath, Convert.FromBase64String(content));

            Logger.Instance.WriteVerbose(string.Format(
                Resources.MountRecoveryPointInfoMessage, result.FilePath, result.Password));
            return result;
        }

        /// <summary>
        /// Revoke Item Level Recovery Access for the given recovery point
        /// </summary>
        /// <returns></returns>
        public void RevokeItemLevelRecoveryAccess()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            AzureVmRecoveryPoint rp = ProviderData[RestoreBackupItemParams.RecoveryPoint]
                as AzureVmRecoveryPoint;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, rp.Id);

            var ilRResponse = ServiceClientAdapter.RevokeItemLevelRecoveryAccess(
                containerUri,
                protectedItemName,
                rp.RecoveryPointId,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            IEnumerable<string> ie =
                    ilRResponse.Response.Headers.GetValues("Azure-AsyncOperation");
            string asyncHeader = string.Empty;
            foreach (string s in ie)
            {
                asyncHeader = s;
            }

            var response = TrackingHelpers.GetOperationStatus(
                ilRResponse,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(
                    operationId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName));

            if (response != null && response.Status != null)
            {
                Logger.Instance.WriteDebug("Completed the call with status code" + response.Status.ToString());
            }
        }

        /// <summary>
        /// Lists recovery points generated for the given item
        /// </summary>
        /// <returns>List of recovery point PowerShell model objects</returns>
        public List<RecoveryPointBase> ListRecoveryPoints()
        {
            return AzureWorkloadProviderHelper.ListRecoveryPoints(ProviderData);
        }

        /// <summary>
        /// Creates policy given the provider data
        /// </summary>
        /// <returns>Created policy object as returned by the service</returns>
        public ProtectionPolicyResource CreatePolicy()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string policyName = (string)ProviderData[PolicyParams.PolicyName];
            CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[PolicyParams.WorkloadType];
            RetentionPolicyBase retentionPolicy =
                ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ?
                (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] :
                null;
            SchedulePolicyBase schedulePolicy =
                ProviderData.ContainsKey(PolicyParams.SchedulePolicy) ?
                (SchedulePolicyBase)ProviderData[PolicyParams.SchedulePolicy] :
                null;

            // do validations
            ValidateAzureVMWorkloadType(workloadType);
            AzureWorkloadProviderHelper.ValidateSimpleSchedulePolicy(schedulePolicy);
            Logger.Instance.WriteDebug("Validation of Schedule policy is successful");

            // validate RetentionPolicy
            AzureWorkloadProviderHelper.ValidateLongTermRetentionPolicy(retentionPolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy is successful");

            // update the retention times from backupSchedule to retentionPolicy after converting to UTC           
            AzureWorkloadProviderHelper.CopyScheduleTimeToRetentionTimes((CmdletModel.LongTermRetentionPolicy)retentionPolicy,
                                             (CmdletModel.SimpleSchedulePolicy)schedulePolicy);
            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

            // Now validate both RetentionPolicy and SchedulePolicy together
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                                (CmdletModel.LongTermRetentionPolicy)retentionPolicy,
                                (CmdletModel.SimpleSchedulePolicy)schedulePolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

            int snapshotRetentionInDays = 2;
            if (((CmdletModel.SimpleSchedulePolicy)schedulePolicy).ScheduleRunFrequency == CmdletModel.ScheduleRunType.Weekly)
            {
                snapshotRetentionInDays = 5;
            }
            // construct Service Client policy request            
            ProtectionPolicyResource serviceClientRequest = new ProtectionPolicyResource()
            {
                Properties = new AzureIaaSVMProtectionPolicy()
                {
                    RetentionPolicy = PolicyHelpers.GetServiceClientLongTermRetentionPolicy(
                                                (CmdletModel.LongTermRetentionPolicy)retentionPolicy),
                    SchedulePolicy = PolicyHelpers.GetServiceClientSimpleSchedulePolicy(
                                                (CmdletModel.SimpleSchedulePolicy)schedulePolicy),
                    TimeZone = DateTimeKind.Utc.ToString().ToUpper(),
                    InstantRpRetentionRangeInDays = snapshotRetentionInDays
                }

            };

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                policyName,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName).Body;
        }

        /// <summary>
        /// Modifies policy using the provider data
        /// </summary>
        /// <returns>Modified policy object as returned by the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectionPolicyResource> ModifyPolicy()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            RetentionPolicyBase retentionPolicy =
               ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ?
               (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] :
               null;
            SchedulePolicyBase schedulePolicy =
                ProviderData.ContainsKey(PolicyParams.SchedulePolicy) ?
                (SchedulePolicyBase)ProviderData[PolicyParams.SchedulePolicy] :
                null;

            PolicyBase policy =
                ProviderData.ContainsKey(PolicyParams.ProtectionPolicy) ?
                (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy] :
                null;

            // do validations
            ValidateAzureVMProtectionPolicy(policy);
            Logger.Instance.WriteDebug("Validation of Protection Policy is successful");

            // validate RetentionPolicy and SchedulePolicy
            if (schedulePolicy != null)
            {
                AzureWorkloadProviderHelper.ValidateSimpleSchedulePolicy(schedulePolicy);
                ((AzureVmPolicy)policy).SchedulePolicy = schedulePolicy;
                Logger.Instance.WriteDebug("Validation of Schedule policy is successful");
            }
            if (retentionPolicy != null)
            {
                AzureWorkloadProviderHelper.ValidateLongTermRetentionPolicy(retentionPolicy);
                ((AzureVmPolicy)policy).RetentionPolicy = retentionPolicy;
                Logger.Instance.WriteDebug("Validation of Retention policy is successful");
            }

            // copy the backupSchedule time to retentionPolicy after converting to UTC
            AzureWorkloadProviderHelper.CopyScheduleTimeToRetentionTimes(
                (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy,
                (CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy);
            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy,
                (CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

            //Validate instant RP retention days
            ValidateInstantRPRetentionDays(((AzureVmPolicy)policy));

            // construct Service Client policy request            
            ProtectionPolicyResource serviceClientRequest = new ProtectionPolicyResource()
            {
                Properties = new AzureIaaSVMProtectionPolicy()
                {
                    RetentionPolicy = PolicyHelpers.GetServiceClientLongTermRetentionPolicy(
                                  (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy),
                    SchedulePolicy = PolicyHelpers.GetServiceClientSimpleSchedulePolicy(
                                  (CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy),
                    TimeZone = DateTimeKind.Utc.ToString().ToUpper(),
                    InstantRpRetentionRangeInDays = ((AzureVmPolicy)policy).SnapshotRetentionInDays
                }
            };

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                policy.Name,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        /// <summary>
        /// Lists protection containers according to the provider data
        /// </summary>
        /// <returns>List of protection containers</returns>
        public List<ContainerBase> ListProtectionContainers()
        {
            string resourceGroupName = (string)ProviderData[ContainerParams.ResourceGroupName];
            CmdletModel.BackupManagementType? backupManagementTypeNullable =
                (CmdletModel.BackupManagementType?)
                    ProviderData[ContainerParams.BackupManagementType];

            if (backupManagementTypeNullable.HasValue)
            {
                ValidateAzureVMBackupManagementType(backupManagementTypeNullable.Value);
            }

            var containerModels = AzureWorkloadProviderHelper.ListProtectionContainers(
                ProviderData,
                ServiceClientModel.BackupManagementType.AzureIaasVM);

            // Filter by RG Name
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                containerModels = containerModels.Where(
                    containerModel =>
                    {
                        return string.Compare(
                            (containerModel as AzureVmContainer).ResourceGroupName,
                            resourceGroupName,
                            true) == 0;
                    }).ToList();
            }

            return containerModels;
        }

        public List<CmdletModel.BackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists protected items protected by the recovery services vault according to the provider data
        /// </summary>
        /// <returns>List of protected items</returns>
        public List<ItemBase> ListProtectedItems()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ContainerBase container =
                (ContainerBase)ProviderData[ItemParams.Container];
            string itemName = (string)ProviderData[ItemParams.ItemName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)ProviderData[ItemParams.ProtectionStatus];
            ItemProtectionState status =
                (ItemProtectionState)ProviderData[ItemParams.ProtectionState];
            CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[ItemParams.WorkloadType];
            ItemDeleteState deleteState =
               (ItemDeleteState)ProviderData[ItemParams.DeleteState];

            PolicyBase policy = (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy];

            // 1. Filter by container
            List<ProtectedItemResource> protectedItems = AzureWorkloadProviderHelper.ListProtectedItemsByContainer(
                vaultName,
                resourceGroupName,
                container,
                policy,
                ServiceClientModel.BackupManagementType.AzureIaasVM,
                DataSourceType.VM);

            // 2. Filter by item name
            List<ItemBase> itemModels = AzureWorkloadProviderHelper.ListProtectedItemsByItemName(
                protectedItems,
                itemName,
                vaultName,
                resourceGroupName,
                (itemModel, protectedItemGetResponse) =>
                {
                    AzureVmItemExtendedInfo extendedInfo = new AzureVmItemExtendedInfo();
                    var serviceClientExtendedInfo = ((AzureIaaSVMProtectedItem)protectedItemGetResponse.Properties).ExtendedInfo;
                    if (serviceClientExtendedInfo.OldestRecoveryPoint.HasValue)
                    {
                        extendedInfo.OldestRecoveryPoint = serviceClientExtendedInfo.OldestRecoveryPoint;
                    }
                    extendedInfo.PolicyState = serviceClientExtendedInfo.PolicyInconsistent.ToString();
                    extendedInfo.RecoveryPointCount =
                        (int)(serviceClientExtendedInfo.RecoveryPointCount.HasValue ?
                            serviceClientExtendedInfo.RecoveryPointCount : 0);
                    ((AzureVmItem)itemModel).ExtendedInfo = extendedInfo;
                });

            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).ProtectionStatus == protectionStatus;
                }).ToList();
            }

            // 4. Filter by item's Protection State
            if (status != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).ProtectionState == status;
                }).ToList();
            }

            // 5. Filter by workload type
            if (workloadType != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return itemModel.WorkloadType == workloadType;
                }).ToList();
            }

            // 6. Filter by Delete State
            if (deleteState != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).DeleteState == deleteState;
                }).ToList();
            }

            return itemModels;
        }

        /// <summary>
        /// Constructs the schedule policy object with default inits
        /// </summary>
        /// <returns>Default schedule policy object</returns>
        public SchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            CmdletModel.SimpleSchedulePolicy defaultSchedule = new CmdletModel.SimpleSchedulePolicy();
            //Default is daily scedule at 10:30 AM local time
            defaultSchedule.ScheduleRunFrequency = CmdletModel.ScheduleRunType.Daily;

            DateTime scheduleTime = AzureWorkloadProviderHelper.GenerateRandomScheduleTime();
            defaultSchedule.ScheduleRunTimes = new List<DateTime>();
            defaultSchedule.ScheduleRunTimes.Add(scheduleTime);

            defaultSchedule.ScheduleRunDays = new List<System.DayOfWeek>();
            defaultSchedule.ScheduleRunDays.Add(System.DayOfWeek.Sunday);

            return defaultSchedule;
        }

        /// <summary>
        /// Constructs the retention policy object with default inits
        /// </summary>
        /// <returns>Default retention policy object</returns>
        public RetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            CmdletModel.LongTermRetentionPolicy defaultRetention = new CmdletModel.LongTermRetentionPolicy();

            //Default time is 10:30 local time
            DateTime retentionTime = AzureWorkloadProviderHelper.GenerateRandomScheduleTime();

            //Daily Retention policy
            defaultRetention.IsDailyScheduleEnabled = true;
            defaultRetention.DailySchedule = new CmdletModel.DailyRetentionSchedule();
            defaultRetention.DailySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.DailySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.DailySchedule.DurationCountInDays = 180; //TBD make it const

            //Weekly Retention policy
            defaultRetention.IsWeeklyScheduleEnabled = true;
            defaultRetention.WeeklySchedule = new CmdletModel.WeeklyRetentionSchedule();
            defaultRetention.WeeklySchedule.DaysOfTheWeek = new List<System.DayOfWeek>();
            defaultRetention.WeeklySchedule.DaysOfTheWeek.Add(System.DayOfWeek.Sunday);
            defaultRetention.WeeklySchedule.DurationCountInWeeks = 104; //TBD make it const
            defaultRetention.WeeklySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.WeeklySchedule.RetentionTimes.Add(retentionTime);

            //Monthly retention policy
            defaultRetention.IsMonthlyScheduleEnabled = true;
            defaultRetention.MonthlySchedule = new CmdletModel.MonthlyRetentionSchedule();
            defaultRetention.MonthlySchedule.DurationCountInMonths = 60; //tbd: make it const
            defaultRetention.MonthlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.MonthlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.MonthlySchedule.RetentionScheduleFormatType =
                CmdletModel.RetentionScheduleFormat.Weekly;

            //Initialize day based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleDaily = AzureWorkloadProviderHelper.GetDailyRetentionFormat();

            //Initialize Week based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleWeekly = AzureWorkloadProviderHelper.GetWeeklyRetentionFormat();

            //Yearly retention policy
            defaultRetention.IsYearlyScheduleEnabled = true;
            defaultRetention.YearlySchedule = new CmdletModel.YearlyRetentionSchedule();
            defaultRetention.YearlySchedule.DurationCountInYears = 10;
            defaultRetention.YearlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.YearlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.YearlySchedule.RetentionScheduleFormatType =
                CmdletModel.RetentionScheduleFormat.Weekly;
            defaultRetention.YearlySchedule.MonthsOfYear = new List<Month>();
            defaultRetention.YearlySchedule.MonthsOfYear.Add(Month.January);
            defaultRetention.YearlySchedule.RetentionScheduleDaily = AzureWorkloadProviderHelper.GetDailyRetentionFormat();
            defaultRetention.YearlySchedule.RetentionScheduleWeekly = AzureWorkloadProviderHelper.GetWeeklyRetentionFormat();
            return defaultRetention;

        }
        public void RegisterContainer()
        {
            throw new NotImplementedException();
        }

        #region private


        private void ValidateProtectedItemCount(AzureVmPolicy azureVmPolicy)
        {
            if (azureVmPolicy.ProtectedItemsCount > 100)
            {
                throw new ArgumentException(Resources.ProtectedItemsCountExceededException);
            }
        }

        private void ValidateAzureVMWorkloadType(CmdletModel.WorkloadType type)
        {
            if (type != CmdletModel.WorkloadType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            CmdletModel.WorkloadType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureVMWorkloadType(CmdletModel.WorkloadType itemWorkloadType,
            CmdletModel.WorkloadType policyWorkloadType)
        {
            ValidateAzureVMWorkloadType(itemWorkloadType);
            ValidateAzureVMWorkloadType(policyWorkloadType);
            if (itemWorkloadType != policyWorkloadType)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            CmdletModel.WorkloadType.AzureVM.ToString(),
                                            itemWorkloadType.ToString()));
            }
        }

        private void ValidateAzureVMContainerType(CmdletModel.ContainerType type)
        {
            if (type != CmdletModel.ContainerType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedContainerTypeException,
                                            CmdletModel.ContainerType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureVMBackupManagementType(
            CmdletModel.BackupManagementType backupManagementType)
        {
            if (backupManagementType != CmdletModel.BackupManagementType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedBackupManagementTypeException,
                                            CmdletModel.BackupManagementType.AzureVM.ToString(),
                                            backupManagementType.ToString()));
            }
        }

        private void ValidateAzureVMProtectionPolicy(PolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureVmPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmPolicy).ToString()));
            }

            ValidateAzureVMWorkloadType(policy.WorkloadType);
            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMEnableProtectionRequest(string vmName, string serviceName, string rgName,
            PolicyBase policy)
        {
            if (string.IsNullOrEmpty(vmName))
            {
                throw new ArgumentException(string.Format(Resources.InvalidAzureVMName));
            }
            if (string.IsNullOrEmpty(rgName) && string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentException(
                    string.Format(Resources.BothCloudServiceNameAndResourceGroupNameShouldNotEmpty)
                    );
            }
        }

        private void ValidateAzureVMModifyProtectionRequest(ItemBase itemBase,
            PolicyBase policy)
        {
            if (itemBase == null || itemBase.GetType() != typeof(AzureVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }
        }

        private void ValidateAzureVMDisableProtectionRequest(ItemBase itemBase)
        {

            if (itemBase == null || itemBase.GetType() != typeof(AzureVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }

            ValidateAzureVMWorkloadType(itemBase.WorkloadType);
            ValidateAzureVMContainerType(itemBase.ContainerType);
        }

        private void ValidateInstantRPRetentionDays(AzureVmPolicy policy)
        {
            if (((CmdletModel.SimpleSchedulePolicy)policy.SchedulePolicy).ScheduleRunFrequency == CmdletModel.ScheduleRunType.Weekly)
            {
                if (policy.SnapshotRetentionInDays != 5)
                {
                    throw new ArgumentException(string.Format(Resources.InstantRPRetentionDaysException));
                }
            }
            else if ((((CmdletModel.SimpleSchedulePolicy)policy.SchedulePolicy).ScheduleRunFrequency == CmdletModel.ScheduleRunType.Daily))
            {
                if (policy.SnapshotRetentionInDays < 1 || policy.SnapshotRetentionInDays > 5)
                {
                    throw new ArgumentException(string.Format(Resources.InstantRPRetentionDaysException));
                }
            }
        }

        private bool IsComputeAzureVM(string virtualMachineId)
        {
            bool isComputeAzureVM = true;
            if (virtualMachineId.IndexOf(classicComputeAzureVMVersion,
                StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                isComputeAzureVM = false;
            }
            return isComputeAzureVM;
        }

        private WorkloadProtectableItemResource GetAzureVMProtectableObject(
            string azureVMName,
            string azureVMRGName,
            bool isComputeAzureVM,
            string vaultName = null,
            string resourceGroupName = null)
        {
            //TriggerDiscovery if needed

            bool isDiscoveryNeeded = false;

            WorkloadProtectableItemResource protectableObjectResource = null;
            isDiscoveryNeeded = IsDiscoveryNeeded(
                azureVMName,
                azureVMRGName,
                isComputeAzureVM,
                out protectableObjectResource,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            if (isDiscoveryNeeded)
            {
                Logger.Instance.WriteDebug(string.Format(Resources.VMNotDiscovered, azureVMName));
                AzureWorkloadProviderHelper.RefreshContainer(vaultName, resourceGroupName);
                isDiscoveryNeeded = IsDiscoveryNeeded(
                    azureVMName,
                    azureVMRGName,
                    isComputeAzureVM,
                    out protectableObjectResource,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);

                if (isDiscoveryNeeded)
                {
                    // Container is not discovered. Throw exception
                    string vmversion = (isComputeAzureVM) ?
                        computeAzureVMVersion :
                        classicComputeAzureVMVersion;
                    string errMsg = string.Format(Resources.DiscoveryFailure,
                        azureVMName,
                        azureVMRGName,
                        vmversion);
                    Logger.Instance.WriteDebug(errMsg);
                    Logger.Instance.WriteError(
                        new ErrorRecord(new Exception(Resources.AzureVMNotFound),
                            string.Empty,
                            ErrorCategory.InvalidArgument,
                            null));
                }
            }
            if (protectableObjectResource == null)
            {
                // Container is not discovered. Throw exception
                string vmversion = (isComputeAzureVM) ?
                    computeAzureVMVersion : classicComputeAzureVMVersion;
                string errMsg = string.Format(
                    Resources.DiscoveryFailure,
                    azureVMName,
                    azureVMRGName,
                    vmversion);
                Logger.Instance.WriteDebug(errMsg);
                Logger.Instance.WriteError(
                    new ErrorRecord(new Exception(Resources.AzureVMNotFound),
                        string.Empty, ErrorCategory.InvalidArgument, null));
            }

            return protectableObjectResource;
        }

        private bool IsDiscoveryNeeded(
            string vmName,
            string rgName,
            bool isComputeAzureVM,
            out WorkloadProtectableItemResource protectableObjectResource,
            string vaultName = null,
            string resourceGroupName = null)
        {
            bool isDiscoveryNeed = true;
            protectableObjectResource = null;
            string vmVersion = string.Empty;
            vmVersion = (isComputeAzureVM) == true ? computeAzureVMVersion : classicComputeAzureVMVersion;
            string virtualMachineId = GetAzureIaasVirtualMachineId(rgName, vmVersion, vmName);

            ODataQuery<BMSPOQueryObject> queryParam = new ODataQuery<BMSPOQueryObject>(
                q => q.BackupManagementType
                     == ServiceClientModel.BackupManagementType.AzureIaasVM);

            var protectableItemList = ServiceClientAdapter.ListProtectableItem(
                queryParam,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            Logger.Instance.WriteDebug(string.Format(Resources.ContainerCountAfterFilter,
                protectableItemList.Count()));
            if (protectableItemList.Count() == 0)
            {
                //Container is not discovered
                Logger.Instance.WriteDebug(Resources.ContainerNotDiscovered);
                isDiscoveryNeed = true;
            }
            else
            {
                foreach (var protectableItem in protectableItemList)
                {
                    IaaSVMProtectableItem iaaSVMProtectableItem =
                        (IaaSVMProtectableItem)protectableItem.Properties;
                    if (iaaSVMProtectableItem != null &&
                        string.Compare(iaaSVMProtectableItem.FriendlyName, vmName, true) == 0
                        && iaaSVMProtectableItem.VirtualMachineId.IndexOf(virtualMachineId,
                        StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        protectableObjectResource = protectableItem;
                        isDiscoveryNeed = false;
                        break;
                    }
                }
            }

            return isDiscoveryNeed;
        }

        private static string GetAzureIaasVirtualMachineId(
            string resourceGroup,
            string vmVersion,
            string name)
        {
            string IaasVMIdFormat = "/resourceGroups/{0}/providers/{1}/virtualMachines/{2}";
            return string.Format(IaasVMIdFormat, resourceGroup, vmVersion, name);
        }

        /// <summary>
        /// Generates ILR Response object for Windows VMs
        /// </summary>
        /// <param name="clientScriptForConnection"></param>
        /// <returns></returns>
        private AzureVmRPMountScriptDetails GenerateILRResponseForWindowsVMs(
            ClientScriptForConnect clientScriptForConnection, out string content)
        {
            try
            {
                SystemNet.HttpWebResponse webResponse =
                    TrackingHelpers.RetryHttpWebRequest(
                        clientScriptForConnection.Url,
                        3);

                if (SystemNet.HttpStatusCode.OK == webResponse.StatusCode)
                {
                    using (Stream myResponseStream = webResponse.GetResponseStream())
                    {
                        byte[] myBuffer = new byte[4096];
                        int bytesRead;
                        MemoryStream memoryStream = new MemoryStream();
                        while ((bytesRead =
                            myResponseStream.Read(myBuffer, 0, myBuffer.Length)) > 0)
                        {
                            memoryStream.Write(myBuffer, 0, bytesRead);
                        }
                        content = Convert.ToBase64String(
                            memoryStream.ToArray());
                        string suffix = clientScriptForConnection.ScriptNameSuffix;
                        string password = this.RemovePasswordFromSuffixAndReturn(ref suffix);
                        string fileName = this.ConstructFileName(
                            suffix, clientScriptForConnection.ScriptExtension);

                        return new AzureVmRPMountScriptDetails(
                            clientScriptForConnection.OsType, fileName, password);
                    }
                }
                throw new Exception(
                    "Error in Web Request to download center for ILR script" +
                    webResponse.StatusCode);
            }
            catch (Exception e)
            {
                Logger.Instance.WriteWarning(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Generates ILR Response object for Linux VMs.
        /// </summary>
        /// <param name="clientScriptForConnection"></param>
        /// <param name="protectedItemName"></param>
        /// <param name="recoveryPointTime"></param>
        /// <returns></returns>
        private AzureVmRPMountScriptDetails GenerateILRResponseForLinuxVMs(
            ClientScriptForConnect clientScriptForConnection,
            string protectedItemName, string recoveryPointTime, out string content)
        {
            try
            {
                content = clientScriptForConnection.ScriptContent;
                string suffix = clientScriptForConnection.ScriptNameSuffix;
                string fileName, password;
                if (suffix != null)
                {
                    this.RemovePasswordFromSuffixAndReturn(ref suffix);
                    fileName = this.ConstructFileName(
                        suffix, clientScriptForConnection.ScriptExtension);
                }
                else
                {
                    string operatingSystemName = clientScriptForConnection.OsType;
                    string vmName = protectedItemName.Split(';')[3];
                    fileName = string.Format(
                            CultureInfo.InvariantCulture,
                            "{0}_{1}_{2}" + clientScriptForConnection.ScriptExtension,
                            operatingSystemName,
                            vmName,
                            recoveryPointTime);
                }
                password = this.ReplacePasswordInScriptContentAndReturn(ref content);

                return new AzureVmRPMountScriptDetails(
                    clientScriptForConnection.OsType, fileName, password);
            }
            catch (Exception e)
            {
                Logger.Instance.WriteWarning(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Removes password from ScriptNameSuffix and returns it.
        /// </summary>
        /// <param name="suffix"></param>
        /// <returns></returns>
        private string RemovePasswordFromSuffixAndReturn(ref string suffix)
        {
            int lastIndexOfUnderScore = suffix.LastIndexOf('_');
            int passwordOffset = lastIndexOfUnderScore +
                33;
            string password = suffix.Substring(
                passwordOffset, 15);
            suffix = suffix.Remove(
                passwordOffset, 15);
            return password;
        }

        /// <summary>
        /// Constructs ILR script file name
        /// </summary>
        /// <param name="suffix"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        private string ConstructFileName(string suffix, string extension)
        {
            string format = "{0}" + extension;
            return string.Format(
                    CultureInfo.InvariantCulture,
                    format,
                    suffix);
        }

        /// <summary>
        /// Replaces password in ILR script with dummy password and returns it
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string ReplacePasswordInScriptContentAndReturn(ref string content)
        {
            // decode to text format from Base 64 encoded format
            var contentBytes = Convert.FromBase64String(content);
            content = Encoding.UTF8.GetString(contentBytes);

            string targetPasswordString =
                "TargetPassword=\"";
            string password = content.Substring(
                content.IndexOf(
                    targetPasswordString) + targetPasswordString.Length, 15);

            string pattern = targetPasswordString + ".*\"";
            string replacement =
                targetPasswordString + "UserInput012345\"";
            Regex rgx = new Regex(pattern);
            content = rgx.Replace(content, replacement);

            // ecode back to Base 64 format
            contentBytes = Encoding.UTF8.GetBytes(content);
            content = Convert.ToBase64String(contentBytes);

            return password;
        }

        private bool ShouldUseOsa(AzureVmRecoveryPoint rp, bool osaOption)
        {
            bool useOsa = false;
            if (osaOption)
            {
                if (rp.OriginalSAEnabled)
                {
                    useOsa = true;
                }
                else
                {
                    throw new Exception("This recovery point doesn’t have the capability to restore disks to their original storage account. Re-run the restore command without the UseOriginalStorageAccountForDisks parameter.");
                }
            }

            return useOsa;
        }

        public List<PointInTimeBase> GetLogChains()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}