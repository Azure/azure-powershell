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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Services
{
    /// <summary>
    /// Adapter for database ledger digest upload operations
    /// </summary>
    public class AzureSqlDatabaseLedgerDigestUploadAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlDatabaseLedgerDigestUploadCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseLedgerDigestUploadCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database backup adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseLedgerDigestUploadAdapter(IAzureContext context)
        {
            Context = context;
            _subscription = context?.Subscription;
            Communicator = new AzureSqlDatabaseLedgerDigestUploadCommunicator(Context);
        }

        /// <summary>
        /// Gets a ledger digest upload configuration for a Azure SQL Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <returns>A ledger digest upload</returns>
        internal AzureSqlDatabaseLedgerDigestUploadModel GetLedgerDigestUpload(
            string resourceGroup,
            string serverName,
            string databaseName)
        {
            var configuration = Communicator.GetLedgerDigestUpload(resourceGroup, serverName, databaseName);

            return new AzureSqlDatabaseLedgerDigestUploadModel(resourceGroup, serverName, databaseName, configuration);
        }

        /// <summary>
        /// Create or update a ledger digest upload configuration for a Azure SQL Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <param name="model">AzureSqlDatabaseLedgerDigestUploadModel model</param>
        /// <returns>A ledger digest upload</returns>
        internal AzureSqlDatabaseLedgerDigestUploadModel SetLedgerDigestUpload(
            string resourceGroup,
            string serverName,
            string databaseName,
            AzureSqlDatabaseLedgerDigestUploadModel model)
        {
            var configuration = Communicator.SetLedgerDigestUpload(
                model.ResourceGroupName, 
                model.ServerName, 
                model.DatabaseName, 
                new Management.Sql.Models.LedgerDigestUploads()
                {
                    DigestStorageEndpoint = model.Endpoint
                });

            return new AzureSqlDatabaseLedgerDigestUploadModel(resourceGroup, serverName, databaseName, configuration);
        }

        /// <summary>
        /// Disables ledger digest upload configuration for a Azure SQL Database
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <returns>A ledger digest upload</returns>
        internal AzureSqlDatabaseLedgerDigestUploadModel DisableLedgerDigestUpload(
            string resourceGroup,
            string serverName,
            string databaseName)
        {
            var configuration = Communicator.DisableLedgerDigestUpload(
                resourceGroup,
                serverName,
                databaseName);

            return new AzureSqlDatabaseLedgerDigestUploadModel(resourceGroup, serverName, databaseName, configuration);
        }


        private string GetResourceGroupNameFromResourceId(string resourceId)
        {
            if (resourceId.Contains("/resourceGroups/"))
            {
                return resourceId.Split('/')[4];
            }
            return null;
        }
    }
}
