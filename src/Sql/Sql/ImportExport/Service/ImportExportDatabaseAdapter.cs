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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ImportExport.Model;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Microsoft.Azure.Commands.Sql.ImportExport.Service
{
    /// <summary>
    /// Adapter for import/export operations
    /// </summary>
    public class ImportExportDatabaseAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private ImportExportDatabaseCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a firewall rule adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public ImportExportDatabaseAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new ImportExportDatabaseCommunicator(Context);
        }

        /// <summary>
        /// Creates a new export request
        /// </summary>
        /// <param name="exportRequest">Export request parameters</param>
        /// <returns>Operation response including the OperationStatusLink to get the operation status</returns>
        public AzureSqlDatabaseImportExportBaseModel Export(AzureSqlDatabaseImportExportBaseModel exportRequest)
        {
            ExportDatabaseDefinition parameters = new ExportDatabaseDefinition()
            {
                AdministratorLogin = exportRequest.AdministratorLogin,
                AdministratorLoginPassword = AzureSqlServerAdapter.Decrypt(exportRequest.AdministratorLoginPassword),
                StorageKey = exportRequest.StorageKey,
                StorageKeyType = exportRequest.StorageKeyType.ToString(),
                StorageUri = exportRequest.StorageUri.ToString(),
                NetworkIsolation = null
            };

            if(!string.IsNullOrEmpty(exportRequest.NetworkIsolationSettings.SqlServerResourceId)
                || !string.IsNullOrEmpty(exportRequest.NetworkIsolationSettings.StorageAccountResourceId))
            {
                parameters.NetworkIsolation = new Management.Sql.Models.NetworkIsolationSettings()
                {
                    SqlServerResourceId = exportRequest.NetworkIsolationSettings.SqlServerResourceId,
                    StorageAccountResourceId = exportRequest.NetworkIsolationSettings.StorageAccountResourceId
                };
            }

            if (exportRequest.AuthenticationType != AuthenticationType.None)
            {
                parameters.AuthenticationType = exportRequest.AuthenticationType.ToString().ToLowerInvariant();
            }

            Uri azureAsyncOperation = null;
            ImportExportOperationResult response;

            response = Communicator.BeginExport(
                exportRequest.ResourceGroupName,
                exportRequest.ServerName,
                exportRequest.DatabaseName,
                parameters,
                out azureAsyncOperation);

            return CreateImportExportResponse(response, exportRequest, azureAsyncOperation);
        }

        /// <summary>
        /// Creates a new import request
        /// </summary>
        /// <param name="importRequest">Import request parameters</param>
        /// <returns>Operation response including the OperationStatusLink to get the operation status</returns>
        public AzureSqlDatabaseImportExportBaseModel ImportNewDatabase(AzureSqlDatabaseImportModel importRequest)
        {
            Management.Sql.Models.ImportNewDatabaseDefinition parameters = new Management.Sql.Models.ImportNewDatabaseDefinition()
            {
                AdministratorLogin = importRequest.AdministratorLogin,
                AdministratorLoginPassword = AzureSqlServerAdapter.Decrypt(importRequest.AdministratorLoginPassword),
                StorageKey = importRequest.StorageKey,
                StorageKeyType = importRequest.StorageKeyType.ToString(),
                StorageUri = importRequest.StorageUri.ToString(),
                MaxSizeBytes = importRequest.DatabaseMaxSizeBytes.ToString(),
                Edition = importRequest.Edition != Database.Model.DatabaseEdition.None ? importRequest.Edition.ToString() : string.Empty,
                ServiceObjectiveName = importRequest.ServiceObjectiveName,
                DatabaseName = importRequest.DatabaseName,
                NetworkIsolation = new Management.Sql.Models.NetworkIsolationSettings()
                {
                    SqlServerResourceId = importRequest.NetworkIsolationSettings.SqlServerResourceId,
                    StorageAccountResourceId = importRequest.NetworkIsolationSettings.StorageAccountResourceId
                }
            };

            if (importRequest.AuthenticationType != AuthenticationType.None)
            {
                parameters.AuthenticationType = importRequest.AuthenticationType.ToString().ToLowerInvariant();
            }

            Uri azureAsyncOperation = null;
            ImportExportOperationResult response;

            response = Communicator.BeginImportNewDatabase(importRequest.ResourceGroupName, importRequest.ServerName, parameters, out azureAsyncOperation);

            return CreateImportExportResponse(response, importRequest, azureAsyncOperation);
        }

        /// <summary>
        /// Gets the status of an import/export operation
        /// </summary>
        /// <param name="operationStatusLink">The operation status link</param>
        /// <returns>Operation status response</returns>
        public AzureSqlDatabaseImportExportStatusModel GetStatus(string operationStatusLink)
        {
            HttpResponseMessage rawHttpResponse;
            ImportExportOperationResult response = Communicator.GetOperationStatus(operationStatusLink, out rawHttpResponse);

            OperationStatus? operationStatus = GetOperationStatusFromHttpStatus(rawHttpResponse.StatusCode);

            AzureSqlDatabaseImportExportStatusModel status = new AzureSqlDatabaseImportExportStatusModel()
            {
                ErrorMessage = response.ErrorMessage,
                LastModifiedTime = response.LastModifiedTime,
                QueuedTime = response.QueuedTime,
                StatusMessage = response.Status, // in spite of the name, the field called "Status" is the correct one to put into the "StatusMessage" field
                Status = operationStatus.HasValue ? operationStatus.Value.ToString() : "",
                RequestType = response.RequestType,
                PrivateEndpointRequestStatus = response.PrivateEndpointConnections?.Select(pec => new PrivateEndpointRequestStatus()
                {
                    PrivateEndpointConnectionName = pec.PrivateEndpointConnectionName,
                    PrivateLinkServiceId = pec.PrivateLinkServiceId,
                    Status = pec.Status
                }).ToArray(),
                OperationStatusLink = operationStatusLink
            };

            return status;
        }

        /// <summary>
        /// Creates the response model given server response
        /// </summary>
        /// <param name="response">Server Response</param>
        /// <param name="originalModel"></param>
        /// <param name="statusLink"></param>
        /// <returns>Response Model</returns>
        private AzureSqlDatabaseImportExportBaseModel CreateImportExportResponse(ImportExportOperationResult response, AzureSqlDatabaseImportExportBaseModel originalModel, Uri statusLink)
        {
            AzureSqlDatabaseImportExportBaseModel model = originalModel == null ? new AzureSqlDatabaseImportExportBaseModel() : originalModel.Copy();
            model.OperationStatusLink = statusLink?.ToString();

            // It looks like the ExportDatabase SDK call is currently broken (and returns "null" instead of the response object).
            // I need to check in a sev2 hotfix now. Once the SDK issue has been resolved, un-comment this and the asserts in
            // the test code
            // Also can probably remove the "LastLocationHeader" hack and just rely on the header in the returned results
            // model.Status = response.Status;
            return model;
        }

        /// <summary>
        /// Get the "Status" value for the Import/Export request
        ///
        /// This logic is copied verbatim from the (generated) legacy SDK:
        /// <see cref="Azure.Management.Sql.LegacySdk.ImportExportOperations.GetImportExportOperationStatusAsync"/>
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        protected OperationStatus? GetOperationStatusFromHttpStatus(HttpStatusCode statusCode)
        {
            OperationStatus? status = null;
            switch (statusCode)
            {
                // We expect this switch statement to cover all possible cases of return values from the service
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    status = OperationStatus.Succeeded;
                    break;
                case HttpStatusCode.Accepted:
                    status = OperationStatus.InProgress;
                    break;
            }

            return status;
        }
    }
}
