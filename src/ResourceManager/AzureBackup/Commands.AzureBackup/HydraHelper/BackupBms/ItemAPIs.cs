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

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public partial class HydraHelper
    {
        /// <summary>
        /// Lists datasources in the vault
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IList<CSMProtectedItemResponse> BackupListDataSources(string resourceGroupName, string resourceName, CSMProtectedItemQueryObject query)
        {
            var response = BackupBmsAdapter.Client.DataSource.ListCSMAsync(
                resourceGroupName, resourceName, query,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return (response != null) ? response.CSMProtectedItemListResponse.Value : null;
        }

        /// <summary>
        /// Lists protectable objects in the vault
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IList<CSMItemResponse> BackupListProtectableObjects(string resourceGroupName, string resourceName, CSMItemQueryObject query)
        {
            var response = BackupBmsAdapter.Client.ProtectableObject.ListCSMAsync(
                resourceGroupName, resourceName, query,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
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
        public Guid BackupDisableProtection(string resourceGroupName, string resourceName, string containerName, string itemName)
        {
            var response = BackupBmsAdapter.Client.DataSource.DisableProtectionCSMAsync(
                resourceGroupName, resourceName, BackupBmsAdapter.GetCustomRequestHeaders(),
                containerName, itemName, BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Enable Protection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid BackupEnableProtection(string resourceGroupName, string resourceName, string containerName, string itemName, CSMSetProtectionRequest request)
        {
            var response = BackupBmsAdapter.Client.DataSource.EnableProtectionCSMAsync(
                resourceGroupName, resourceName, BackupBmsAdapter.GetCustomRequestHeaders(),
                containerName, itemName, request, BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Update Protection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid BackupUpdateProtection(string resourceGroupName, string resourceName, string containerName, string itemName, CSMUpdateProtectionRequest request)
        {
            var response = BackupBmsAdapter.Client.DataSource.UpdateProtectionCSMAsync(
                resourceGroupName, resourceName, BackupBmsAdapter.GetCustomRequestHeaders(),
                containerName, itemName, request, BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Trigger backup on a DS
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public Guid BackupTriggerBackup(string resourceGroupName, string resourceName, string containerName, string itemName)
        {
            var response = BackupBmsAdapter.Client.BackUp.TriggerBackUpAsync(
                resourceGroupName, resourceName, BackupBmsAdapter.GetCustomRequestHeaders(),
                containerName, itemName, BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Lists recovery points for specified item
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public IEnumerable<CSMRecoveryPointResponse> BackupListRecoveryPoints(string resourceGroupName, string resourceName, string containerName, string itemName)
        {
            var response = BackupBmsAdapter.Client.RecoveryPoint.ListAsync(
                resourceGroupName, resourceName, BackupBmsAdapter.GetCustomRequestHeaders(),
                containerName, itemName, BackupBmsAdapter.CmdletCancellationToken).Result;
            return (response != null) ? response.CSMRecoveryPointListResponse.Value : null;
        }

        /// <summary>
        /// Lists recovery points for specified item
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public CSMRecoveryPointResponse BackupGetRecoveryPoint(string resourceGroupName, string resourceName, string containerName, string itemName, string recoveryPointName)
        {
            var response = BackupBmsAdapter.Client.RecoveryPoint.GetAsync(
                resourceGroupName, resourceName, BackupBmsAdapter.GetCustomRequestHeaders(),
                containerName, itemName, recoveryPointName, BackupBmsAdapter.CmdletCancellationToken).Result;
            return (response != null) ? response.CSMRecoveryPointResponse : null;
        }

        /// <summary>
        /// Lists recovery points for specified item
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itemName"></param>
        /// <param name="recoveryPointName"></param>
        /// <returns></returns>
        public Guid BackupTriggerRestore(string resourceGroupName, string resourceName, string containerName, string itemName, string recoveryPointName, CSMRestoreRequest csmRestoreRequest)
        {
            var response = BackupBmsAdapter.Client.Restore.TriggerResotreAsync(
                resourceGroupName, resourceName, BackupBmsAdapter.GetCustomRequestHeaders(),
                containerName, itemName, recoveryPointName, csmRestoreRequest, BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }
    }
}