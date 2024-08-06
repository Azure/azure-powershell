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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using System;
using System.Collections.Generic;
using RestAzureNS = Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Restores the disk based on the recovery point and other input parameters
        /// </summary>
        /// <param name="rp">Recovery point to restore the disk to</param>
        /// <param name="storageAccountLocation">Location of the storage account where to restore the disk</param>
        /// <param name="triggerRestoreRequest"></param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="vaultLocation"></param>
        /// <param name="auxiliaryAccessToken"></param>
        /// <param name="isMUAProtected"></param>
        /// <returns>Job created by this operation</returns>
        public RestAzureNS.AzureOperationResponse RestoreDisk(
            AzureRecoveryPoint rp,
            string storageAccountLocation,
            RestoreRequestResource triggerRestoreRequest,
            string vaultName = null,
            string resourceGroupName = null,
            string vaultLocation = null,
            string auxiliaryAccessToken = "",
            bool isMUAProtected = false)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, rp.Id);
            string recoveryPointId = rp.RecoveryPointId;
            //validtion block
            if (!triggerRestoreRequest.Properties.GetType().IsSubclassOf(typeof(AzureWorkloadRestoreRequest)))
            {
                if (storageAccountLocation != vaultLocation && rp.BackupManagementType != Models.BackupManagementType.AzureStorage)
                {
                    throw new Exception(Resources.TriggerRestoreIncorrectRegion);
                }
            }

            #region MUA 
            Dictionary<string, List<string>> customHeaders = new Dictionary<string, List<string>>();
            string operationRequest = null;

            if (isMUAProtected)
            {
                List<ResourceGuardProxyBaseResource> resourceGuardMapping = ListResourceGuardMapping(vaultName, resourceGroupName);

                if (resourceGuardMapping != null && resourceGuardMapping.Count != 0)
                {
                    foreach (ResourceGuardOperationDetail operationDetail in resourceGuardMapping[0].Properties.ResourceGuardOperationDetails)
                    {
                        if (operationDetail.VaultCriticalOperation == "Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/recoveryPoints/restore/action") operationRequest = operationDetail.DefaultResourceRequest;
                    }

                    if (operationRequest != null)
                    {
                        triggerRestoreRequest.Properties.ResourceGuardOperationRequests = new List<string>();
                        triggerRestoreRequest.Properties.ResourceGuardOperationRequests.Add(operationRequest);
                    }
                }
            }

            if (auxiliaryAccessToken != null && auxiliaryAccessToken != "")
            {
                if (operationRequest != null)
                {
                    customHeaders.Add("x-ms-authorization-auxiliary", new List<string> { "Bearer " + auxiliaryAccessToken });
                }
                else if (!isMUAProtected)
                {
                    // resx                    
                    throw new ArgumentException(String.Format("operation not critical. please try without the Token parameter"));
                }
                else
                {
                    throw new ArgumentException(String.Format(Resources.UnexpectedParameterToken, "Restore"));
                }
            }
            #endregion

            var response = BmsAdapter.Client.Restores.TriggerWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerUri,
                protectedItemUri,
                recoveryPointId,
                triggerRestoreRequest,
                null,
                customHeaders,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }


        /// <summary>
        /// Gets the access token for CRR operation
        /// </summary>
        /// <param name="rp">Recovery point to restore the disk to</param>
        /// <param name="secondaryRegion">secondary region where to trigger the restore</param>
        /// <param name="vaultName">Name of recovery services vault</param>
        /// <param name="resourceGroupName">Name of the vault resource group</param>
        /// <param name="backupManagementType"></param>
        /// <returns>CRR access token</returns>
        public CrrModel.CrrAccessToken GetCRRAccessToken(
            AzureRecoveryPoint rp,
            string secondaryRegion,
            string vaultName = null,
            string resourceGroupName = null,
            string backupManagementType = null)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, rp.Id);
            string recoveryPointId = rp.RecoveryPointId;

            CrrModel.AADPropertiesResource userInfo = GetAADProperties(secondaryRegion, backupManagementType);

            if(userInfo == null || userInfo.Properties == null)
            {
                throw new Exception(Resources.AADPropertiesCouldNotBeFetchedException);
            }

            var accessToken = CrrAdapter.Client.RecoveryPoints.GetAccessTokenWithHttpMessagesAsync(vaultName ?? BmsAdapter.GetResourceName(), resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName, containerUri, protectedItemUri, recoveryPointId, userInfo).Result.Body; 

            if(accessToken == null || accessToken.Properties == null)
            {
                throw new Exception(Resources.CRRAccessTokenCouldNotBeFetchedException);
            }

            return accessToken.Properties; 
        }

        /// <summary>
        /// Restores the disk to the secondaryRegion based on the recovery point and other input parameters
        /// </summary>
        /// <param name="rp">Recovery point to restore the disk to</param>
        /// <param name="storageAccountLocation">ID of the storage account where to restore the disk</param>
        /// <param name="triggerCRRRestoreRequest">Location of the storage account where to restore the disk</param>
        /// <param name="secondaryRegion">Type of the storage account where to restore the disk</param>
        /// <returns>Job created by this operation</returns>
        public RestAzureNS.AzureOperationResponse RestoreDiskSecondryRegion(
            AzureRecoveryPoint rp,
            CrrModel.CrossRegionRestoreRequest triggerCRRRestoreRequest,
            string storageAccountLocation = null,
            string secondaryRegion = null)
        {  
            //validation block
            if (!triggerCRRRestoreRequest.RestoreRequest.GetType().IsSubclassOf(typeof(CrrModel.AzureWorkloadRestoreRequest)))
            {
                if (storageAccountLocation != secondaryRegion && rp.BackupManagementType != Models.BackupManagementType.AzureStorage)
                {
                    throw new Exception(Resources.TriggerRestoreIncorrectRegion);
                }
            }
            
            var response = CrrAdapter.Client.CrossRegionRestore.TriggerWithHttpMessagesAsync(secondaryRegion, triggerCRRRestoreRequest.CrossRegionRestoreAccessDetails , triggerCRRRestoreRequest.RestoreRequest).Result;
            return response;
        }
    }
}