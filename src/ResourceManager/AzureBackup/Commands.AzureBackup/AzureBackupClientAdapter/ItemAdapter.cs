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

using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureBackupClientAdapter
    {
        /// <summary>
        /// Lists datasources in the vault
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IList<CSMProtectedItemResponse> ListDataSources(string resourceGroupName, string resourceName, CSMProtectedItemQueryObject query)
        {
            var response = AzureBackupClient.DataSource.ListCSMAsync(resourceGroupName, resourceName, query, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return (response != null) ? response.CSMProtectedItemListResponse.Value : null;
        }

        /// <summary>
        /// Lists protectable objects in the vault
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IList<CSMItemResponse> ListProtectableObjects(string resourceGroupName, string resourceName, CSMItemQueryObject query)
        {
            var response = AzureBackupClient.ProtectableObject.ListCSMAsync(resourceGroupName, resourceName, query, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return (response != null) ? response.CSMItemListResponse.Value : null;
        }

        /// <summary>
        /// Dsiable protection
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="dsType"></param>
        /// <param name="dsId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid DisableProtection(string resourceGroupName, string resourceName, string containerName, string itemName)
        {
            var response = AzureBackupClient.DataSource.DisableProtectionCSMAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), containerName, itemName, CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Enable Protection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid EnableProtection(string resourceGroupName, string resourceName, string containerName, string itemName, CSMSetProtectionRequest request)
        {
            var response = AzureBackupClient.DataSource.EnableProtectionCSMAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), containerName, itemName, request, CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Update Protection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid UpdateProtection(string resourceGroupName, string resourceName, string containerName, string itemName, CSMUpdateProtectionRequest request)
        {
            var response = AzureBackupClient.DataSource.UpdateProtectionCSMAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), containerName, itemName, request, CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Trigger backup on a DS
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public Guid TriggerBackup(string resourceGroupName, string resourceName, string containerName, string itemName)
        {
            var response = AzureBackupClient.BackUp.TriggerBackUpAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), containerName, itemName, CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Lists recovery points for specified item
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public IEnumerable<CSMRecoveryPointResponse> ListRecoveryPoints(string resourceGroupName, string resourceName, string containerName, string itemName)
        {
            var response = AzureBackupClient.RecoveryPoint.ListAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), containerName, itemName, CmdletCancellationToken).Result;
            return (response != null) ? response.CSMRecoveryPointListResponse.Value : null;
        }

        /// <summary>
        /// Lists recovery points for specified item
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public CSMRecoveryPointResponse GetRecoveryPoint(string resourceGroupName, string resourceName, string containerName, string itemName, string recoveryPointName)
        {
            var response = AzureBackupClient.RecoveryPoint.GetAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), containerName, itemName, recoveryPointName, CmdletCancellationToken).Result;
            return (response != null) ? response.CSMRecoveryPointResponse : null;
        }

        /// <summary>
        /// Lists recovery points for specified item
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <param name="recoveryPointName"></param>
        /// <returns></returns>
        public Guid TriggerRestore(string resourceGroupName, string resourceName, string containerName, string itemName, string recoveryPointName, CSMRestoreRequest csmRestoreRequest)
        {
            var response = AzureBackupClient.Restore.TriggerResotreAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), containerName, itemName, recoveryPointName, csmRestoreRequest, CmdletCancellationToken).Result;
            return response.OperationId;
        }
    }
}