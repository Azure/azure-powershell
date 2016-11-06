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
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Restores the disk based on the recovery point and other input parameters
        /// </summary>
        /// <param name="rp">Recovery point to restore the disk to</param>
        /// <param name="storageAccountId">ID of the storage account where to restore the disk</param>
        /// <param name="storageAccountLocation">Location of the storage account where to restore the disk</param>
        /// <param name="storageAccountType">Type of the storage account where to restore the disk</param>
        /// <returns>Job created by this operation</returns>
        public BaseRecoveryServicesJobResponse RestoreDisk(AzureVmRecoveryPoint rp, string storageAccountId, 
            string storageAccountLocation, string storageAccountType)
        {
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            string resourceName = BmsAdapter.GetResourceName();
            string vaultLocation = BmsAdapter.GetResourceLocation();
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, rp.Id);
            string recoveryPointId = rp.RecoveryPointId;
            //validtion block
            if(storageAccountLocation != vaultLocation)
            {
                throw new Exception(Resources.RestoreDiskIncorrectRegion);
            }
            
            string vmType = containerUri.Split(';')[1].Equals("iaasvmcontainer", StringComparison.OrdinalIgnoreCase) 
                ? "Classic" : "Compute";
            string strType = storageAccountType.Equals("Microsoft.ClassicStorage/StorageAccounts", 
                StringComparison.OrdinalIgnoreCase) ? "Classic" : "Compute";
            if(vmType != strType)
            {
                throw new Exception(String.Format(Resources.RestoreDiskStorageTypeError, vmType));
            }

            IaasVMRestoreRequest restoreRequest = new IaasVMRestoreRequest()
            {
                CreateNewCloudService = false,
                RecoveryPointId = recoveryPointId,
                RecoveryType = RecoveryType.RestoreDisks,
                Region = vaultLocation,
                StorageAccountId = storageAccountId,
                SourceResourceId = rp.SourceResourceId,
            };

            TriggerRestoreRequest triggerRestoreRequest = new TriggerRestoreRequest();
            triggerRestoreRequest.Item = new RestoreRequestResource();
            triggerRestoreRequest.Item.Properties = new RestoreRequest();
            triggerRestoreRequest.Item.Properties = restoreRequest;

            var response = BmsAdapter.Client.Restores.TriggerRestoreAsync(
                resourceGroupName, 
                resourceName, 
                BmsAdapter.GetCustomRequestHeaders(),
                AzureFabricName, 
                containerUri, 
                protectedItemUri, 
                recoveryPointId, 
                triggerRestoreRequest, 
                BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }
    }
}