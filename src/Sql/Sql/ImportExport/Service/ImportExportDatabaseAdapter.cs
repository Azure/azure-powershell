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
<<<<<<< HEAD
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
=======
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
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
<<<<<<< HEAD
            ExportRequestParameters parameters = new ExportRequestParameters()
=======
            ExportDatabaseDefinition parameters = new ExportDatabaseDefinition()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                AdministratorLogin = exportRequest.AdministratorLogin,
                AdministratorLoginPassword = AzureSqlServerAdapter.Decrypt(exportRequest.AdministratorLoginPassword),
                StorageKey = exportRequest.StorageKey,
                StorageKeyType = exportRequest.StorageKeyType.ToString(),
<<<<<<< HEAD
                StorageUri = exportRequest.StorageUri
            };

=======
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

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            if (exportRequest.AuthenticationType != AuthenticationType.None)
            {
                parameters.AuthenticationType = exportRequest.AuthenticationType.ToString().ToLowerInvariant();
            }

<<<<<<< HEAD
            ImportExportResponse response = Communicator.Export(exportRequest.ResourceGroupName, exportRequest.ServerName,
                exportRequest.DatabaseName, parameters);
            return CreateImportExportResponse(response, exportRequest);
=======
            Uri azureAsyncOperation = null;
            ImportExportOperationResult response;

            response = Communicator.BeginExport(
                exportRequest.ResourceGroupName,
                exportRequest.ServerName,
                exportRequest.DatabaseName,
                parameters,
                out azureAsyncOperation);

            return CreateImportExportResponse(response, exportRequest, azureAsyncOperation);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Creates a new import request
        /// </summary>
        /// <param name="importRequest">Import request parameters</param>
        /// <returns>Operation response including the OperationStatusLink to get the operation status</returns>
<<<<<<< HEAD
        public AzureSqlDatabaseImportExportBaseModel Import(AzureSqlDatabaseImportModel importRequest)
        {
            ImportRequestParameters parameters = new ImportRequestParameters()
=======
        public AzureSqlDatabaseImportExportBaseModel ImportNewDatabase(AzureSqlDatabaseImportModel importRequest)
        {
            Management.Sql.Models.ImportNewDatabaseDefinition parameters = new Management.Sql.Models.ImportNewDatabaseDefinition()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                AdministratorLogin = importRequest.AdministratorLogin,
                AdministratorLoginPassword = AzureSqlServerAdapter.Decrypt(importRequest.AdministratorLoginPassword),
                StorageKey = importRequest.StorageKey,
                StorageKeyType = importRequest.StorageKeyType.ToString(),
<<<<<<< HEAD
                StorageUri = importRequest.StorageUri,
                DatabaseMaxSize = importRequest.DatabaseMaxSizeBytes,
                Edition = importRequest.Edition != Database.Model.DatabaseEdition.None ? importRequest.Edition.ToString() : string.Empty,
                ServiceObjectiveName = importRequest.ServiceObjectiveName,
                DatabaseName = importRequest.DatabaseName
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            };

            if (importRequest.AuthenticationType != AuthenticationType.None)
            {
                parameters.AuthenticationType = importRequest.AuthenticationType.ToString().ToLowerInvariant();
            }

<<<<<<< HEAD
            ImportExportResponse response = Communicator.Import(importRequest.ResourceGroupName, importRequest.ServerName, parameters);

            return CreateImportExportResponse(response, importRequest);
=======
            Uri azureAsyncOperation = null;
            ImportExportOperationResult response;

            response = Communicator.BeginImportNewDatabase(importRequest.ResourceGroupName, importRequest.ServerName, parameters, out azureAsyncOperation);

            return CreateImportExportResponse(response, importRequest, azureAsyncOperation);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Gets the status of an import/export operation
        /// </summary>
        /// <param name="operationStatusLink">The operation status link</param>
        /// <returns>Operation status response</returns>
        public AzureSqlDatabaseImportExportStatusModel GetStatus(string operationStatusLink)
        {
<<<<<<< HEAD
            ImportExportOperationStatusResponse resposne = Communicator.GetStatus(operationStatusLink);

            AzureSqlDatabaseImportExportStatusModel status = new AzureSqlDatabaseImportExportStatusModel()
            {
                ErrorMessage = resposne.ErrorMessage,
                LastModifiedTime = resposne.LastModifiedTime,
                QueuedTime = resposne.QueuedTime,
                StatusMessage = resposne.StatusMessage,
                Status = resposne.Status.ToString(),
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                OperationStatusLink = operationStatusLink
            };

            return status;
        }

        /// <summary>
        /// Creates the response model given server response
        /// </summary>
        /// <param name="response">Server Response</param>
        /// <returns>Response Model</returns>
<<<<<<< HEAD
        private AzureSqlDatabaseImportExportBaseModel CreateImportExportResponse(ImportExportResponse response, AzureSqlDatabaseImportExportBaseModel originalModel)
        {
            AzureSqlDatabaseImportExportBaseModel model = originalModel == null ? new AzureSqlDatabaseImportExportBaseModel() : originalModel.Copy();
            model.OperationStatusLink = response.OperationStatusLink;
            model.Status = response.Status.ToString();
            model.ErrorMessage = response.Error == null ? "" : response.Error.Message;
            return model;
        }
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
