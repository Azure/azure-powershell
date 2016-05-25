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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Adapter
{
    /// <summary>
    /// Adapter for firewall operations
    /// </summary>
    public class AzureSqlDatabaseTransparentDataEncryptionAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseTransparentDataEncryptionCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Transparent Data Encryption adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseTransparentDataEncryptionAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseTransparentDataEncryptionCommunicator(Context);
        }

        /// <summary>
        /// Gets a Transparent Data Encryption in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <returns>The Transparent Data Encryption</returns>
        public AzureSqlDatabaseTransparentDataEncryptionModel GetTransparentDataEncryption(string resourceGroupName, string serverName, string databaseName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
            return CreateTransparentDataEncryptionModelFromResponse(resourceGroupName, serverName, databaseName, resp);
        }

        /// <summary>
        /// Upserts a Transparent Data Encryption
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of ther server</param>
        /// <param name="model">The Transparent Data Encryption to create</param>
        /// <returns>The updated server model</returns>
        public AzureSqlDatabaseTransparentDataEncryptionModel UpsertTransparentDataEncryption(AzureSqlDatabaseTransparentDataEncryptionModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.DatabaseName, Util.GenerateTracingId(), new TransparentDataEncryptionCreateOrUpdateParameters()
            {
                Properties = new TransparentDataEncryptionCreateOrUpdateProperties()
                {
                    State = model.State.ToString(),
                }
            });

            return CreateTransparentDataEncryptionModelFromResponse(model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.TransparentDataEncryption to AzureSqlDatabaseTransparentDataEncryptionModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlDatabaseTransparentDataEncryptionModel CreateTransparentDataEncryptionModelFromResponse(string resourceGroup, string serverName, string databaseName, Management.Sql.Models.TransparentDataEncryption resp)
        {
            AzureSqlDatabaseTransparentDataEncryptionModel TransparentDataEncryption = new AzureSqlDatabaseTransparentDataEncryptionModel();

            TransparentDataEncryption.ResourceGroupName = resourceGroup;
            TransparentDataEncryption.ServerName = serverName;
            TransparentDataEncryption.DatabaseName = databaseName;

            TransparentDataEncryptionStateType State = TransparentDataEncryptionStateType.Disabled;
            Enum.TryParse<TransparentDataEncryptionStateType>(resp.Properties.State, true, out State);
            TransparentDataEncryption.State = State;

            return TransparentDataEncryption;
        }

        /// <summary>
        /// Convert a Management.Sql.Models.TransparentDataEncryption to AzureSqlDatabaseTransparentDataEncryptionModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlDatabaseTransparentDataEncryptionActivityModel CreateTransparentDataEncryptionActivityModelFromResponse(string resourceGroup, string serverName, string databaseName, Management.Sql.Models.TransparentDataEncryptionActivity resp)
        {
            AzureSqlDatabaseTransparentDataEncryptionActivityModel TransparentDataEncryptionActivity = new AzureSqlDatabaseTransparentDataEncryptionActivityModel();

            TransparentDataEncryptionActivity.ResourceGroupName = resourceGroup;
            TransparentDataEncryptionActivity.ServerName = serverName;
            TransparentDataEncryptionActivity.DatabaseName = databaseName;

            TransparentDataEncryptionActivityStatusType status = TransparentDataEncryptionActivityStatusType.Decrypting;
            Enum.TryParse<TransparentDataEncryptionActivityStatusType>(resp.Properties.Status, true, out status);
            TransparentDataEncryptionActivity.Status = status;
            TransparentDataEncryptionActivity.PercentComplete = resp.Properties.PercentComplete;

            return TransparentDataEncryptionActivity;
        }

        /// <summary>
        /// Gets a list of Transparent Data Encryption Activity
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database</param>
        /// <returns>A list of Transparent Data Encryption Activities</returns>
        internal IList<AzureSqlDatabaseTransparentDataEncryptionActivityModel> ListTransparentDataEncryptionActivity(string resourceGroupName, string serverName, string databaseName)
        {
            List<AzureSqlDatabaseTransparentDataEncryptionActivityModel> list = new List<AzureSqlDatabaseTransparentDataEncryptionActivityModel>();

            var resp = Communicator.ListActivity(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());

            return resp.Select((tdeActivity) =>
            {
                return CreateTransparentDataEncryptionActivityModelFromResponse(resourceGroupName, serverName, databaseName, tdeActivity);
            }).ToList();
        }
    }
}
