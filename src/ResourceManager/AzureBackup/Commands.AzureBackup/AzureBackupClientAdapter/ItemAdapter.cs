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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureBackupClientAdapter
    {
        /// <summary>
        /// Lists datasources in the vault
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<DataSourceInfo> ListDataSources(DataSourceQueryParameter query)
        {
            var response = AzureBackupClient.DataSource.ListAsync(query, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return (response != null) ? response.DataSources.Objects : null;
        }

        /// <summary>
        /// Lists protectable objects in the vault
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<ProtectableObjectInfo> ListProtectableObjects(POQueryParameter query)
        {
            var response = AzureBackupClient.ProtectableObject.ListAsync(query, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return (response != null) ? response.ProtectableObject.Objects : null;
        }

        /// <summary>
        /// Dsiable protection
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="dsType"></param>
        /// <param name="dsId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid DisableProtection(string containerName, string dsType, string dsId, RemoveProtectionRequestInput request)
        {
            var response = AzureBackupClient.DataSource.DisableProtectionAsync(GetCustomRequestHeaders(), containerName, dsType, dsId, request, CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Enable Protection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid EnableProtection(SetProtectionRequestInput request)
        {
            var response = AzureBackupClient.DataSource.EnableProtectionAsync(GetCustomRequestHeaders(), request, CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Trigger backup on a DS
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="dsType"></param>
        /// <param name="dsId"></param>
        /// <returns></returns>
        public Guid TriggerBackup(string containerName, string dsType, string dsId)
        {
            var response = AzureBackupClient.BackUp.TriggerBackUpAsync(GetCustomRequestHeaders(), containerName, dsType, dsId, CmdletCancellationToken).Result;
            return response.OperationId;              
        }

        /// <summary>
        /// Lists recovery points for specified item
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="dsType"></param>
        /// <param name="dsId"></param>
        /// <returns></returns>
        public IEnumerable<RecoveryPointInfo> ListRecoveryPoints(string containerName, string dsType, string dsId)
        {
            var response = AzureBackupClient.RecoveryPoint.ListAsync(GetCustomRequestHeaders(), containerName, dsType, dsId, CmdletCancellationToken).Result;
            return (response != null) ? response.RecoveryPoints.Objects : null;
        }
    }
}