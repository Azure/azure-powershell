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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ImportExport.Model;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;

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
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs a firewall rule adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public ImportExportDatabaseAdapter(AzureContext context)
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
            ExportRequestParameters parameters = new ExportRequestParameters()
            {
                AdministratorLogin = exportRequest.AdministratorLogin,
                AdministratorLoginPassword = AzureSqlServerAdapter.Decrypt(exportRequest.AdministratorLoginPassword),
                StorageKey = exportRequest.StorageKey,
                StorageKeyType = exportRequest.StorageKeyType.ToString(),
                StorageUri = exportRequest.StorageUri
            };

            if (exportRequest.AuthenticationType != AuthenticationType.None)
            {
                parameters.AuthenticationType = exportRequest.AuthenticationType.ToString().ToLowerInvariant();
            }

            ImportExportResponse response = Communicator.Export(exportRequest.ResourceGroupName, exportRequest.ServerName,
                exportRequest.DatabaseName, parameters, Util.GenerateTracingId());
            return CreateImportExportResponse(response, exportRequest);
        }

        /// <summary>
        /// Creates a new import request
        /// </summary>
        /// <param name="importRequest">Import request parameters</param>
        /// <returns>Operation response including the OperationStatusLink to get the operation status</returns>
        public AzureSqlDatabaseImportExportBaseModel Import(AzureSqlDatabaseImportModel importRequest)
        {
            ImportRequestParameters parameters = new ImportRequestParameters()
            {
                AdministratorLogin = importRequest.AdministratorLogin,
                AdministratorLoginPassword = AzureSqlServerAdapter.Decrypt(importRequest.AdministratorLoginPassword),
                StorageKey = importRequest.StorageKey,
                StorageKeyType = importRequest.StorageKeyType.ToString(),
                StorageUri = importRequest.StorageUri,
                DatabaseMaxSize = importRequest.DatabaseMaxSizeBytes,
                Edition = importRequest.Edition != Database.Model.DatabaseEdition.None ? importRequest.Edition.ToString() : string.Empty,
                ServiceObjectiveName = importRequest.ServiceObjectiveName,
                DatabaseName = importRequest.DatabaseName
            };

            if (importRequest.AuthenticationType != AuthenticationType.None)
            {
                parameters.AuthenticationType = importRequest.AuthenticationType.ToString().ToLowerInvariant();
            }

            ImportExportResponse response = Communicator.Import(importRequest.ResourceGroupName, importRequest.ServerName, parameters, Util.GenerateTracingId());

            return CreateImportExportResponse(response, importRequest);
        }

        /// <summary>
        /// Gets the status of an import/export operation
        /// </summary>
        /// <param name="operationStatusLink">The operation status link</param>
        /// <returns>Operation status response</returns>
        public AzureSqlDatabaseImportExportStatusModel GetStatus(string operationStatusLink)
        {
            ImportExportOperationStatusResponse resposne = Communicator.GetStatus(operationStatusLink, Util.GenerateTracingId());

            AzureSqlDatabaseImportExportStatusModel status = new AzureSqlDatabaseImportExportStatusModel()
            {
                ErrorMessage = resposne.ErrorMessage,
                LastModifiedTime = resposne.LastModifiedTime,
                QueuedTime = resposne.QueuedTime,
                StatusMessage = resposne.StatusMessage,
                Status = resposne.Status.ToString(),
                OperationStatusLink = operationStatusLink
            };

            return status;
        }

        /// <summary>
        /// Creates the response model given server response
        /// </summary>
        /// <param name="response">Server Response</param>
        /// <returns>Response Model</returns>
        private AzureSqlDatabaseImportExportBaseModel CreateImportExportResponse(ImportExportResponse response, AzureSqlDatabaseImportExportBaseModel originalModel)
        {
            AzureSqlDatabaseImportExportBaseModel model = originalModel == null ? new AzureSqlDatabaseImportExportBaseModel() : originalModel.Copy();
            model.OperationStatusLink = response.OperationStatusLink;
            model.Status = response.Status.ToString();
            model.ErrorMessage = response.Error == null ? "" : response.Error.Message;
            return model;
        }
    }
}
