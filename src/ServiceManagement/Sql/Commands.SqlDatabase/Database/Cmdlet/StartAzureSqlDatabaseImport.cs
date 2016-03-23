// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.ImportExport;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Imports a database from blob storage into SQL Azure.
    /// </summary>
    [Cmdlet("Start", "AzureSqlDatabaseImport", ConfirmImpact = ConfirmImpact.Medium)]
    public class StartAzureSqlDatabaseImport : SqlDatabaseCmdletBase
    {
        #region Parameter Set names

        /// <summary>
        /// The name of the parameter set that uses the Azure Storage Container object
        /// </summary>
        internal const string ByContainerObjectParameterSet =
            "ByContainerObject";

        /// <summary>
        /// The name of the parameter set that uses the storage container name
        /// </summary>
        internal const string ByContainerNameParameterSet =
            "ByContainerName";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the connection information for connecting to the server
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            HelpMessage = "The connection information for connecting to a server. " +
            "This can be an Azure SQL Server connection context that uses username with password.")]
        [ValidateNotNullOrEmpty]
        public ISqlServerConnectionInformation SqlConnectionContext { get; set; }

        /// <summary>
        /// Gets or sets the storage container object containing the blob
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByContainerObjectParameterSet,
            HelpMessage = "The Azure Storage Container to place the blob in.")]
        [ValidateNotNull]
        public AzureStorageContainer StorageContainer { get; set; }

        /// <summary>
        /// Gets or sets the storage context
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByContainerNameParameterSet,
            HelpMessage = "The storage connection context")]
        [ValidateNotNull]
        public AzureStorageContext StorageContext { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage container to use.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2,
            ParameterSetName = ByContainerNameParameterSet,
            HelpMessage = "The name of the storage container to use")]
        [ValidateNotNullOrEmpty]
        public string StorageContainerName { get; set; }

        /// <summary>
        /// Gets or sets the name for the imported database
        /// </summary>
        [Parameter(Mandatory = true, Position = 2,
            ParameterSetName = ByContainerObjectParameterSet,
            HelpMessage = "The name for the imported database")]
        [Parameter(Mandatory = true, Position = 3,
            ParameterSetName = ByContainerNameParameterSet,
            HelpMessage = "The name for the imported database")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets name of the blob to use for the import
        /// </summary>
        [Parameter(Mandatory = true, Position = 3,
            ParameterSetName = ByContainerObjectParameterSet,
            HelpMessage = "The name of the blob to use for the import")]
        [Parameter(Mandatory = true, Position = 4,
            ParameterSetName = ByContainerNameParameterSet,
            HelpMessage = "The name of the blob to use for the import")]
        [ValidateNotNullOrEmpty]
        public string BlobName { get; set; }

        /// <summary>
        /// Gets or sets the edition for the newly imported database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The edition for the newly imported database")]
        [ValidateNotNull]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the maximum size for the newly imported database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The maximum size for the newly imported database")]
        public int DatabaseMaxSize { get; set; }

        #endregion

        /// <summary>
        /// Performs the call to import database using the server data service context channel.
        /// </summary>
        /// <param name="serverName">The name of the server to connect to.</param>
        /// <param name="blobUri">The storage blob Uri to import from.</param>
        /// <param name="storageAccessKey">The access key for the given storage blob.</param>
        /// <param name="fullyQualifiedServerName">The fully qualified server name.</param>
        /// <param name="databaseName">The name of the database for import.</param>
        /// <param name="edition">The edition of the database for import.</param>
        /// <param name="maxDatabaseSizeInGB">The database size for import.</param>
        /// <param name="sqlCredentials">The credentials used to connect to the database.</param>
        /// <returns>The result of the import request.  Upon success the <see cref="ImportExportRequest"/>
        /// for the request</returns>
        internal ImportExportRequest ImportSqlAzureDatabaseProcess(
            string serverName,
            Uri blobUri,
            string storageAccessKey,
            string fullyQualifiedServerName,
            string databaseName,
            string edition,
            int maxDatabaseSizeInGB,
            SqlAuthenticationCredentials sqlCredentials)
        {
            this.WriteVerbose("BlobUri: " + blobUri);
            this.WriteVerbose("ServerName: " + fullyQualifiedServerName);
            this.WriteVerbose("DatabaseName: " + databaseName);
            this.WriteVerbose("Edition: " + edition);
            this.WriteVerbose("MaxDatabaseSizeInGB: " + maxDatabaseSizeInGB);
            this.WriteVerbose("UserName: " + sqlCredentials.UserName);

            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Start the database export operation
            DacImportExportResponse response = sqlManagementClient.Dac.Import(
                serverName,
                new DacImportParameters()
                {
                    BlobCredentials = new DacImportParameters.BlobCredentialsParameter()
                    {
                        Uri = blobUri,
                        StorageAccessKey = storageAccessKey,
                    },
                    ConnectionInfo = new DacImportParameters.ConnectionInfoParameter()
                    {
                        ServerName = fullyQualifiedServerName,
                        DatabaseName = databaseName,
                        UserName = sqlCredentials.UserName,
                        Password = sqlCredentials.Password,
                    },
                    AzureEdition = edition,
                    DatabaseSizeInGB = maxDatabaseSizeInGB
                });

            ImportExportRequest result = new ImportExportRequest()
            {
                OperationStatus = Services.Constants.OperationSuccess,
                OperationDescription = CommandRuntime.ToString(),
                OperationId = response.RequestId,
                RequestGuid = response.Guid,
                ServerName = serverName,
                SqlCredentials = sqlCredentials,
            };

            return result;
        }

        /// <summary>
        /// Process the import request
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                // Obtain the Blob Uri and Access Key
                string blobUri = null;
                string accessKey = null;
                switch (this.ParameterSetName)
                {
                    case ByContainerNameParameterSet:
                        accessKey =
                            System.Convert.ToBase64String(
                                this.StorageContext.StorageAccount.Credentials.ExportKey());

                        blobUri =
                            this.StorageContext.BlobEndPoint +
                            this.StorageContainerName + "/" +
                            this.BlobName;
                        break;

                    case ByContainerObjectParameterSet:
                        accessKey =
                            System.Convert.ToBase64String(
                                this.StorageContainer.CloudBlobContainer.ServiceClient.Credentials.ExportKey());

                        blobUri =
                            this.StorageContainer.Context.BlobEndPoint +
                            this.StorageContainer.Name + "/" +
                            this.BlobName;
                        break;

                    default:
                        throw new NotSupportedException("ParameterSet");
                }

                // Retrieve the fully qualified server name
                string fullyQualifiedServerName =
                    this.SqlConnectionContext.ServerName + Profile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix);
                
                // Issue the request
                ImportExportRequest context = this.ImportSqlAzureDatabaseProcess(
                    this.SqlConnectionContext.ServerName,
                    new Uri(blobUri),
                    accessKey,
                    fullyQualifiedServerName,
                    this.DatabaseName,
                    this.MyInvocation.BoundParameters.ContainsKey("Edition") ?
                        this.Edition.ToString() : null,
                    this.MyInvocation.BoundParameters.ContainsKey("DatabaseMaxSize") ?
                        this.DatabaseMaxSize : 0,
                    this.SqlConnectionContext.SqlCredentials);

                this.WriteObject(context);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
